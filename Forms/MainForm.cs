using System;
using System.Collections.Generic;
using System.Collections;
using System.Windows.Forms;
using FileSearcher.MVC;
using FileSearcher.Enums;

namespace FileSearcher.Forms
{
    public sealed partial class MainForm : Form, IGenerateResults, IShowAsync
    {
        private ResultsForm _resultsForm;
        private SearcherFileAndFolders _searcherFileAndFolders;
        private TypePathesSearching _typePathesSearching;
        private WhatToSearch _whatToSearch;

        private List<string> _pathesFiles;
        private List<string> _pathesFolders;

        private readonly Action _hideFormAsync;
        private readonly Action _showFormAsync;
        private readonly string[] _logicalDrives;
        private ShowResultFormAsync _showResultFormAsync;

        public IEnumerable<string> GetPathesFiles => _pathesFiles;
        public IEnumerable<string> GetPathesFolders => _pathesFolders;

        public Action ShowAsync => _showFormAsync;

        public MainForm()
        {
            InitializeComponent();

            this._hideFormAsync += this.Hide;
            this._showFormAsync += this.Show;

            this._logicalDrives = Helpers.FileSystemInfo.GetAllDrives;

            this._typePathesSearching = TypePathesSearching.LogicDrives;
            this._whatToSearch = WhatToSearch.Files | WhatToSearch.Folders;

            SettingPanelCheckBox();
        }

        private void StartSearchFile(string[] pathes)
        {
            _searcherFileAndFolders = new SearcherFileAndFolders(this.txbxFileName.Text.Trim(), pathes, this._whatToSearch);
            _searcherFileAndFolders.SearchComplate += Searcher_SearchComplate;
            _searcherFileAndFolders.GoAsync();
        }

        private void SetTypeOfSearching()
        {
            if (this.chbxSearchFiles.Checked && this.chbxSearchFolders.Checked)
                this._whatToSearch = WhatToSearch.Files | WhatToSearch.Folders;
            else if (this.chbxSearchFiles.Checked && !this.chbxSearchFolders.Checked)
                this._whatToSearch = WhatToSearch.Files;
            else if (!this.chbxSearchFiles.Checked && this.chbxSearchFolders.Checked)
                this._whatToSearch = WhatToSearch.Folders;
            else
                this._whatToSearch = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this._whatToSearch == 0)
                MessageBox.Show(Properties.ErrorMessages.WhatSearchIsEmpty);

            if (this._typePathesSearching == TypePathesSearching.LogicDrives)
            {
                List<string> list = new List<string>();

                foreach (Control control in pnlLogicDrives.Controls)
                    if (control is CheckBox checkBox && checkBox.Checked)
                        list.Add(checkBox.Text);

                StartSearchFile(list.ToArray());
            }
            else
            {
                List<string> list = new List<string>();

                foreach (CustumFolder folderCustum in this._listOfFolders)
                    if (folderCustum.Checked)
                        list.Add(folderCustum.Text);

                StartSearchFile(list.ToArray());
            }
        }
        private void Searcher_SearchComplate(object sender, EventArgs e)
        {
            this._pathesFiles = this._searcherFileAndFolders.FoundedPathesFiles;
            this._pathesFolders = this._searcherFileAndFolders.FoundedPathesFolders;

            if (_pathesFiles.Count == 0 && _pathesFolders.Count == 0)
            {
                MessageBox.Show(Properties.ErrorMessages.FileOrFolderNotFound);
                return;
            }

            this._resultsForm = new ResultsForm(this);
            this._showResultFormAsync += this._resultsForm.ShowDialog;
            
            _showResultFormAsync.Invoke();
            

            this._showResultFormAsync -= this._resultsForm.ShowDialog;
            this._searcherFileAndFolders.SearchComplate -= Searcher_SearchComplate;
        }
        private void chbxSearchFiles_CheckedChanged(object sender, EventArgs e)
        {
            SetTypeOfSearching();
        }
        private void chbxSearchFolders_CheckedChanged(object sender, EventArgs e)
        {
            SetTypeOfSearching();
        }

        private delegate DialogResult ShowResultFormAsync();

        private enum TypePathesSearching
        {
            LogicDrives,
            CustomFolders
        }
    }
}
