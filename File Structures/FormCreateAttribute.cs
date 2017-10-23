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
        SortedList<string, Entity> entities;

        internal FormCreateAttribute(CreateAttributeListener listener, SortedList<string, Entity> entities)
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

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Orange400, TextShade.WHITE);
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
            var length = Convert.ToInt32(textFieldLength.Text);
            var indexType = (Attribute.IndexType) comboBoxIndex.SelectedIndex;
            var entity = entities[comboBoxEntity.GetItemText(comboBoxEntity.SelectedItem)];

            if (textFieldName.Text == String.Empty)
                MessageBox.Show("Name is required");
            else if(length <= 0)
                MessageBox.Show("Positive length is required");
            else {
                listener.OnCreateAttribute(new Attribute(textFieldName.Text, type, length, indexType, entity.Name));
            }
        }
    }

    public interface CreateAttributeListener
    {
        void OnCreateAttribute(Attribute attribute);
    }
}
