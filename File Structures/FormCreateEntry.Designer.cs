namespace File_Structures
{
    partial class FormCreateEntry
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
            this.gridViewAttrs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttrs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.AutoSize = true;
            this.btnCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCreate.Depth = 0;
            this.btnCreate.Icon = null;
            this.btnCreate.Location = new System.Drawing.Point(292, 126);
            this.btnCreate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Primary = true;
            this.btnCreate.Size = new System.Drawing.Size(71, 36);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // gridViewAttrs
            // 
            this.gridViewAttrs.AllowUserToAddRows = false;
            this.gridViewAttrs.AllowUserToDeleteRows = false;
            this.gridViewAttrs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridViewAttrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridViewAttrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewAttrs.Location = new System.Drawing.Point(12, 76);
            this.gridViewAttrs.Name = "gridViewAttrs";
            this.gridViewAttrs.RowHeadersVisible = false;
            this.gridViewAttrs.Size = new System.Drawing.Size(351, 47);
            this.gridViewAttrs.TabIndex = 1;
            // 
            // FormCreateEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 172);
            this.Controls.Add(this.gridViewAttrs);
            this.Controls.Add(this.btnCreate);
            this.Name = "FormCreateEntry";
            this.Text = "Create Entry";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttrs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnCreate;
        private System.Windows.Forms.DataGridView gridViewAttrs;
    }
}