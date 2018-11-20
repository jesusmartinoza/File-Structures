using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Antlr4.Runtime;
using MaterialSkin;
using MaterialSkin.Controls;

namespace File_Structures
{
    public partial class MainForm : MaterialForm, CreateEntityListener, CreateAttributeListener, CreateEntryListener,
        ModifyEntityListener, ModifyAttributeListener
    {
        Entity selectedEntity;
        Entry selectedEntry;
        public static File file;
        
        public static Dictionary<string, Entity> relations;

        /**
         * Initialize components and MaterialForm
         * */
        public MainForm()
        {
            file = new File();
            relations = new Dictionary<string, Entity>();

            string[] entityHeaders = { "Name"};
            string[] attrHeaders = {"Entity", "Name", "Type", "Length", "Index Type"};

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
         * Clear Rows of dataGridViewEntities and fill with entities list.
         * */
        private void ReloadEntitiesGridView()
        {
            dataGridViewEntities.Rows.Clear();
            listViewEntities.Items.Clear();

            foreach (KeyValuePair<string, Entity> kvp in file.Entities) {
                Entity e = kvp.Value;
                dataGridViewEntities.Rows.Add(kvp.Key);
                listViewEntities.Items.Add(kvp.Key);
            }
        }

        /**
         * Clear Rows of listViewEntries and fill with entries dictionary.
         * */
        private void ReloadEntriesList(List<Attribute> attrs)
        {
            listViewEntries.Clear();

            if (attrs == null)
                attrs = selectedEntity.Attributes.Values.ToList();

            foreach (var attr in attrs)
            {
                listViewEntries.Columns.Add(attr.Name, attr.Length * 4 + attr.Name.Length * 4);
            }

            foreach (Entry e in selectedEntity.Entries.Values.OrderBy(e => e.SearchValue))
            {
                var list = e.Data.Values.ToList();
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

            foreach (var a in file.GetAttributes())
                dataGridViewAttrs.Rows.Add(a.EntityName.Trim(), a.Name.Trim(), a.Type, a.Length, a.IndexTypeV);
        }

        /************************************************************************
         *                I  N  T  E  R  F  A  C  E  S                          *
         ************************************************************************/
        public void OnCreateEntity(string name)
        {
            if (file.AddEntity(name)) {
                ReloadEntitiesGridView();
                emptyState.Visible = false;
            } else {
                MessageBox.Show(name + " already exists in file.");
            }
        }

        public void OnCreateAttribute(Attribute attr)
        {
            if (file.AddAttribute(attr)) {
                ReloadAttrsGridView();
            } else {
                MessageBox.Show(attr.Name + " already exists in file.");
            }
        }

        /**
         * Verify if primary key already exists.
         * Add Entry to entries list and write in file.
         */
        public void OnCreateEntry(Entry entry)
        {
            if(file.AddEntry(entry))
            {
                ReloadEntriesList(null);
            } else
            {
                MessageBox.Show("An entry with value " + entry.PrimaryValue + " already exists in file.");
            }
        }

        public void OnModifyAttribute(Attribute attribute)
        {
            ReloadAttrsGridView();
        }

        public void OnModifyEntity(Entity entity)
        {
            /*if(!entities.ContainsKey(entity.Name.Trim())) {
                ReloadEntitiesGridView();
                ReloadAttrsGridView();
            } else {
                MessageBox.Show(entity.Name + " already exists in file.");
            }*/
        }

        /************************************************************************
         *                          E  V  E  N  T  S                            *
         ************************************************************************/
        /**
        * Show dialog to create entity.
        * */
        private void BtnAddEntity_Click(object sender, EventArgs e)
        {
            if (file == null) {
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
            if(file == null)
                btnSaveFile.PerformClick();
            else if (file.Entities.Count == 0)
                MessageBox.Show("Please create some entity :)");
            else {
                FormCreateAttribute f = new FormCreateAttribute(this, file.Entities);
                f.ShowDialog(this);
            }
        }

        /**
         * Show dialog to create entry.
         * */
        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (file == null)
                btnSaveFile.PerformClick();
            else if (file.Entities.Count == 0)
                MessageBox.Show("Please create some entity with attributes :)");
            else if (selectedEntity == null)
                MessageBox.Show("Select entity");
            else
            {
                FormCreateEntry f = new FormCreateEntry(this, selectedEntity);
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
                var entity = file.Entities.ElementAt(e.RowIndex);

                switch (e.ColumnIndex)
                {
                    case 1: // Edit button
                        FormModifyEntity formModifyEntity = new FormModifyEntity(this, entity.Value);
                        formModifyEntity.Show(this);
                        break;
                    case 2: // Delete button
                        //DeleteEntity(entity.Value);
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
                var attr = file.GetAttributes().ElementAt(e.RowIndex);

                if (true)//entities.First(ent => ent.Key == attr.EntityName).Value.DataAddress != -1)
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
                            //DeleteAttribute(attr);
                            break;
                    }
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(openFileDialog.FileName);
                string filename = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

                file.Name = filename;
                file.Open(path);

                ReloadEntitiesGridView();
                ReloadAttrsGridView();
                emptyState.Visible = false;
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string path = Path.GetDirectoryName(saveFileDialog.FileName);
                string filename = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);

                file.Name = filename;
                file.Save(path);
                emptyState.Visible = false;
            }
        }

        /**
         * Change attributes list using selected entity.
         */
        private void listViewEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = (MaterialListView)sender;
            selectedEntity = file.Entities.First(enti => enti.Key.Equals(list.FocusedItem.Text)).Value;

            listViewEntries.Clear();
            inputTextQuery.Text = "SELECT * FROM " + list.FocusedItem.Text;

            ReloadEntriesList(null);
        }

        private void listViewEntries_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = listViewEntries.FocusedItem;
                if (item.Bounds.Contains(e.Location))
                {
                    //selectedEntry = entries.First(entry => entry.Key.Equals(item.Name)).Value;
                    contextMenuEntry.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuEntry_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "Edit":
                    FormCreateEntry f = new FormCreateEntry(this, selectedEntry, selectedEntity, file.GetAttributes());
                    f.ShowDialog(this);
                    break;
                case "Delete": //DeleteEntry(selectedEntry);
                    break;
            }
        }

        private void iconEye_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(pictureBoxTree.ImageLocation);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BDAGrammarLexer lex = new BDAGrammarLexer(new AntlrInputStream(inputTextQuery.Text + Environment.NewLine));
            CommonTokenStream tokens = new CommonTokenStream(lex);
            BDAGrammarParser parser = new BDAGrammarParser(tokens);
            parser.AddErrorListener(new MyErrorListener());
            bool success = true;

            try
            {
                parser.query();
            }
            catch (Exception error)
            {
                if (!error.Message.Contains("input ' '"))
                {
                    MessageBox.Show(error.Message);
                    success = false;
                }
            }

            String msg = "";
            foreach (var t in tokens.GetTokens())
            {
                String tokenType = parser.Vocabulary.GetDisplayName(t.Type);
                
                switch(tokenType)
                {
                    case "ATTRS":
                        msg += "Nombre atributos: " + t.Text;
                        break;
                    case "ID":
                        msg += "Nombre tabla: " + t.Text;
                        break;
                }
            }

            if(success)
                MessageBox.Show(msg);
        }
    }
}
