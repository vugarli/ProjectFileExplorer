using Caliburn.Micro;
using FileExplorer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.ViewModels
{
    internal class FilesListViewModel : Screen
    {
        public List<ItemInfo> Files { get; }

        public FilesListViewModel(List<ItemInfo> files)
        {
            Files = files;
        }


    }
}
