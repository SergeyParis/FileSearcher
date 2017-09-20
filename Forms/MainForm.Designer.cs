namespace FileSearcher.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblFileName = new System.Windows.Forms.Label();
            this.txbxFileName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlChooseTypeSearching = new System.Windows.Forms.Panel();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.rBtnChooseFolders = new System.Windows.Forms.RadioButton();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.rBtnLogicDrives = new System.Windows.Forms.RadioButton();
            this.pnlChooseFolders = new System.Windows.Forms.Panel();
            this.pnlLogicDrives = new System.Windows.Forms.Panel();
            this.chbxSearchFiles = new System.Windows.Forms.CheckBox();
            this.chbxSearchFolders = new System.Windows.Forms.CheckBox();
            this.pnlChooseTypeSearching.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFileName.Location = new System.Drawing.Point(12, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(74, 15);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "Enter name:";
            // 
            // txbxFileName
            // 
            this.txbxFileName.Location = new System.Drawing.Point(89, 8);
            this.txbxFileName.Name = "txbxFileName";
            this.txbxFileName.Size = new System.Drawing.Size(328, 20);
            this.txbxFileName.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(423, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlChooseTypeSearching
            // 
            this.pnlChooseTypeSearching.AutoScroll = true;
            this.pnlChooseTypeSearching.Controls.Add(this.btnRemoveFolder);
            this.pnlChooseTypeSearching.Controls.Add(this.rBtnChooseFolders);
            this.pnlChooseTypeSearching.Controls.Add(this.btnAddFolder);
            this.pnlChooseTypeSearching.Controls.Add(this.rBtnLogicDrives);
            this.pnlChooseTypeSearching.Controls.Add(this.pnlChooseFolders);
            this.pnlChooseTypeSearching.Controls.Add(this.pnlLogicDrives);
            this.pnlChooseTypeSearching.Location = new System.Drawing.Point(13, 38);
            this.pnlChooseTypeSearching.Name = "pnlChooseTypeSearching";
            this.pnlChooseTypeSearching.Size = new System.Drawing.Size(608, 198);
            this.pnlChooseTypeSearching.TabIndex = 3;
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Location = new System.Drawing.Point(583, 7);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(22, 22);
            this.btnRemoveFolder.TabIndex = 1;
            this.btnRemoveFolder.Text = "-";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
            // 
            // rBtnChooseFolders
            // 
            this.rBtnChooseFolders.AutoSize = true;
            this.rBtnChooseFolders.Location = new System.Drawing.Point(306, 10);
            this.rBtnChooseFolders.Name = "rBtnChooseFolders";
            this.rBtnChooseFolders.Size = new System.Drawing.Size(98, 17);
            this.rBtnChooseFolders.TabIndex = 3;
            this.rBtnChooseFolders.Text = "Choose Folders";
            this.rBtnChooseFolders.UseVisualStyleBackColor = true;
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(562, 7);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(23, 22);
            this.btnAddFolder.TabIndex = 0;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // rBtnLogicDrives
            // 
            this.rBtnLogicDrives.AutoSize = true;
            this.rBtnLogicDrives.Checked = true;
            this.rBtnLogicDrives.Location = new System.Drawing.Point(4, 10);
            this.rBtnLogicDrives.Name = "rBtnLogicDrives";
            this.rBtnLogicDrives.Size = new System.Drawing.Size(84, 17);
            this.rBtnLogicDrives.TabIndex = 2;
            this.rBtnLogicDrives.TabStop = true;
            this.rBtnLogicDrives.Text = "Logic Drives";
            this.rBtnLogicDrives.UseVisualStyleBackColor = true;
            this.rBtnLogicDrives.CheckedChanged += new System.EventHandler(this.rBtnLogicDrives_CheckedChanged);
            // 
            // pnlChooseFolders
            // 
            this.pnlChooseFolders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlChooseFolders.Location = new System.Drawing.Point(306, 33);
            this.pnlChooseFolders.Name = "pnlChooseFolders";
            this.pnlChooseFolders.Size = new System.Drawing.Size(300, 162);
            this.pnlChooseFolders.TabIndex = 1;
            // 
            // pnlLogicDrives
            // 
            this.pnlLogicDrives.AutoScroll = true;
            this.pnlLogicDrives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlLogicDrives.Location = new System.Drawing.Point(2, 33);
            this.pnlLogicDrives.Name = "pnlLogicDrives";
            this.pnlLogicDrives.Size = new System.Drawing.Size(300, 162);
            this.pnlLogicDrives.TabIndex = 0;
            // 
            // chbxSearchFiles
            // 
            this.chbxSearchFiles.AutoSize = true;
            this.chbxSearchFiles.Checked = true;
            this.chbxSearchFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxSearchFiles.Location = new System.Drawing.Point(516, 10);
            this.chbxSearchFiles.Name = "chbxSearchFiles";
            this.chbxSearchFiles.Size = new System.Drawing.Size(47, 17);
            this.chbxSearchFiles.TabIndex = 4;
            this.chbxSearchFiles.Text = "Files";
            this.chbxSearchFiles.UseVisualStyleBackColor = true;
            this.chbxSearchFiles.CheckedChanged += new System.EventHandler(this.chbxSearchFiles_CheckedChanged);
            // 
            // chbxSearchFolders
            // 
            this.chbxSearchFolders.AutoSize = true;
            this.chbxSearchFolders.Checked = true;
            this.chbxSearchFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxSearchFolders.Location = new System.Drawing.Point(568, 10);
            this.chbxSearchFolders.Name = "chbxSearchFolders";
            this.chbxSearchFolders.Size = new System.Drawing.Size(60, 17);
            this.chbxSearchFolders.TabIndex = 5;
            this.chbxSearchFolders.Text = "Folders";
            this.chbxSearchFolders.UseVisualStyleBackColor = true;
            this.chbxSearchFolders.CheckedChanged += new System.EventHandler(this.chbxSearchFolders_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 248);
            this.Controls.Add(this.chbxSearchFolders);
            this.Controls.Add(this.chbxSearchFiles);
            this.Controls.Add(this.pnlChooseTypeSearching);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txbxFileName);
            this.Controls.Add(this.lblFileName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(649, 287);
            this.MinimumSize = new System.Drawing.Size(649, 287);
            this.Name = "MainForm";
            this.Text = "Task 3 (System.IO)";
            this.pnlChooseTypeSearching.ResumeLayout(false);
            this.pnlChooseTypeSearching.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txbxFileName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlChooseTypeSearching;
        private System.Windows.Forms.Panel pnlChooseFolders;
        private System.Windows.Forms.Panel pnlLogicDrives;
        private System.Windows.Forms.RadioButton rBtnChooseFolders;
        private System.Windows.Forms.RadioButton rBtnLogicDrives;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.CheckBox chbxSearchFiles;
        private System.Windows.Forms.CheckBox chbxSearchFolders;
    }
}

