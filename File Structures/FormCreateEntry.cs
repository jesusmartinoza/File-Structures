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
        CreateEntryListener listener;
        Entry entry;
        Entity parent;

        public FormCreateEntry(CreateEntryListener listener, Entity entity)
        {
            Init();
            Text = "Create entry for " + entity.Name;
            this.listener = listener;
            this.parent = entity;

            // Add headers
            foreach(var attr in entity.Attributes)
                gridViewAttrs.Columns.Add(attr.Key, attr.Value.Name);

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
            Text = "Modify entry " + entry.PrimaryValue + " of " + entity.Name.Trim();
            btnCreate.Text = "Modify";
            this.listener = listener;
            this.entry = new Entry(entry);

            // Add headers
            foreach (var attr in entity.Attributes)
                gridViewAttrs.Columns.Add(attr.Key, attr.Value.Name);

            foreach (DataGridViewColumn c in gridViewAttrs.Columns)
                c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Add item to edit without fileAddress and NextEntryAddress
            gridViewAttrs.Rows.Add(entry.Data.Where((val, idx) => idx != 0).ToArray());
        }

        public void Init()
        {
            InitializeComponent();
            CenterToScreen();

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Pink400, TextShade.BLACK);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Boolean valid = true;
            entry = new Entry();

            entry.EntityName = parent.Name;

            int i = 0;
            foreach(DataGridViewTextBoxCell cell in gridViewAttrs.Rows[0].Cells)
            {
                var attribute = parent.Attributes.ElementAt(i).Value;

                if (cell.Value == null || cell.Value.ToString() == String.Empty)
                {
                    MessageBox.Show("All fields are required");
                    valid = false;
                    break;
                }

                if(attribute.IndexTypeV == Attribute.IndexType.primaryKey)
                    entry.PrimaryValue = cell.Value.ToString();
                else if (attribute.IndexTypeV == Attribute.IndexType.foreignKey)
                {
                    // If foreign key validate that pk really exists
                    var entriesList = MainForm.file
                        .GetEntriesFrom(attribute.ForeignName)
                        .Where(entry => entry.PrimaryValue == cell.Value.ToString());

                    if(entriesList.Count() == 0)
                    {
                        MessageBox.Show("No entry with Id " + cell.Value.ToString() + " found in Entity " +  attribute.ForeignName);
                        valid = false;
                        break;
                    }

                    entry.ForeignValue = cell.Value.ToString();
                }

                entry.Data.Add(parent.Attributes.ElementAt(i).Key, cell.Value.ToString());

                i++;
            }

            if (entry.PrimaryValue == null)
            {
                entry.PrimaryValue = "";

                foreach (DataGridViewTextBoxCell cell in gridViewAttrs.Rows[0].Cells)
                    entry.PrimaryValue += cell.Value.ToString().Trim();
            }

            if(valid)
            {
                listener.OnCreateEntry(entry);
                entry = null;

                foreach (DataGridViewTextBoxCell cell in gridViewAttrs.Rows[0].Cells)
                    cell.Value = "";
            }
        }
    }

    public interface CreateEntryListener
    {
        void OnCreateEntry(Entry entry);
    }
}
