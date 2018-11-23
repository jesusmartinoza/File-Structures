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
            this.lblEntity = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxEntity = new System.Windows.Forms.ComboBox();
            this.comboBoxRelation = new System.Windows.Forms.ComboBox();
            this.lblRelation = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.AutoSize = true;
            this.btnCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreate.Depth = 0;
            this.btnCreate.Icon = null;
            this.btnCreate.Location = new System.Drawing.Point(219, 282);
            this.btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Primary = true;
            this.btnCreate.Size = new System.Drawing.Size(71, 36);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // textFieldName
            // 
            this.textFieldName.Depth = 0;
            this.textFieldName.Hint = "";
            this.textFieldName.Location = new System.Drawing.Point(70, 120);
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
            this.textFieldLength.Location = new System.Drawing.Point(219, 162);
            this.textFieldLength.MaxLength = 32767;
            this.textFieldLength.MouseState = MaterialSkin.MouseState.HOVER;
            this.textFieldLength.Name = "textFieldLength";
            this.textFieldLength.PasswordChar = '\0';
            this.textFieldLength.SelectedText = "";
            this.textFieldLength.SelectionLength = 0;
            this.textFieldLength.SelectionStart = 0;
            this.textFieldLength.Size = new System.Drawing.Size(70, 23);
            this.textFieldLength.TabIndex = 2;
            this.textFieldLength.TabStop = false;
            this.textFieldLength.Text = "8";
            this.textFieldLength.UseSystemPasswordChar = false;
            this.textFieldLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFieldLength_KeyPress);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Depth = 0;
            this.labelType.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelType.Location = new System.Drawing.Point(12, 163);
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
            this.labelIndex.Location = new System.Drawing.Point(12, 202);
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
            this.comboBoxType.Location = new System.Drawing.Point(70, 164);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(83, 21);
            this.comboBoxType.TabIndex = 5;
            this.comboBoxType.SelectedValueChanged += new System.EventHandler(this.comboBoxType_SelectedValueChanged);
            // 
            // comboBoxIndex
            // 
            this.comboBoxIndex.FormattingEnabled = true;
            this.comboBoxIndex.Items.AddRange(new object[] {
            "No type",
            "Primary key",
            "Foreign key"});
            this.comboBoxIndex.Location = new System.Drawing.Point(70, 200);
            this.comboBoxIndex.Name = "comboBoxIndex";
            this.comboBoxIndex.Size = new System.Drawing.Size(83, 21);
            this.comboBoxIndex.TabIndex = 6;
            this.comboBoxIndex.SelectedIndexChanged += new System.EventHandler(this.comboBoxIndex_SelectedIndexChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Depth = 0;
            this.labelName.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelName.Location = new System.Drawing.Point(10, 122);
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
            this.materialLabel1.Location = new System.Drawing.Point(159, 163);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(54, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Length";
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Depth = 0;
            this.lblEntity.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEntity.Location = new System.Drawing.Point(9, 84);
            this.lblEntity.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(47, 19);
            this.lblEntity.TabIndex = 10;
            this.lblEntity.Text = "Entity";
            // 
            // comboBoxEntity
            // 
            this.comboBoxEntity.FormattingEnabled = true;
            this.comboBoxEntity.Items.AddRange(new object[] {
            "Integer",
            "String"});
            this.comboBoxEntity.Location = new System.Drawing.Point(70, 82);
            this.comboBoxEntity.Name = "comboBoxEntity";
            this.comboBoxEntity.Size = new System.Drawing.Size(219, 21);
            this.comboBoxEntity.TabIndex = 11;
            this.comboBoxEntity.SelectedIndexChanged += new System.EventHandler(this.comboBoxEntity_SelectedIndexChanged);
            // 
            // comboBoxRelation
            // 
            this.comboBoxRelation.Enabled = false;
            this.comboBoxRelation.FormattingEnabled = true;
            this.comboBoxRelation.Location = new System.Drawing.Point(84, 237);
            this.comboBoxRelation.Name = "comboBoxRelation";
            this.comboBoxRelation.Size = new System.Drawing.Size(204, 21);
            this.comboBoxRelation.TabIndex = 13;
            // 
            // lblRelation
            // 
            this.lblRelation.AutoSize = true;
            this.lblRelation.Depth = 0;
            this.lblRelation.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblRelation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRelation.Location = new System.Drawing.Point(12, 239);
            this.lblRelation.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(64, 19);
            this.lblRelation.TabIndex = 12;
            this.lblRelation.Text = "Relation";
            // 
            // FormCreateAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 330);
            this.Controls.Add(this.comboBoxRelation);
            this.Controls.Add(this.lblRelation);
            this.Controls.Add(this.comboBoxEntity);
            this.Controls.Add(this.lblEntity);
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
        private MaterialSkin.Controls.MaterialLabel lblEntity;
        private System.Windows.Forms.ComboBox comboBoxEntity;
        private System.Windows.Forms.ComboBox comboBoxRelation;
        private MaterialSkin.Controls.MaterialLabel lblRelation;
    }
}