using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using Shields.GraphViz.Models;
using Shields.GraphViz.Services;
using Shields.GraphViz.Components;
using System.Threading;
using CSharpTest.Net.Serialization;
using CSharpTest.Net.Collections;
using System.Text.RegularExpressions;
using System.Collections.Immutable;

namespace File_Structures
{
    public partial class MainForm : MaterialForm, CreateEntityListener, CreateAttributeListener, CreateEntryListener,
        ModifyEntityListener, ModifyAttributeListener
    {
        SortedList<string, Entity> entities;
        Dictionary<string, Entry> entries;
        Entity selectedEntity;
        Entry selectedEntry;
        File f;

        public static List<Attribute> attributes;
        public static Dictionary<string, Entity> relations;

        /**
         * Initialize components and MaterialForm
         * */
        public MainForm()
        {
            entities = new SortedList<string, Entity>();
            attributes = new List<Attribute>();
            entries = new Dictionary<string, Entry>();
            relations = new Dictionary<string, Entity>();

            string[] entityHeaders = { "Name"};
            string[] attrHeaders = {"Entity", "Name", /*"Address",*/ "Type", "Length", "Index Type"/*, "Index Address", "Next Attribute Address"*/ };

            InitializeComponent();
            InitDataGridView(dataGridViewEntities, entityHeaders);
            InitDataGridView(dataGridViewAttrs, attrHeaders);
            CenterToScreen();
            ReloadEntitiesGridView();
            ReloadAttrsGridView();

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Pink400, TextShade.BLACK);
        }

        /**
         * Set DataGridView headers and column buttons
         * @param gridView - DataGridView to fill
         * @param headers - Headers of the grid
         * */
        private void InitDataGridView(DataGridView gridView, string[] headers)
        {
            gridView.ColumnCount = headers.Length;

            // Add headers
            for (int i = 0; i < headers.Length; i++) {
                gridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                gridView.Columns[i].Name = headers[i];
            }

            // Add edit and delete cell column
            AddDataGridViewButtonColumn(gridView, "EDIT", "Edit", "#E91E63");
            AddDataGridViewButtonColumn(gridView, "X", "Delete", "#D91E18");
        }

        /**
         * Add ButtonColumn to @gridView
         * @param text Button text
         * @param name Button name
         * @param hexcolor Color in HEX 
         * */
        private void AddDataGridViewButtonColumn(DataGridView gridView, string text, string name, string hexColor)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "";
            btn.Width = 35;
            btn.FlatStyle = FlatStyle.Flat;
            btn.DefaultCellStyle.ForeColor = Color.White;
            btn.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(hexColor);
            btn.Text = text;
            btn.Name = name;
            btn.UseColumnTextForButtonValue = true;

