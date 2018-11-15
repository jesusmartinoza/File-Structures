using System;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace File_Structures
{
    public partial class FormModifyAttribute : MaterialForm
    {
        ModifyAttributeListener listener;
        Attribute attribute;

        public FormModifyAttribute(Attribute attribute, ModifyAttributeListener listener)
        {
            this.listener = listener;
            this.attribute = attribute;
            InitializeComponent();
            CenterToScreen();

            textFieldName.Text = attribute.Name;
            comboBoxType.SelectedItem = attribute.Type;
            comboBoxType.SelectedItem = attribute.IndexTypeV;

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Pink400, TextShade.BLACK);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            var type = comboBoxType.GetItemText(comboBoxType.SelectedItem) == "String" ? 'S' : 'I';
            var length = Convert.ToInt32(textFieldLength.Text);
            var indexType = (Attribute.IndexType)comboBoxIndex.SelectedIndex;

            if (textFieldName.Text == String.Empty)
                MessageBox.Show("Name is required");
            else if (length <= 0)
                MessageBox.Show("Positive length is required");
            else {
                attribute.Name = textFieldName.Text;
                attribute.IndexTypeV = indexType;
                attribute.Type = type;

                listener.OnModifyAttribute(attribute);
                Close();
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxType.SelectedIndex == 0)
                textFieldLength.Text = "8";
            else
                textFieldLength.Text = "30";
        }
    }

    public interface ModifyAttributeListener
    {
        void OnModifyAttribute(Attribute attribute);
    }
}
