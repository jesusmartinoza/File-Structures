using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Structures
{
    public partial class FormEntities : Form
    {
        public FormEntities()
        {
            InitializeComponent();
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            string[] columns = { "Name", "Address", "Attributes Address", "Data Address", "Next Entity Address" };

            dataGridView.ColumnCount = columns.Length;

            // Add headers
            for (int i = 0; i < columns.Length; i++)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[i].Name = columns[i];
            }

            // Add and confif delete cell button
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Width = 25;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.DefaultCellStyle.ForeColor = Color.White;
            btnDelete.DefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#D91E18");
            btnDelete.Text = "X";
            btnDelete.Name = "delete";
            btnDelete.UseColumnTextForButtonValue = true;

            dataGridView.Columns.Add(btnDelete);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If clicked on delete cell button
            if (e.ColumnIndex == 5)
            {
                MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
        }
    }
}
