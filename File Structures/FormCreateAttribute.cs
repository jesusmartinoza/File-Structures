using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace File_Structures
{
    public partial class FormCreateAttribute: MaterialForm
    {
        CreateAttributeListener listener;
        Dictionary<string, Entity> entities;
        Dictionary<string, string> relationsData;

        internal FormCreateAttribute(CreateAttributeListener listener, Dictionary<string, Entity> entities)
        {
            InitializeComponent();
            CenterToScreen();
            this.listener = listener;
            this.entities = entities;

            comboBoxEntity.DataSource = this.entities.ToList();
            comboBoxEntity.SelectedIndex = 0;
            comboBoxEntity.DisplayMember = "key";

            comboBoxType.SelectedIndex = 0;
            comboBoxIndex.SelectedIndex = 0;

            // Get attributes that are primary keys, no LINQ available :c
            relationsData = new Dictionary<string, string>();
            foreach (Attribute attr in MainForm.file.GetAttributes())
            {
                if (attr.IndexTypeV == Attribute.IndexType.primaryKey)
                    relationsData.Add(attr.Name, attr.EntityName + " - " + attr.Name);
            }
            comboBoxRelation.DataSource = relationsData.Values.ToList();

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Pink400, TextShade.BLACK);
        }

        /**
         * Allow only numbers in textFieldLength
         * */
        private void textFieldLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /**
         * If valid data trigger OnCreateAttribute method.
         * TODO: Validate empty length;
         * TODO: Combobox no editable
         * */
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var type = comboBoxType.GetItemText(comboBoxType.SelectedItem) == "String" ? 'S' : 'I';
            var length = Convert.ToInt32(textFieldLength.Text.Length == 0 ? "0" : textFieldLength.Text);
            var indexType = (Attribute.IndexType) comboBoxIndex.SelectedIndex;
            var entity = entities[comboBoxEntity.GetItemText(comboBoxEntity.SelectedItem)];
            if (textFieldName.Text == String.Empty)
                MessageBox.Show("Name is required");
           /*else if (entities.First(ent => ent.Key == entity.Name.Trim()).Value.DataAddress != -1)
                MessageBox.Show(entity.Name.Trim() +  " already has entries. Cannot add new attributes :/");*/
            else if(length <= 0)
                MessageBox.Show("Positive length is required");
            else {
                listener.OnCreateAttribute(new Attribute(textFieldName.Text, type, length, indexType, entity.Name));
            }
        }

        private void comboBoxType_SelectedValueChanged(object sender, EventArgs e)
        {
            // When integer
            if (comboBoxType.SelectedIndex == 0)
                textFieldLength.Text = "8";
            else
                textFieldLength.Text = "30";
        }

        private void comboBoxIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When Foreign key
            if (comboBoxIndex.SelectedIndex == 2)
            {
                lblRelation.ForeColor = System.Drawing.Color.Black;
                comboBoxRelation.Enabled = true;
            } else
            {
                lblRelation.ForeColor = System.Drawing.Color.DarkGray;
                comboBoxRelation.Enabled = false;
            }
        }
    }

    public interface CreateAttributeListener
    {
        void OnCreateAttribute(Attribute attribute);
    }
}
