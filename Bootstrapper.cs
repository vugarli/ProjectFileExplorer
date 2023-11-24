using Caliburn.Micro;
using FileExplorer.ViewModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileExplorer
{
    public record Test(string name = "Vugar");

    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void Configure()
        {
            _container.Instance(_container);
            _container.Singleton<Test>();
            _container.RegisterPerRequest(typeof(ShellViewModel), null, typeof(ShellViewModel));
        }

        public Bootstrapper()
        {
            Initialize();
        }

        protected async override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);
            await DisplayRootViewForAsync<ShellViewModel>();
        }

    }
}
