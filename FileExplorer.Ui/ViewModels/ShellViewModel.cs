using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using FileExplorer.Core.Models;
using FileExplorer.Views;

namespace FileExplorer.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        
        public ICommand commandBack;
        public ShellViewModel()
        {
        }
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);

            ShellView shellView = (ShellView)view;
            
            shellView.CommandBindings.Add(new CommandBinding(ApplicationCommands.Open,test));
        }
        

        private string _path = "C:/";

		public string Path
		{
			get { return _path; }
			set 
			{ 
				_path = value;
                NotifyOfPropertyChange(() => Path);
			}
		}

		public List<ItemInfo> Files { get; set; } = new();

        public void OnKeyDownHandler(KeyEventArgs e)
        {
                Submit();
        }

        public void test(object sender, ExecutedRoutedEventArgs e)
        {
            var a = "a";
        }

        public void Submit()
		{
            if (Directory.Exists(Path))
            {
                Files.Clear();
                Files.AddRange(
                    new DirectoryInfo(Path).GetFiles("*")
                    .Select(d => new ItemInfo(d.Name,d.CreationTime,"file",true,(int)d.Length,d.FullName))
                );
                Files.AddRange(
                    new DirectoryInfo(Path).GetDirectories("*")
                    .Select(d => new ItemInfo(d.Name, d.CreationTime, "file", true, -1, d.FullName))
                );
                var model = new FilesListViewModel(Files);
                ActiveItem = model;
            }
        }

        public void ItemClicked(ItemInfo itemInfo)
        {
            Path = itemInfo.Path;
            Submit();
        }


    }
}
