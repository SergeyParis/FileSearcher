namespace FileSearcher.Forms
{
    partial class ResultsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.treeViewFounded = new System.Windows.Forms.TreeView();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.btnCollapseAll = new System.Windows.Forms.Button();
            this.contextMenuStripFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsFolder_OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsFile_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFile_OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFolder.SuspendLayout();
            this.contextMenuStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Found files:";
            // 
            // treeViewFounded
            // 
            this.treeViewFounded.Location = new System.Drawing.Point(7, 67);
            this.treeViewFounded.Name = "treeViewFounded";
            this.treeViewFounded.Size = new System.Drawing.Size(940, 360);
            this.treeViewFounded.TabIndex = 2;
            this.treeViewFounded.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFounded_AfterCollapse);
            this.treeViewFounded.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFounded_AfterExpand);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Location = new System.Drawing.Point(88, 12);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(75, 23);
            this.btnExpandAll.TabIndex = 3;
            this.btnExpandAll.Text = "Expand all";
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Location = new System.Drawing.Point(7, 12);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(75, 23);
            this.btnCollapseAll.TabIndex = 4;
            this.btnCollapseAll.Text = "Collapse all";
            this.btnCollapseAll.UseVisualStyleBackColor = true;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // contextMenuStripFolder
            // 
            this.contextMenuStripFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFolder_OpenFolder});
            this.contextMenuStripFolder.Name = "contextMenuStripFolder";
            this.contextMenuStripFolder.Size = new System.Drawing.Size(138, 26);
            // 
            // cmsFolder_OpenFolder
            // 
            this.cmsFolder_OpenFolder.Name = "cmsFolder_OpenFolder";
            this.cmsFolder_OpenFolder.Size = new System.Drawing.Size(137, 22);
            this.cmsFolder_OpenFolder.Text = "Open folder";
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFile_OpenFile,
            this.cmsFile_OpenFolder});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.Size = new System.Drawing.Size(138, 48);
            // 
            // cmsFile_OpenFile
            // 
            this.cmsFile_OpenFile.Name = "cmsFile_OpenFile";
            this.cmsFile_OpenFile.Size = new System.Drawing.Size(137, 22);
            this.cmsFile_OpenFile.Text = "Open file";
            // 
            // cmsFile_OpenFolder
            // 
            this.cmsFile_OpenFolder.Name = "cmsFile_OpenFolder";
            this.cmsFile_OpenFolder.Size = new System.Drawing.Size(137, 22);
            this.cmsFile_OpenFolder.Text = "Open folder";
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 439);
            this.Controls.Add(this.btnCollapseAll);
            this.Controls.Add(this.btnExpandAll);
            this.Controls.Add(this.treeViewFounded);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultsForm";
            this.Text = "Results";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultsForm_FormClosed);
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.contextMenuStripFolder.ResumeLayout(false);
            this.contextMenuStripFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeViewFounded;
        private System.Windows.Forms.Button btnExpandAll;
        private System.Windows.Forms.Button btnCollapseAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFolder;
        private System.Windows.Forms.ToolStripMenuItem cmsFolder_OpenFolder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem cmsFile_OpenFile;
        private System.Windows.Forms.ToolStripMenuItem cmsFile_OpenFolder;
    }
}