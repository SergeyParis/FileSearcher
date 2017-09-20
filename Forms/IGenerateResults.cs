using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.Forms
{
    internal interface IGenerateResults
    {
        IEnumerable<string> GetPathesFiles { get; }
        IEnumerable<string> GetPathesFolders { get; }
    }
}
