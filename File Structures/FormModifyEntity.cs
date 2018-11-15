using System;
using MaterialSkin;
using MaterialSkin.Controls;

namespace File_Structures
{
    public partial class FormModifyEntity : MaterialForm
    {
        Entity entity;
        ModifyEntityListener listener;

        public FormModifyEntity(ModifyEntityListener listener, Entity entity)
        {
            this.entity = entity;
            this.listener = listener;
            InitializeComponent();
            CenterToScreen();

            textFieldName.Text = entity.Name.Trim();

            // Config material skin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Yellow800, Primary.Yellow900, Primary.Yellow500, Accent.Pink400, TextShade.BLACK);
        }

        /**
         * If name is not empty trigger OnModifyEntity method.
         * */
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (textFieldName.Text != String.Empty)
            {
                entity.Name = textFieldName.Text;
                listener.OnModifyEntity(entity);
                Close();
            }
        }
    }

    public interface ModifyEntityListener
    {
        void OnModifyEntity(Entity name);
    }
}
