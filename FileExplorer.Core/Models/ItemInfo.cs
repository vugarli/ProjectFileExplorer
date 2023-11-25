using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Core.Models
{
    public class ItemInfo
    {
        public ItemInfo(string name, DateTime dateModified, string type, bool isFolder, int size, string path)
        {
            Name = name;
            DateModified = dateModified;
            Type = type;
            IsFolder = isFolder;
            Size = size;
            Path = path;
        }

        public string Name { get; set; }
        public DateTime DateModified { get; set; }
        public string Type { get; set; }
        public bool IsFolder { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
    }

}
