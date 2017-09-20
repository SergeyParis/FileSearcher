using System;
using System.Collections.Generic;
using System.Threading;
using FileSearcher.Helpers;
using  FileSearcher.Enums;

namespace FileSearcher.MVC
{
    internal sealed class SearcherFileAndFolders
    {
        private const int LIST_LENGTH_FILEPATHES = 32768;
        private const int LIST_LENGTH_FOLDERPATHES = 8192;
        private const int LIST_LENGTH_PATHESCANTCHECK = 512;

        private readonly string _fileName;
        private readonly string[] _searcherPaths;
        private readonly WhatToSearch _whatToSearch;
        private List<string> _foundedPathesFiles;
        private List<string> _foundedPathesFolders;
        private List<string> _pathesCantCheck;

        public List<string> FoundedPathesFiles => _foundedPathesFiles;
        public List<string> FoundedPathesFolders => _foundedPathesFolders;
        public List<string> PathesCantCheck => _pathesCantCheck;

        public SearcherFileAndFolders(string fileName, string[] paths, WhatToSearch whatToSearch)
        {
            this._fileName = ConvertToGegularExpresion.Convert(fileName);
            this._searcherPaths = paths;
            this._whatToSearch = whatToSearch;

            this._foundedPathesFiles = new List<string>(LIST_LENGTH_FILEPATHES);
            this._foundedPathesFolders = new List<string>(LIST_LENGTH_FOLDERPATHES);
            this._pathesCantCheck = new List<string>(LIST_LENGTH_PATHESCANTCHECK);
        }

        public void GoAsync()
        {
            if (_fileName == null || _searcherPaths == null)
                throw new ArgumentNullException(Properties.ErrorMessages.FileNameSearcherPathIsNULL);

            Thread[] threads = new Thread[_searcherPaths.Length];

            for (int i = 0; i < _searcherPaths.Length; i++)
                threads[i] = new Thread(GetPath) { IsBackground = true };

            for (int i = 0; i < _searcherPaths.Length; i++)
                threads[i].Start(_searcherPaths[i]);

            new Thread(CheckSearchComplate) { IsBackground = true }.Start(threads);
        }

        private void GetPath(object path)
        {
            if (path is string s)
            {
                WorkWithDirectory workWithDirectory = new WorkWithDirectory(_whatToSearch);
                workWithDirectory.Searching(this._fileName, s);

                _foundedPathesFiles.AddRangeAsync(workWithDirectory.FoundedFiles);
                _foundedPathesFolders.AddRangeAsync(workWithDirectory.FoundedFolders);
                _pathesCantCheck.AddRangeAsync(workWithDirectory.PathesException);
            }
            else
                throw new ArgumentException(Properties.ErrorMessages.ArgumentIsNotString);
        }

        private void CheckSearchComplate(object threads)
        {
            Thread[] _threads = threads as Thread[];

            if (_threads == null)
                throw new ArgumentException(Properties.ErrorMessages.ArgumentIsNotThreadArray);

            bool flag = true;

            while (flag)
            {
                Thread.Sleep(200);
                flag = false;

                foreach (Thread thread in _threads)
                    if (thread.IsAlive)
                        flag = true;
            }

            SearchComplate?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler SearchComplate;
    }
}
