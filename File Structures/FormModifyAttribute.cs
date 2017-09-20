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

            textFieldName.Text = attribute.Name;
            comboBoxType.SelectedItem = attribute.Type;
            textFieldLength.Text = "" + attribute.Length;
            comboBoxType.SelectedItem = attribute.IndexTypeV;

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Orange400, TextShade.WHITE);
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
                attribute.Length = length;
                attribute.IndexTypeV = indexType;
                attribute.Type = type;

                listener.OnModifyAttribute(attribute);
                Close();
            }
        }
    }

    public interface ModifyAttributeListener
    {
        void OnModifyAttribute(Attribute attribute);
    }
}
