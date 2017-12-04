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
        Entry entry;
        Boolean isNew;

        public FormCreateEntry(CreateEntryListener listener, String entityName, List<Attribute> attributes)
        {
            Init();
            isNew = true;
            Text = "Create entry for " + entityName;
            this.listener = listener;
            this.attributes = attributes.Where(a => a.EntityName == entityName).ToList();

            // Add headers
            foreach(var attr in this.attributes)
                gridViewAttrs.Columns.Add(attr.Name, attr.Name);

            foreach (DataGridViewColumn c in gridViewAttrs.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Add item to edit
            gridViewAttrs.Rows.Add();
        }

        /**
         * Constructor for modify the given entry
         */
        public FormCreateEntry(CreateEntryListener listener, Entry entry, Entity entity, List<Attribute> attributes)
        {
            Init();
            isNew = false;
            Text = "Modify entry " + entry.PrimaryValue + " of " + entity.Name.Trim();
            btnCreate.Text = "Modify";
            this.listener = listener;
            this.attributes = attributes.Where(a => a.EntityName == entity.Name.Trim()).ToList();
            this.entry = entry;

            // Add headers
            foreach (var attr in this.attributes)
                gridViewAttrs.Columns.Add(attr.Name, attr.Name);

            foreach (DataGridViewColumn c in gridViewAttrs.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Add item to edit without fileAddress and NextEntryAddress
            gridViewAttrs.Rows.Add(entry.Data.Where((val, idx) => idx != 0 && idx != entry.Data.Length - 1).ToArray());
        }

        public void Init()
        {
            InitializeComponent();
            CenterToScreen();

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Orange400, TextShade.WHITE);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Boolean valid = true;

            if (entry == null)
                entry = new Entry(attributes.Count());

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
                else if (attributes[i].IndexTypeV == Attribute.IndexType.foreignKey)
                    entry.ForeignValue = cell.Value.ToString();
                else if (attributes[i].IndexTypeV == Attribute.IndexType.bPlusTree)
                    entry.BPlusValue = cell.Value.ToString();

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

            /*if (entry.PrimaryValue == null)
            {
                MessageBox.Show("Every entry needs a primary key");
                valid = false;
            }*/
            if (entry.PrimaryValue == null)
                entry.PrimaryValue = entry.GetHashCode().ToString();

            if(valid)
            {
                listener.OnCreateEntry(entry, isNew);
                Close();
            }
        }
    }

    public interface CreateEntryListener
    {
        void OnCreateEntry(Entry entry, bool isNew);
    }
}
