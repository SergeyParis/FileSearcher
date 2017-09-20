using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.Forms
{
    internal interface IShowAsync
    {
        Action ShowAsync { get; }
    }
}
