using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileSearcher.Forms
{
    internal sealed partial class ResultsForm : Form
    {
        private readonly IGenerateResults _parent;

        private readonly IEnumerable<string> _pathesFiles;
        private readonly IEnumerable<string> _pathesFolders;

        private readonly ContextMenuStrip _cmsFile;
        private readonly ContextMenuStrip _cmsFolder;

        public ResultsForm(IGenerateResults parent)
        {
            InitializeComponent();

            this._parent = parent;

            this._pathesFiles = this._parent.GetPathesFiles;
            this._pathesFolders = this._parent.GetPathesFolders;

            this.treeViewFounded.HotTracking = true;
            this.treeViewFounded.Scrollable = true;
        }

        private void BuildTree()
        {
            this.treeViewFounded.BeginUpdate();

            AddNodesToTree(_pathesFolders, FontStyle.Underline);
            AddNodesToTree(_pathesFiles, FontStyle.Underline);

            if (this._pathesFiles.Count() + this._pathesFiles.Count() < 50000)
                btnExpandAll_Click(null, null);
            else
                this.btnExpandAll.Visible = false;
            
            BindingContextMenuStrip();

            this.treeViewFounded.EndUpdate();
        }

        private void AddNodesToTree(IEnumerable<string> pathes, FontStyle styleFoundedEllements = FontStyle.Regular)
        {
            foreach (string path in pathes)
            {
                string[] parse = ParsePath(path);

                TreeNodeCollection collection = this.treeViewFounded.Nodes;

                for (int i = 0; i < parse.Length; i++)
                {
                    TreeNode currentNode = collection[parse[i]];

                    if (currentNode == null)
                    {
                        collection.Add(parse[i], parse[i]);
                        currentNode = collection[parse[i]];
                    }

                    if (i == parse.Length - 1)
                        currentNode.NodeFont = new Font(FontFamily.GenericSansSerif, 8, styleFoundedEllements);

                    collection = currentNode.Nodes;
                }
            }
        }

        private void BindingContextMenuStrip()
        {
            foreach (string path in _pathesFiles)
            {
                string[] parse = ParsePath(path);

                TreeNode currentNode = this.treeViewFounded.Nodes[parse[0]];

                for (int i = 1; i < parse.Length; i++)
                {
                    currentNode.ContextMenuStrip = _cmsFolder;
                    currentNode = currentNode.Nodes[parse[i]];
                }

                currentNode.ContextMenuStrip = _cmsFile;
            }

            foreach (TreeNode node in this.treeViewFounded.Nodes)
                BindingContextMenuStripFolders(node);
        }
        private void BindingContextMenuStripFolders(TreeNode nodeFolder)
        {
            nodeFolder.ContextMenuStrip = _cmsFolder;

            foreach (TreeNode node in nodeFolder.Nodes)
                if (node.ContextMenuStrip == null)
                    node.ContextMenuStrip = _cmsFolder;
        }

        private string[] ParsePath(string path)
        {
            string[] parse = path.Split('\\');

            int counter = 0;
            foreach (string s in parse)
                if (String.IsNullOrWhiteSpace(s))
                    counter++;

            if (counter == 0)
                return parse;

            string[] parse2 = new string[parse.Length - counter];

            int i = 0;
            foreach (string s in parse)
                if (!String.IsNullOrWhiteSpace(s))
                    parse2[i++] = s;

            return parse2;
        }

        private void ResultsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_parent is IShowAsync showed)
                this.Invoke(showed.ShowAsync);
            else
                Application.Exit();
        }
        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            this.treeViewFounded.BeginUpdate();
            this.treeViewFounded.ExpandAll();
            this.treeViewFounded.EndUpdate();

            this.btnExpandAll.Enabled = false;
            this.btnCollapseAll.Enabled = true;
        }
        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            this.treeViewFounded.BeginUpdate();
            this.treeViewFounded.CollapseAll();
            this.treeViewFounded.EndUpdate();

            this.btnExpandAll.Enabled = true;
            this.btnCollapseAll.Enabled = false;
        }
        private void treeViewFounded_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            this.btnExpandAll.Enabled = true;
            this.btnCollapseAll.Enabled = true;
        }
        private void treeViewFounded_AfterExpand(object sender, TreeViewEventArgs e)
        {
            this.btnExpandAll.Enabled = true;
            this.btnCollapseAll.Enabled = true;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            BuildTree();
        }
    }
}
