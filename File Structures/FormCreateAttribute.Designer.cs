namespace File_Structures
{
    partial class FormCreateAttribute
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreate = new MaterialSkin.Controls.MaterialRaisedButton();
            this.textFieldName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textFieldLength = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.labelType = new MaterialSkin.Controls.MaterialLabel();
            this.labelIndex = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxIndex = new System.Windows.Forms.ComboBox();
            this.labelName = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.AutoSize = true;
            this.btnCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreate.Depth = 0;
            this.btnCreate.Icon = null;
            this.btnCreate.Location = new System.Drawing.Point(219, 193);
            this.btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Primary = true;
            this.btnCreate.Size = new System.Drawing.Size(71, 36);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // textFieldName
            // 
            this.textFieldName.Depth = 0;
            this.textFieldName.Hint = "";
            this.textFieldName.Location = new System.Drawing.Point(70, 76);
            this.textFieldName.MaxLength = 32767;
            this.textFieldName.MouseState = MaterialSkin.MouseState.HOVER;
            this.textFieldName.Name = "textFieldName";
            this.textFieldName.PasswordChar = '\0';
            this.textFieldName.SelectedText = "";
            this.textFieldName.SelectionLength = 0;
            this.textFieldName.SelectionStart = 0;
            this.textFieldName.Size = new System.Drawing.Size(220, 23);
            this.textFieldName.TabIndex = 1;
            this.textFieldName.TabStop = false;
            this.textFieldName.UseSystemPasswordChar = false;
            // 
            // textFieldLength
            // 
            this.textFieldLength.Depth = 0;
            this.textFieldLength.Hint = "";
            this.textFieldLength.Location = new System.Drawing.Point(70, 115);
            this.textFieldLength.MaxLength = 32767;
            this.textFieldLength.MouseState = MaterialSkin.MouseState.HOVER;
            this.textFieldLength.Name = "textFieldLength";
            this.textFieldLength.PasswordChar = '\0';
            this.textFieldLength.SelectedText = "";
            this.textFieldLength.SelectionLength = 0;
            this.textFieldLength.SelectionStart = 0;
            this.textFieldLength.Size = new System.Drawing.Size(219, 23);
            this.textFieldLength.TabIndex = 2;
            this.textFieldLength.TabStop = false;
            this.textFieldLength.UseSystemPasswordChar = false;
            this.textFieldLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFieldLength_KeyPress);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Depth = 0;
            this.labelType.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelType.Location = new System.Drawing.Point(11, 153);
            this.labelType.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(41, 19);
            this.labelType.TabIndex = 3;
            this.labelType.Text = "Type";
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Depth = 0;
            this.labelIndex.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelIndex.Location = new System.Drawing.Point(153, 153);
            this.labelIndex.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(44, 19);
            this.labelIndex.TabIndex = 4;
            this.labelIndex.Text = "Index";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Integer",
            "String"});
            this.comboBoxType.Location = new System.Drawing.Point(58, 153);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(89, 21);
            this.comboBoxType.TabIndex = 5;
            // 
            // comboBoxIndex
            // 
            this.comboBoxIndex.FormattingEnabled = true;
            this.comboBoxIndex.Items.AddRange(new object[] {
            "No type",
            "Search key",
            "Primary key",
            "Foreign key",
            "B+ Tree",
            "Dynamic Hash"});
            this.comboBoxIndex.Location = new System.Drawing.Point(200, 153);
            this.comboBoxIndex.Name = "comboBoxIndex";
            this.comboBoxIndex.Size = new System.Drawing.Size(89, 21);
            this.comboBoxIndex.TabIndex = 6;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Depth = 0;
            this.labelName.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelName.Location = new System.Drawing.Point(10, 78);
            this.labelName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 19);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Name";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(10, 117);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(54, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Length";
            // 
            // FormCreateAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 245);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxIndex);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.textFieldLength);
            this.Controls.Add(this.textFieldName);
            this.Controls.Add(this.btnCreate);
            this.Name = "FormCreateAttribute";
            this.Text = "Create Attribute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnCreate;
        private MaterialSkin.Controls.MaterialSingleLineTextField textFieldName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textFieldLength;
        private MaterialSkin.Controls.MaterialLabel labelType;
        private MaterialSkin.Controls.MaterialLabel labelIndex;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxIndex;
        private MaterialSkin.Controls.MaterialLabel labelName;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}