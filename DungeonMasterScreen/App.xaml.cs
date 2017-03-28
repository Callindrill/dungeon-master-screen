using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DungeonMasterScreen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _Container = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SetUpAutoFac();

            ShutdownMode = ShutdownMode.OnMainWindowClose;
            MainWindow = _Container.Resolve<DungeonMasterScreen.Views.MainWindow>();
            MainWindow.Show();
        }

        private void SetUpAutoFac()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder
                .RegisterType<DungeonMasterScreen.Views.MainWindow>()
                .AsSelf()
                .SingleInstance();

            _Container = containerBuilder.Build();
        }
    }
}
