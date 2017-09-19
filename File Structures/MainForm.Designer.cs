namespace File_Structures
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewEntities = new System.Windows.Forms.DataGridView();
            this.btnAddEntity = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddAttr = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridViewAttrs = new System.Windows.Forms.DataGridView();
            this.btnSaveFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOpenFile = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttrs)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEntities
            // 
            this.dataGridViewEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntities.Location = new System.Drawing.Point(17, 11);
            this.dataGridViewEntities.Name = "dataGridViewEntities";
            this.dataGridViewEntities.Size = new System.Drawing.Size(785, 343);
            this.dataGridViewEntities.TabIndex = 0;
            this.dataGridViewEntities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // btnAddEntity
            // 
            this.btnAddEntity.AutoSize = true;
            this.btnAddEntity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddEntity.Depth = 0;
            this.btnAddEntity.Icon = null;
            this.btnAddEntity.Location = new System.Drawing.Point(755, 367);
            this.btnAddEntity.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddEntity.Name = "btnAddEntity";
            this.btnAddEntity.Primary = true;
            this.btnAddEntity.Size = new System.Drawing.Size(48, 36);
            this.btnAddEntity.TabIndex = 2;
            this.btnAddEntity.Text = "Add";
            this.btnAddEntity.UseVisualStyleBackColor = true;
            this.btnAddEntity.Click += new System.EventHandler(this.BtnAddEntity_Click);
            // 
            // tabSelector
            // 
            this.tabSelector.BaseTabControl = this.tabControl;
            this.tabSelector.Depth = 0;
            this.tabSelector.Location = new System.Drawing.Point(-1, 64);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(820, 46);
            this.tabSelector.TabIndex = 3;
            this.tabSelector.Text = "materialTabSelector1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Depth = 0;
            this.tabControl.Location = new System.Drawing.Point(-1, 116);
            this.tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(820, 415);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewEntities);
            this.tabPage1.Controls.Add(this.btnAddEntity);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(812, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Entities";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddAttr);
            this.tabPage2.Controls.Add(this.dataGridViewAttrs);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(812, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Attributes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddAttr
            // 
            this.btnAddAttr.AutoSize = true;
            this.btnAddAttr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddAttr.Depth = 0;
            this.btnAddAttr.Icon = null;
            this.btnAddAttr.Location = new System.Drawing.Point(755, 367);
            this.btnAddAttr.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddAttr.Name = "btnAddAttr";
            this.btnAddAttr.Primary = true;
            this.btnAddAttr.Size = new System.Drawing.Size(48, 36);
            this.btnAddAttr.TabIndex = 3;
            this.btnAddAttr.Text = "Add";
            this.btnAddAttr.UseVisualStyleBackColor = true;
            this.btnAddAttr.Click += new System.EventHandler(this.BtnAddAttr_Click);
            // 
            // dataGridViewAttrs
            // 
            this.dataGridViewAttrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttrs.Location = new System.Drawing.Point(17, 11);
            this.dataGridViewAttrs.Name = "dataGridViewAttrs";
            this.dataGridViewAttrs.Size = new System.Drawing.Size(785, 343);
            this.dataGridViewAttrs.TabIndex = 1;
            this.dataGridViewAttrs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttrs_CellContentClick);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.AutoSize = true;
            this.btnSaveFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveFile.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSaveFile.Depth = 0;
            this.btnSaveFile.Icon = null;
            this.btnSaveFile.Location = new System.Drawing.Point(678, 34);
            this.btnSaveFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Primary = true;
            this.btnSaveFile.Size = new System.Drawing.Size(117, 36);
            this.btnSaveFile.TabIndex = 5;
            this.btnSaveFile.Text = "Save File As...";
            this.btnSaveFile.UseVisualStyleBackColor = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AutoSize = true;
            this.btnOpenFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOpenFile.Depth = 0;
            this.btnOpenFile.Icon = null;
            this.btnOpenFile.Location = new System.Drawing.Point(615, 34);
            this.btnOpenFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Primary = true;
            this.btnOpenFile.Size = new System.Drawing.Size(57, 36);
            this.btnOpenFile.TabIndex = 6;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 532);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSaveFile);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tabSelector);
            this.Name = "MainForm";
            this.Text = "Entities";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttrs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEntities;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddEntity;
        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private MaterialSkin.Controls.MaterialTabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddAttr;
        private System.Windows.Forms.DataGridView dataGridViewAttrs;
        private MaterialSkin.Controls.MaterialRaisedButton btnSaveFile;
        private MaterialSkin.Controls.MaterialRaisedButton btnOpenFile;
    }
}

