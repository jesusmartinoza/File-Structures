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
    public partial class MainForm : MaterialForm
    {
        /**
         * Initialuze components and MaterialForm
         * */
        public MainForm()
        {
            InitializeComponent();
            InitDataGridView();

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
            for (int i = 0; i < columns.Length; i++)
            {
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

        private void BtnAddEntity_Click(object sender, EventArgs e)
        {
            FormCreateEntity f = new FormCreateEntity();
            f.ShowDialog(this);
        }

        private void BtnAddAttr_Click(object sender, EventArgs e)
        {
            FormCreateAttribute f = new FormCreateAttribute();
            f.ShowDialog(this);
        }
    }
}
