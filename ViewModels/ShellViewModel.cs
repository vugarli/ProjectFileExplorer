using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.ViewModels
{
    class ShellViewModel : Screen
    {
        
        public ShellViewModel(Test t)
        {
			var a = t.name;
        }
        private string _path;

		public string Path
		{
			get { return _path; }
			set 
			{ 
				Files.Clear();
				_path = value;
				if(Directory.Exists(value))
				{
					Files.AddRange(new DirectoryInfo(value).GetDirectories("*").Select(d=>d.Name.ToString()));
				}
			}
		}

		public BindableCollection<string> Files { get; set; } = new();

		

	}
}
