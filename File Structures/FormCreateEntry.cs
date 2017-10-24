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
    public partial class FormCreateEntry : MaterialForm
    {
        List<Attribute> attributes;
        CreateEntryListener listener;

        public FormCreateEntry(CreateEntryListener listener, String entityName, List<Attribute> attributes)
        {
            InitializeComponent();
            CenterToScreen();
            Text = "Create entry for " + entityName;
            this.listener = listener;
            this.attributes = attributes.Where(a => a.EntityName == entityName).ToList();

            // Add headers
            foreach(var attr in this.attributes)
            {
                gridViewAttrs.Columns.Add(attr.Name, attr.Name);
            }

            foreach (DataGridViewColumn c in gridViewAttrs.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Add item to edit
            gridViewAttrs.Rows.Add();

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Orange400, TextShade.WHITE);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry(attributes.Count());
            Boolean valid = true;

            int i = 0;
            foreach(DataGridViewTextBoxCell cell in gridViewAttrs.Rows[0].Cells)
            {
                if (cell.Value == null || cell.Value.ToString() == String.Empty)
                {
                    MessageBox.Show("All fields are required");
                    valid = false;
                    break;
                }

                if(attributes[i].IndexTypeV == Attribute.IndexType.primaryKey)
                    entry.PrimaryValue = cell.Value.ToString();
                else if (attributes[i].IndexTypeV == Attribute.IndexType.searchKey)
                    entry.SearchValue = cell.Value.ToString();

                if (attributes[i].Type == 'S')
                    entry.Data[i+1] = cell.Value.ToString();
                else
                {
                    int num = 0;
                    if(Int32.TryParse(cell.Value.ToString(), out num))
                        entry.Data[i+1] = num;
                    else
                    {
                        MessageBox.Show(attributes[i].Name + " must be integer");
                        valid = false;
                    }
                }
                i++;
            }

            if(valid)
            {
                entry.FileAddress = -1;
                entry.NextEntryAddress = -1;
                listener.OnCreateEntry(entry);
            }
        }
    }

    public interface CreateEntryListener
    {
        void OnCreateEntry(Entry entry);
    }
}
