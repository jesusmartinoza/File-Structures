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

namespace File_Structures
{
    public partial class MainForm : MaterialForm, CreateEntityListener, CreateAttributeListener
    {
        SortedList<string, Entity> entities;
        List<Attribute> attributes;
        File f;

        /**
         * Initialize components and MaterialForm
         * */
        public MainForm()
        {
            f = new File("file-structures.dat");
            string[] entityHeaders = {"Name", "Address", "Attributes Address", "Data Address", "Next Entity Address" };
            string[] attrHeaders = {"Entity", "Name", "Address", "Type", "Length", "Index Type", "Index Address", "Next Attribute Address" };
            entities = f.GetEntities();
            attributes = f.GetAttributes();

            InitializeComponent();
            InitDataGridView(dataGridViewEntities, entityHeaders);
            InitDataGridView(dataGridViewAttrs, attrHeaders);
            CenterToScreen();

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
         * Capture cell click and decide if is edit or delete click
         * */
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1) {
                var entity = entities.ElementAt(e.RowIndex);

                switch (e.ColumnIndex)
                {
                    case 5: // Edit button
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
                        break;
                    case 9: // Delete button
                        DeleteAttribute(attr);
                        break;
                }
            }
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
         * Show dialog to create entity.
         * */
        private void BtnAddEntity_Click(object sender, EventArgs e)
        {
            FormCreateEntity f = new FormCreateEntity(this);
            f.ShowDialog(this);
        }

        /**
         * Show dialog to create attribute.
         * */
        private void BtnAddAttr_Click(object sender, EventArgs e)
        {
            if (entities.Count == 0)
                MessageBox.Show("Please create some entity :)");
            else {
                FormCreateAttribute f = new FormCreateAttribute(this, entities);
                f.ShowDialog(this);
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {

        }

        /**
         * Clear Rows of dataGridViewEntities and fill with entities list.
         * */
        private void ReloadEntitiesGridView()
        {
            dataGridViewEntities.Rows.Clear();

            foreach (KeyValuePair<string, Entity> kvp in entities) {
                Entity e = kvp.Value;
                dataGridViewEntities.Rows.Add(kvp.Key, e.FileAddress, e.AttrsAddress, e.DataAddress, e.NextEntityAddress);
            }
        }

        /**
         * Clear Rows of dataGridViewAttrs and fill with entities list.
         * */
        private void ReloadAttrsGridView()
        {
            dataGridViewAttrs.Rows.Clear();

            foreach (var a in attributes)
                dataGridViewAttrs.Rows.Add(a.EntityName, a.Name, a.FileAddress, a.Type, a.Length, a.IndexTypeV, a.IndexAddress, a.NexAttributeAddress);
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

                if (prevIndex != -1)
                {
                    Entity prevEntity = entities.Values[prevIndex];

                    newEntity.FileAddress = size;
                    newEntity.NextEntityAddress = prevEntity.NextEntityAddress;
                    prevEntity.NextEntityAddress = size; // Address where would be located the new entity.

                    f.WriteEntity(prevEntity);
                }
                else
                {
                    newEntity.FileAddress = entities.Count == 1 ? size + 1 : size;
                    newEntity.NextEntityAddress = f.GetHeader();
                    f.SetHeader(newEntity.FileAddress);
                }

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
    }
}
