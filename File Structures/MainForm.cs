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

namespace File_Structures
{
    public partial class MainForm : MaterialForm, CreateEntityListener, CreateAttributeListener, CreateEntryListener,
        ModifyEntityListener, ModifyAttributeListener
    {
        SortedList<string, Entity> entities;
        List<Attribute> attributes;
        Dictionary<string, Entry> entries;
        File f;

        /**
         * Initialize components and MaterialForm
         * */
        public MainForm()
        {
            entities = new SortedList<string, Entity>();
            attributes = new List<Attribute>();
            entries = new Dictionary<string, Entry>();
            string[] entityHeaders = {"Name", "Address", "Attributes Address", "Data Address", "Next Entity Address" };
            string[] attrHeaders = {"Entity", "Name", "Address", "Type", "Length", "Index Type", "Index Address", "Next Attribute Address" };

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
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Orange400, TextShade.WHITE);
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
            AddDataGridViewButtonColumn(gridView, "EDIT", "Edit", "#1abc9c");
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
         * Delete entity from memoery list and file
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

        /**
         * Delete entity from memoery list and file
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
                dataGridViewEntities.Rows.Add(kvp.Key, e.FileAddress, e.AttrsAddress, e.DataAddress, e.NextEntityAddress);
                listViewEntities.Items.Add(kvp.Key);
            }
        }

        /**
         * Clear Rows of dataGridViewEntities and fill with entities list.
         * */
        private void ReloadEntriesList()
        {
            listViewEntries.Items.Clear();
            foreach(Entry e in entries.Values)
            {
                var listViewItem = new ListViewItem(Array.ConvertAll(e.Data, d => d.ToString()));
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
                dataGridViewAttrs.Rows.Add(a.EntityName.Trim(), a.Name.Trim(), a.FileAddress, a.Type, a.Length, a.IndexTypeV, a.IndexAddress, a.NexAttributeAddress);
        }

        /**
         * Cast every entry data to string and add to actual entries list
         */
        private void AddEntryToList(Entry entry)
        {
            var listViewItem = new ListViewItem(Array.ConvertAll(entry.Data, d => d.ToString()));
            listViewEntries.Items.Add(listViewItem);
            entries.Add(entry.PrimaryValue, entry);

            entries = entries.OrderBy(e => e.Value.SearchValue).ToDictionary(pair => pair.Key, pair => pair.Value);
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
            } else {
                MessageBox.Show(attr.Name + " already exists in file.");
            }
        }

        public void OnCreateEntry(Entry entry)
        {
            if(entries.ContainsKey(entry.PrimaryValue))
            {
                MessageBox.Show("A entry with value " + entry.PrimaryValue + " already exists in file.");
            } else
            {
                AddEntryToList(entry);
                ReloadEntriesList();
                List<Entry> sorted = entries.Values.ToList();
                long size = f.GetSize();

                // Get previous item and modify it
                int prevIndex = sorted.IndexOf(entry) - 1;

                entry.FileAddress = size;
                if (prevIndex != -1)
                {
                    Entry prevEntry = sorted[prevIndex];

                    entry.NextEntryAddress = prevEntry.NextEntryAddress;
                    prevEntry.NextEntryAddress = size; // Address where would be located the new entity.

                    f.WriteEntry(prevEntry);
                }
                else
                {
                    Entity entityFather = entities.First(enti => enti.Key.Equals(listViewEntities.FocusedItem.Text)).Value;
                    entry.NextEntryAddress = entityFather.DataAddress;
                    entityFather.DataAddress = size;

                    f.WriteEntity(entityFather);
                }

                // Write new entry in file and reload grid view
                f.WriteEntry(entry);
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
            if(f == null) {
                btnSaveFile.PerformClick();
            } else if (entities.Count == 0)
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
            {
                btnSaveFile.PerformClick();
            }
            else if (entities.Count == 0  || listViewEntities.Items.Count == 0)
                MessageBox.Show("Please create some entity with attributes :)");
            else
            {
                FormCreateEntry f = new FormCreateEntry(this, listViewEntities.FocusedItem.Text, attributes);
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
                    case 5: // Edit button
                        FormModifyEntity formModifyEntity = new FormModifyEntity(this, entity.Value);
                        formModifyEntity.Show(this);
                        break;
                    case 6: // Delete button
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

                switch (e.ColumnIndex)
                {
                    case 8: // Edit button
                        FormModifyAttribute formModifyAttr = new FormModifyAttribute(attr, this);
                        formModifyAttr.Show(this);
                        break;
                    case 9: // Delete button
                        DeleteAttribute(attr);
                        break;
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
            }
        }

        /**
         * Change attributes list using selected entity.
         */
        private void listViewEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (MaterialListView)sender;
            listViewEntries.Clear();

            listViewEntries.Columns.Add("File Address");
            foreach (var attr in attributes)
            {
                if (attr.EntityName.Equals(list.FocusedItem.Text))
                    listViewEntries.Columns.Add(attr.Name);
            }
            listViewEntries.Columns.Add("Next");
            entries = f.GetEntriesFrom(
                entities.First(enti => enti.Key.Equals(list.FocusedItem.Text)).Value,
                attributes.Where(a => a.EntityName.Equals(list.FocusedItem.Text)).ToList());
            ReloadEntriesList();

            listViewEntries.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewEntries.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
