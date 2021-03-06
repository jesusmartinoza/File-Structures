﻿using System;
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
    public partial class FormCreateEntity : MaterialForm
    {
        CreateEntityListener listener;

        public FormCreateEntity(CreateEntityListener listener)
        {
            this.listener = listener;

            InitializeComponent();
            CenterToScreen();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Cyan800, Primary.Cyan900, Primary.Cyan500, Accent.Orange400, TextShade.WHITE);
        }

        /**
         * If name is not empty trigger OnCreateEntity method.
         * */
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(textFieldName.Text != String.Empty) {
                listener.OnCreateEntity(textFieldName.Text);
            }
        }
    }

    public interface CreateEntityListener
    {
        void OnCreateEntity(string name);
    }
}