            gridView.Columns.Add(btn);
        }

        /**
         * Find in tree a matching entry by File Address and merge them
         */
        private void MergeEntriesAndTree()
        {
            foreach(var attr in attributes)
                if(attr.Tree != null)
                    foreach(var t in attr.Tree)
                    {
                        var entry = entries.Where(e => e.Value.FileAddress == t.Value);

                        if(entry.Count() > 0)
                            entry.First().Value.BPlusValue = t.Key.ToString();
                    }
        }

        /**
         * Delete entity from memory list and file
         * */
        private void DeleteAttribute(Attribute attr)
        {
            List<Attribute> entityAttrs = attributes.Where(a => a.EntityName.Equals(attr.EntityName)).ToList();
            var index = entityAttrs.IndexOf(attr);
            var entity = entities[attr.EntityName];

            if (index == 0) {
                entity.AttrsAddress = attr.NexAttributeAddress; // Update entity
                f.WriteEntity(entity);
                ReloadEntitiesGridView();
            }
            else {
                var prevAttr = entityAttrs.ElementAt(index - 1);

                prevAttr.NexAttributeAddress = attr.NexAttributeAddress;
                f.WriteAttribute(prevAttr);
            }

            // Remove from memory list
            attributes.Remove(attr);
            ReloadAttrsGridView();
        }

        private void DeleteEntry(Entry entry)
        {
            var keyList = entries.Keys.ToList();
            var index = keyList.IndexOf(selectedEntry.PrimaryValue);

            if (index == 0)
            {
                selectedEntity.DataAddress = entry.NextEntryAddress;
                f.WriteEntity(selectedEntity);
            }
            else
            {
                var prevEntryKey = keyList.ElementAt(index - 1);
                var prevEntry = entries[prevEntryKey];

                prevEntry.NextEntryAddress = entry.NextEntryAddress;

                f.WriteEntry(prevEntry);
            }
            entries.Remove(entry.PrimaryValue);
            WriteIndexValue(entry, false, true);
            ReloadEntriesList();
        }

        /**
         * Delete entity from memory list and file
         * */
        private void DeleteEntity(Entity entity)
        {
            var index = entities.IndexOfValue(entity);
            
            if (index == 0)
                f.SetHeader(entity.NextEntityAddress); // Update header
            else {
                var prevEntity = entities.ElementAt(index - 1);

                prevEntity.Value.NextEntityAddress = entity.NextEntityAddress;
                f.WriteEntity(prevEntity.Value);
            }

            // Remove from memory list
            entities.RemoveAt(index);
            ReloadEntitiesGridView();
        }

        /**
         * Clear Rows of dataGridViewEntities and fill with entities list.
         * */
        private void ReloadEntitiesGridView()
        {
            dataGridViewEntities.Rows.Clear();
            listViewEntities.Items.Clear();

            foreach (KeyValuePair<string, Entity> kvp in entities) {
                Entity e = kvp.Value;
                dataGridViewEntities.Rows.Add(kvp.Key /*, e.FileAddress, e.AttrsAddress, e.DataAddress, e.NextEntityAddress*/);
                listViewEntities.Items.Add(kvp.Key);
            }
        }

        /**
         * Clear Rows of listViewEntries and fill with entries dictionary.
         * */
        private void ReloadEntriesList()
        {
            listViewEntries.Items.Clear();
            foreach(Entry e in entries.Values.OrderBy(e => e.SearchValue))
            {
                var list = e.Data.ToList();
                list.RemoveAt(0);
                var listViewItem = new ListViewItem(Array.ConvertAll(list.ToArray(), d => d.ToString()));
                listViewItem.Name = e.PrimaryValue;
                listViewEntries.Items.Add(listViewItem);
            }
        }

        /**
         * Clear Rows of dataGridViewAttrs and fill with entities list.
         * */
        private void ReloadAttrsGridView()
        {
            dataGridViewAttrs.Rows.Clear();

            foreach (var a in attributes)
                dataGridViewAttrs.Rows.Add(a.EntityName.Trim(), a.Name.Trim(), /*a.FileAddress,*/ a.Type, a.Length, a.IndexTypeV/*, a.IndexAddress, a.NexAttributeAddress*/);
        }

        /**
         * Cast every entry data to string and add to actual entries list
         */
        private void AddEntryToList(Entry entry)
        {
            var list = entry.Data.ToList();
            list.RemoveAt(0);
            var listViewItem = new ListViewItem(Array.ConvertAll(list.ToArray(), d => d.ToString()));
            listViewEntries.Items.Add(listViewItem);
            entries.Add(entry.PrimaryValue, entry);

            entries = entries.OrderBy(e => e.Value.SearchValue).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /**
         * Reserve memory in file to store index.
         * Iterate throught attributes and reserve for PrimaryKey and ForeignKey
         */
        private void ReserveIndexSpace()
        {
            foreach(Attribute a in attributes.Where(a => a.EntityName.Equals(selectedEntity.Name.Trim())).ToList())
            {
                switch (a.IndexTypeV)
                {
                    case Attribute.IndexType.primaryKey:
                        f.ReserveDenseIndexSpace(a);
                        break;
                    case Attribute.IndexType.foreignKey:
                        f.ReserveSparseIndexSpace(a);
                        break;
                }
            }
        }

        /**
         * Iterate over attributes that correspond on the selected entity 
         * and update Index Data
         */
        private void WriteIndexValue(Entry entry, bool isNew = true, bool delete = false)
        {
            foreach (Attribute a in attributes.Where(a => a.EntityName.Equals(selectedEntity.Name.Trim())).ToList())
            {
                switch (a.IndexTypeV)
                {
                    case Attribute.IndexType.primaryKey:
                        if (isNew && !a.IndexData.ContainsKey(int.Parse(entry.PrimaryValue)))
                            a.IndexData.Add(int.Parse(entry.PrimaryValue), entry.FileAddress.ToString());
                        else
                            a.IndexData.Remove(int.Parse(entry.PrimaryValue));
                        f.WriteIndexData(a);
                        break;
                    case Attribute.IndexType.foreignKey:
                        // Find repeated key value and append it
                        var repeated = a.IndexData.Where(k => k.Key.ToString() == entry.ForeignValue);

                        if (!isNew)
                        {
                            var val = a.IndexData[int.Parse(entry.ForeignValue)];
                            val = val.Replace(entry.FileAddress.ToString(), "").Replace(",,", ",");
                            a.IndexData[int.Parse(entry.ForeignValue)] = val;
                        }
                        else if (repeated.Count() > 0)
                        {
                            var value = repeated.First().Value + "," + entry.FileAddress.ToString();
                            a.IndexData[int.Parse(entry.ForeignValue)] = value;
                        } else {
                            a.IndexData.Add(int.Parse(entry.ForeignValue), entry.FileAddress.ToString());
                        }
                        f.WriteIndexData(a);
                        break;
                    case Attribute.IndexType.bPlusTree:
                        if(delete)
                        {
                            try
                            {
                                a.Tree.Remove(Int32.Parse(entry.BPlusValue));
                            } catch(Exception e)
                            {
                                // Error on delete
                            }
                        }
                        else
                            a.Tree.TryAdd(Int32.Parse(entry.BPlusValue), entry.FileAddress);
                        break;
                }
            }
        }

        private void ReloadIndexList()
        {
            listViewIndexAttr.Items.Clear();
            ListViewGroup pk = new ListViewGroup("Primary key");
            ListViewGroup fk = new ListViewGroup("Foreign key");
            ListViewGroup bT = new ListViewGroup("B+ Tree");

            listViewIndexAttr.Groups.Add(pk);
            listViewIndexAttr.Groups.Add(fk);
            listViewIndexAttr.Groups.Add(bT);

            foreach (Attribute a in attributes)
            {
                switch(a.IndexTypeV)
                {
                    case Attribute.IndexType.primaryKey:
                        listViewIndexAttr.Items.Add(a.Name).Group = pk;
                        break;
                    case Attribute.IndexType.foreignKey:
                        listViewIndexAttr.Items.Add(a.Name).Group = fk;
                        break;
                    case Attribute.IndexType.bPlusTree:
                        listViewIndexAttr.Items.Add(a.Name).Group = bT;
                        break;
                }
            }
        }

        /************************************************************************
         *                I  N  T  E  R  F  A  C  E  S                          *
         ************************************************************************/
        public void OnCreateEntity(string name)
        {
            if (!entities.ContainsKey(name)) {
                long size = f.GetSize();
                Entity newEntity = new Entity(name);

                // Push entity into SortedList
                entities.Add(name, newEntity);

                // Get previous item and modify it
                int prevIndex = entities.IndexOfKey(name) - 1;

                if (prevIndex != -1) {
                    Entity prevEntity = entities.Values[prevIndex];

                    newEntity.FileAddress = size;
                    newEntity.NextEntityAddress = prevEntity.NextEntityAddress;
                    prevEntity.NextEntityAddress = size; // Address where would be located the new entity.

                    f.WriteEntity(prevEntity);
                }
                else {
                    newEntity.FileAddress = size;
                    newEntity.NextEntityAddress = f.GetHeader();
                    f.SetHeader(newEntity.FileAddress);
                }

                entities.Remove(name);
                entities.Add(name, newEntity);

                // Write new entity in file and reload grid view
                f.WriteEntity(newEntity);
                ReloadEntitiesGridView();
            } else {
                MessageBox.Show(name + " already exists in file.");
            }
        }

        public void OnCreateAttribute(Attribute attr)
        {
            if (!attributes.Contains(attr)) {
                List<Attribute> entityAttrs = attributes.Where(a => a.EntityName.Equals(attr.EntityName)).ToList();
                long size = f.GetSize();
                var entity = entities[attr.EntityName];

                // Push attribute into List
                attr.FileAddress = size;
                attributes.Add(attr);

                // Modify entity or previous items
                if (entityAttrs.Count == 0) {
                    // Update entity
                    entity.AttrsAddress = attr.FileAddress;
                    f.WriteEntity(entity);
                    ReloadEntitiesGridView();
                } else {
                    entityAttrs.Add(attr);

                    int prevIndex = entityAttrs.IndexOf(attr) - 1;
                    Attribute prevAttr = entityAttrs[prevIndex];

                    attr.NexAttributeAddress = prevAttr.NexAttributeAddress;
                    prevAttr.NexAttributeAddress = size; // Address where would be located the new attribute.

                    f.WriteAttribute(prevAttr);
                }

                // Write new attribute in file and reload grid view
                f.WriteAttribute(attr);
                ReloadAttrsGridView();
                attributes = f.GetAttributes();
            } else {
                MessageBox.Show(attr.Name + " already exists in file.");
            }
        }

        /**
         * Verify if primary key already exists.
         * Add Entry to entries list and write in file.
         */
        public void OnCreateEntry(Entry entry, Boolean isNew, Entry originalEntry)
        {
            if(entries.ContainsKey(entry.PrimaryValue) && isNew)
            {
                MessageBox.Show("An entry with value " + entry.PrimaryValue + " already exists in file.");
            } else
            {
                List<Entry> items = entries.Values.OrderBy(e => e.SearchValue).ToList();
                int position = 0;

                // Find position of the element in the list
                for (; position < items.Count; position++)
                    if (entry.CompareTo(items[position]) < 0)
                        break;

                // If first entry, reserve index space in file
                if (selectedEntity.DataAddress == -1)
                    ReserveIndexSpace();

                if(isNew)
                    entry.FileAddress = f.GetSize();

                // If first position, update header
                if (position == 0)
                {
                    entry.NextEntryAddress = selectedEntity.DataAddress;
                    selectedEntity.DataAddress = entry.FileAddress;
                    f.WriteEntity(selectedEntity);
                } else
                {
                    long aux = entry.NextEntryAddress;
                    // Update prev item
                    Entry prevEntry = items[position - 1];

                    entry.NextEntryAddress = prevEntry.NextEntryAddress;
                    prevEntry.NextEntryAddress = entry.FileAddress; // Address where would be located the new entry.

                    f.WriteEntry(prevEntry);

                    // Update next item
                    if(position < items.Count - 1 && !isNew)
                    {
                        Entry nextEntry = items[position];
                        nextEntry.NextEntryAddress = aux;
                        f.WriteEntry(nextEntry);
                    }
                }

                if(isNew)
                {
                    AddEntryToList(entry);
                } else
                {
                    WriteIndexValue(originalEntry, isNew, true);
                    entries.Remove(originalEntry.PrimaryValue);
                    entries.Add(entry.PrimaryValue, entry);
                }

                f.WriteEntry(entry);
                WriteIndexValue(entry, true);
                
                List<Entry> sorted = entries.Values.OrderBy(e => e.SearchValue).ToList();
                Entry last = sorted.Last();

                last.NextEntryAddress = -1;
                f.WriteEntry(last);
                ReloadEntriesList();
            }
        }

        public void OnModifyAttribute(Attribute attribute)
        {
            f.WriteAttribute(attribute);
            ReloadAttrsGridView();
        }

        public void OnModifyEntity(Entity entity)
        {
            if(!entities.ContainsKey(entity.Name.Trim())) {
                // Find entity by fileAddress and delete it
                foreach (KeyValuePair<string, Entity> kvp in entities)
                {
                    Entity e = kvp.Value;

                    if (e.FileAddress == entity.FileAddress)
                    {
                        entities.Remove(kvp.Key);
                        break;
                    }
                }

                entities.Add(entity.Name.Trim(), entity);

                int address = 8;
                int i = entities.Count;

                // Recalculate all file address :P
                foreach (KeyValuePair<string, Entity> kvp in entities)
                {
                    Entity e = kvp.Value;
                    e.FileAddress = address;

                    address += 63;
                    e.NextEntityAddress = address;

                    if(--i == 0)
                        e.NextEntityAddress = -1;

                    f.WriteEntity(e);
                }

                ReloadEntitiesGridView();
                ReloadAttrsGridView();
            } else {
                MessageBox.Show(entity.Name + " already exists in file.");
            }
        }

        /************************************************************************
         *                          E  V  E  N  T  S                            *
         ************************************************************************/
        /**
        * Show dialog to create entity.
        * */
        private void BtnAddEntity_Click(object sender, EventArgs e)
        {
            if (f == null) {
                btnSaveFile.PerformClick();
            } else { 
                FormCreateEntity f = new FormCreateEntity(this);
                f.ShowDialog(this);
            }
        }

        /**
         * Show dialog to create attribute.
         * */
        private void BtnAddAttr_Click(object sender, EventArgs e)
        {
            if(f == null)
                btnSaveFile.PerformClick();
            else if (entities.Count == 0)
                MessageBox.Show("Please create some entity :)");
            else {
                FormCreateAttribute f = new FormCreateAttribute(this, entities);
                f.ShowDialog(this);
            }
        }

        /**
         * Show dialog to create entry.
         * */
        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (f == null)
                btnSaveFile.PerformClick();
            else if (entities.Count == 0)
                MessageBox.Show("Please create some entity with attributes :)");
            else if (selectedEntity == null)
                MessageBox.Show("Select entity");
            else
            {
                FormCreateEntry f = new FormCreateEntry(this, selectedEntity.Name.Trim(), attributes);
                f.ShowDialog(this);
            }
        }

        /**
         * Capture cell click and decide if is edit or delete click
         * */
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var entity = entities.ElementAt(e.RowIndex);

                switch (e.ColumnIndex)
                {
                    case 1: // Edit button
                        FormModifyEntity formModifyEntity = new FormModifyEntity(this, entity.Value);
                        formModifyEntity.Show(this);
                        break;
                    case 2: // Delete button
                        DeleteEntity(entity.Value);
                        break;
                }
            }
        }

        /**
         * Capture cell click and decide if is edit or delete click.
         * TODO: Validate empty row
         * */
        private void dataGridViewAttrs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var attr = attributes.ElementAt(e.RowIndex);

                if (entities.First(ent => ent.Key == attr.EntityName).Value.DataAddress != -1)
                    MessageBox.Show("This entity already has entries. Cannot modify :/");
                else
                {
                    switch (e.ColumnIndex)
                    {
                        case 5: // Edit button
                            FormModifyAttribute formModifyAttr = new FormModifyAttribute(attr, this);
                            formModifyAttr.Show(this);
                            break;
                        case 6: // Delete button
                            DeleteAttribute(attr);
                            break;
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                f = new File(openFileDialog.FileName);
                entities = f.GetEntities();
                attributes = f.GetAttributes();

                ReloadEntitiesGridView();
                ReloadAttrsGridView();
                emptyState.Visible = false;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                if(f == null) {
                    f = new File(saveFileDialog.FileName);
                } else if(!saveFileDialog.FileName.Equals(f.Fs.Name)) {
                    System.IO.File.Copy(f.Fs.Name, saveFileDialog.FileName, true);
                }
                emptyState.Visible = false;
            }
        }

        /**
         * Change attributes list using selected entity.
         */
        private void listViewEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (MaterialListView)sender;
            selectedEntity = entities.First(enti => enti.Key.Equals(list.FocusedItem.Text)).Value;
            listViewEntries.Clear();
            foreach (var attr in attributes)
            {
                if (attr.EntityName.Equals(list.FocusedItem.Text))
                    listViewEntries.Columns.Add(attr.Name, attr.Length * 4 + attr.Name.Length * 10);
            }
            entries = f.GetEntriesFrom(selectedEntity,
                attributes.Where(a => a.EntityName.Equals(list.FocusedItem.Text)).ToList());
            MergeEntriesAndTree();
            ReloadEntriesList();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ((MaterialTabControl)sender).SelectedIndex;
            switch (index)
            {
                case 3: ReloadIndexList(); break;
            }
        }

        /**
         * Fill Index info table
         */
        private void listViewIndexAttr_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (MaterialListView)sender;

            if (list.FocusedItem == null) // Click on list group header
                return;

            var sorted = f.GetIndexData(attributes.First(a => a.Name == list.FocusedItem.Text));

            listViewIndexRep.Items.Clear();

            foreach (KeyValuePair<object, string> kvp in sorted)
            {
                string[] row = new string[] { kvp.Key.ToString(), kvp.Value};
                listViewIndexRep.Items.Add(new ListViewItem(row));
            }

            if(list.FocusedItem.Group.Header == "B+ Tree")
            {
                textBoxTreeLog.Visible = true;
                pictureBoxTree.Visible = true;
                iconEye.Visible = true;
                var attr = attributes.Find(a => a.Name.Trim() == list.FocusedItem.Text);
                attr.SetBPlusTreeLog(textBoxTreeLog, pictureBoxTree);
            } else
            {
                textBoxTreeLog.Visible = false;
                pictureBoxTree.Visible = false;
                iconEye.Visible = false;
            }
        }

        private void listViewEntries_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = listViewEntries.FocusedItem;
                if (item.Bounds.Contains(e.Location))
                {
                    selectedEntry = entries.First(entry => entry.Key.Equals(item.Name)).Value;
                    contextMenuEntry.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuEntry_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "Edit":
                    FormCreateEntry f = new FormCreateEntry(this, selectedEntry, selectedEntity, attributes);
                    f.ShowDialog(this);
                    break;
                case "Delete": DeleteEntry(selectedEntry); break;
            }
        }

        private void iconEye_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(pictureBoxTree.ImageLocation);
        }
    }
}
