using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using FileSearcher.Enums;

namespace FileSearcher.MVC
{
    internal class WorkWithDirectory
    {
        private readonly List<string> _foundedFiles;
        private List<string> _foundedFolders;
        private readonly List<string> _pathesException;
        private readonly WhatToSearch _whatToSearch;

        public List<string> FoundedFiles => _foundedFiles;
        public List<string> FoundedFolders => _foundedFolders;
        public List<string> PathesException => _pathesException;

        public WorkWithDirectory(WhatToSearch whatToSearch)
        {
            this._foundedFiles = new List<string>();
            this._foundedFolders = new List<string>();
            this._pathesException = new List<string>();

            this._whatToSearch = whatToSearch;
        }

        public void Searching(string fileName, string directory)
        {
            Search(fileName, directory);
        }

        private void Search(string fileName, string directory)
        {
            string[] allFiles;

            try
            {
                allFiles = Directory.GetFiles(directory);
            }
            catch (System.UnauthorizedAccessException)
            {
                _pathesException.Add(directory);
                return;
            }
            
            if (this._whatToSearch == WhatToSearch.Folders ||
                this._whatToSearch == (WhatToSearch.Files | WhatToSearch.Folders))
            {
                string[] parse = directory.Split('\\');
                string parseFolderName = parse[parse.Length - 1];

                if (new Regex(fileName).IsMatch(parseFolderName))
                    _foundedFolders.Add(directory);
            }

            if (this._whatToSearch == WhatToSearch.Files ||
                    this._whatToSearch == (WhatToSearch.Files | WhatToSearch.Folders))
            {
                foreach (string file in allFiles)
                {
                    string[] parse = file.Split('\\');
                    string parseFileName = parse[parse.Length - 1];

                    if (new Regex(fileName).IsMatch(parseFileName))
                        _foundedFiles.Add(file);
                }
            }

            string[] allDirectory = Directory.GetDirectories(directory);

            foreach (string directoryName in allDirectory)
                Search(fileName, directoryName);
        }
    }
}
