﻿namespace File_Structures
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridViewEntities = new System.Windows.Forms.DataGridView();
            this.btnAddEntity = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.emptyState = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddAttr = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridViewAttrs = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listViewEntries = new MaterialSkin.Controls.MaterialListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewEntities = new MaterialSkin.Controls.MaterialListView();
            this.Entity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddEntry = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBoxTree = new System.Windows.Forms.PictureBox();
            this.textBoxTreeLog = new System.Windows.Forms.TextBox();
            this.listViewIndexRep = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewIndexAttr = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSaveFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnOpenFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuEntry = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconEye = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptyState)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttrs)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTree)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconEye)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEntities
            // 
            this.dataGridViewEntities.AllowUserToAddRows = false;
            this.dataGridViewEntities.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewEntities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntities.Location = new System.Drawing.Point(17, 11);
            this.dataGridViewEntities.Name = "dataGridViewEntities";
            this.dataGridViewEntities.RowHeadersVisible = false;
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
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Depth = 0;
            this.tabControl.Location = new System.Drawing.Point(-1, 116);
            this.tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(820, 415);
            this.tabControl.TabIndex = 4;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.emptyState);
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
            // emptyState
            // 
            this.emptyState.ImageLocation = "C:\\Users\\hongo\\Documents\\File-Structures\\File Structures\\empty_state.png";
            this.emptyState.Location = new System.Drawing.Point(127, 32);
            this.emptyState.Name = "emptyState";
            this.emptyState.Size = new System.Drawing.Size(610, 252);
            this.emptyState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.emptyState.TabIndex = 3;
            this.emptyState.TabStop = false;
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
            this.dataGridViewAttrs.AllowUserToAddRows = false;
            this.dataGridViewAttrs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewAttrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAttrs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttrs.Location = new System.Drawing.Point(17, 11);
            this.dataGridViewAttrs.Name = "dataGridViewAttrs";
            this.dataGridViewAttrs.RowHeadersVisible = false;
            this.dataGridViewAttrs.Size = new System.Drawing.Size(785, 343);
            this.dataGridViewAttrs.TabIndex = 1;
            this.dataGridViewAttrs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAttrs_CellContentClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.btnAddEntry);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(812, 389);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Entries";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listViewEntries);
            this.groupBox4.Location = new System.Drawing.Point(151, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(652, 358);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Entries";
            // 
            // listViewEntries
            // 
            this.listViewEntries.AllowColumnReorder = true;
            this.listViewEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewEntries.Depth = 0;
            this.listViewEntries.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewEntries.FullRowSelect = true;
            this.listViewEntries.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewEntries.Location = new System.Drawing.Point(5, 14);
            this.listViewEntries.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewEntries.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewEntries.Name = "listViewEntries";
            this.listViewEntries.OwnerDraw = true;
            this.listViewEntries.Size = new System.Drawing.Size(640, 338);
            this.listViewEntries.TabIndex = 1;
            this.listViewEntries.UseCompatibleStateImageBehavior = false;
            this.listViewEntries.View = System.Windows.Forms.View.Details;
            this.listViewEntries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewEntries_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewEntities);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 358);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select entity";
            // 
            // listViewEntities
            // 
            this.listViewEntities.BackColor = System.Drawing.SystemColors.Menu;
            this.listViewEntities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Entity});
            this.listViewEntities.Depth = 0;
            this.listViewEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewEntities.FullRowSelect = true;
            this.listViewEntities.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewEntities.Location = new System.Drawing.Point(6, 17);
            this.listViewEntities.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewEntities.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewEntities.Name = "listViewEntities";
            this.listViewEntities.OwnerDraw = true;
            this.listViewEntities.Size = new System.Drawing.Size(113, 335);
            this.listViewEntities.TabIndex = 0;
            this.listViewEntities.UseCompatibleStateImageBehavior = false;
            this.listViewEntities.View = System.Windows.Forms.View.Details;
            this.listViewEntities.SelectedIndexChanged += new System.EventHandler(this.listViewEntities_SelectedIndexChanged);
            // 
            // Entity
            // 
            this.Entity.Tag = "Entity";
            this.Entity.Text = "";
            this.Entity.Width = 110;
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.AutoSize = true;
            this.btnAddEntry.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddEntry.Depth = 0;
            this.btnAddEntry.Icon = null;
            this.btnAddEntry.Location = new System.Drawing.Point(755, 367);
            this.btnAddEntry.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Primary = true;
            this.btnAddEntry.Size = new System.Drawing.Size(48, 36);
            this.btnAddEntry.TabIndex = 3;
            this.btnAddEntry.Text = "Add";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(812, 389);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Index";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.iconEye);
            this.groupBox3.Controls.Add(this.pictureBoxTree);
            this.groupBox3.Controls.Add(this.textBoxTreeLog);
            this.groupBox3.Controls.Add(this.listViewIndexRep);
            this.groupBox3.Location = new System.Drawing.Point(151, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(652, 369);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Index representation";
            // 
            // pictureBoxTree
            // 
            this.pictureBoxTree.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxTree.Name = "pictureBoxTree";
            this.pictureBoxTree.Size = new System.Drawing.Size(640, 182);
            this.pictureBoxTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTree.TabIndex = 2;
            this.pictureBoxTree.TabStop = false;
            this.pictureBoxTree.Visible = false;
            // 
            // textBoxTreeLog
            // 
            this.textBoxTreeLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxTreeLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTreeLog.Location = new System.Drawing.Point(6, 207);
            this.textBoxTreeLog.Multiline = true;
            this.textBoxTreeLog.Name = "textBoxTreeLog";
            this.textBoxTreeLog.ReadOnly = true;
            this.textBoxTreeLog.Size = new System.Drawing.Size(635, 154);
            this.textBoxTreeLog.TabIndex = 1;
            this.textBoxTreeLog.Visible = false;
            // 
            // listViewIndexRep
            // 
            this.listViewIndexRep.BackColor = System.Drawing.SystemColors.Menu;
            this.listViewIndexRep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewIndexRep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.listViewIndexRep.Depth = 0;
            this.listViewIndexRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewIndexRep.FullRowSelect = true;
            this.listViewIndexRep.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewIndexRep.Location = new System.Drawing.Point(6, 17);
            this.listViewIndexRep.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewIndexRep.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewIndexRep.Name = "listViewIndexRep";
            this.listViewIndexRep.OwnerDraw = true;
            this.listViewIndexRep.Size = new System.Drawing.Size(640, 344);
            this.listViewIndexRep.TabIndex = 0;
            this.listViewIndexRep.UseCompatibleStateImageBehavior = false;
            this.listViewIndexRep.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "Entity";
            this.columnHeader2.Text = "VALUE";
            this.columnHeader2.Width = 106;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ADDRESS";
            this.columnHeader3.Width = 530;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewIndexAttr);
            this.groupBox2.Location = new System.Drawing.Point(9, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 369);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select attribute";
            // 
            // listViewIndexAttr
            // 
            this.listViewIndexAttr.BackColor = System.Drawing.SystemColors.Menu;
            this.listViewIndexAttr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewIndexAttr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewIndexAttr.Depth = 0;
            this.listViewIndexAttr.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listViewIndexAttr.FullRowSelect = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listViewIndexAttr.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listViewIndexAttr.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewIndexAttr.Location = new System.Drawing.Point(6, 17);
            this.listViewIndexAttr.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listViewIndexAttr.MouseState = MaterialSkin.MouseState.OUT;
            this.listViewIndexAttr.Name = "listViewIndexAttr";
            this.listViewIndexAttr.OwnerDraw = true;
            this.listViewIndexAttr.Size = new System.Drawing.Size(113, 344);
            this.listViewIndexAttr.TabIndex = 0;
            this.listViewIndexAttr.UseCompatibleStateImageBehavior = false;
            this.listViewIndexAttr.View = System.Windows.Forms.View.Details;
            this.listViewIndexAttr.SelectedIndexChanged += new System.EventHandler(this.listViewIndexAttr_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "Entity";
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 110;
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
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
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
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Data dictionary | *.dic";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Data dictionary | *.dic";
            // 
            // contextMenuEntry
            // 
            this.contextMenuEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuEntry.Name = "contextMenuEntry";
            this.contextMenuEntry.Size = new System.Drawing.Size(108, 48);
            this.contextMenuEntry.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuEntry_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "Edit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem2.Text = "Delete";
            // 
            // iconEye
            // 
            this.iconEye.ImageLocation = "C:\\Users\\hongo\\Documents\\File-Structures\\File Structures\\ic_eye.png";
            this.iconEye.InitialImage = null;
            this.iconEye.Location = new System.Drawing.Point(592, 19);
            this.iconEye.Name = "iconEye";
            this.iconEye.Size = new System.Drawing.Size(49, 44);
            this.iconEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconEye.TabIndex = 3;
            this.iconEye.TabStop = false;
            this.iconEye.Click += new System.EventHandler(this.iconEye_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "File Structures";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntities)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emptyState)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttrs)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTree)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuEntry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconEye)).EndInit();
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
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialListView listViewEntities;
        private MaterialSkin.Controls.MaterialListView listViewEntries;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddEntry;
        private System.Windows.Forms.ColumnHeader Entity;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialListView listViewIndexAttr;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialListView listViewIndexRep;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ContextMenuStrip contextMenuEntry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TextBox textBoxTreeLog;
        private System.Windows.Forms.PictureBox pictureBoxTree;
        private System.Windows.Forms.PictureBox emptyState;
        private System.Windows.Forms.PictureBox iconEye;
    }
}

