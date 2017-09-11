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
    public partial class MainForm : MaterialForm, CreateEntityListener
    {
        SortedList<string, Entity> entities;
        List<Attribute> attributes;
        File f;

        /**
         * Initialize components and MaterialForm
         * */
        public MainForm()
        {
            entities = new SortedList<string, Entity>();
            f = new File("file-structures.dat");

            InitializeComponent();
            InitDataGridView();
            CenterToScreen();

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Orange400, TextShade.WHITE);
        }

        /**
         * Set DataGridView headers and column buttons
         * */
        private void InitDataGridView()
        {
            string[] columns = { "Name", "Address", "Attributes Address", "Data Address", "Next Entity Address" };

            dataGridViewEntities.ColumnCount = columns.Length;

            // Add headers
            for (int i = 0; i < columns.Length; i++) {
                dataGridViewEntities.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewEntities.Columns[i].Name = columns[i];
            }

            // Add edit and delete cell column
            AddDataGridViewButtonColumn("EDIT", "Edit", "#1abc9c");
            AddDataGridViewButtonColumn("X", "Delete", "#D91E18");

        }

        /**
         * Add ButtonColumn to @gridView
         * @param text Button text
         * @param name Button name
         * @param hexcolor Color in HEX 
         * */
        private void AddDataGridViewButtonColumn(string text, string name, string hexColor)
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

            dataGridViewEntities.Columns.Add(btn);
        }

        /**
         * Capture cell click and decide if is edit or delete click
         * */
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 5: // Edit button
                    break;
                case 6: // Delete button
                    MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                    break;
            }
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
            FormCreateAttribute f = new FormCreateAttribute();
            f.ShowDialog(this);
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

        /************************************************************************
         *                I  N  T  E  R  F  A  C  E  S                          *
         ************************************************************************/
        public void OnCreateEntity(string name)
        {
            if (entities.ContainsKey(name)) {
                MessageBox.Show(name + " already exists in file.");
            } else {
                Entity newEntity = new Entity(name);

                // Push entity into SortedList
                entities.Add(name, newEntity);

                // Get previous item and modify it
                int prevIndex = entities.IndexOfKey(name) - 1;

                if (prevIndex != -1) {
                    Entity prevEntity = entities.Values[prevIndex];
                    long size = f.GetSize();

                    newEntity.FileAddress = size;
                    newEntity.NextEntityAddress = prevEntity.NextEntityAddress;
                    prevEntity.NextEntityAddress = size; // Address where would be located the new entity.
                    
                    f.WriteEntity(prevEntity);
                } else {
                    f.SetHeader(newEntity.FileAddress);
                }

                // Write new entity in file and reload grid view
                f.WriteEntity(newEntity);
                ReloadEntitiesGridView();
            }
        }
    }
}
