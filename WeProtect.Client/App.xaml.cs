using Egor92.MvvmNavigation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WeProtect.Client.ViewModels;
using WeProtect.Client.Views;

namespace WeProtect.Client
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow();
            var navigationManager = new NavigationManager(window);

            navigationManager.Register<Home>("Home", () => new HomeViewModel(navigationManager));
            //navigationManager.Register<Home>("Home", () => new HomeViewModel(navigationManager));
            navigationManager.Register<Demo>("Demo", () => new DemoViewModel(navigationManager));
            navigationManager.Register<Trial>("Trial", () => new TrialViewModel(navigationManager));
            navigationManager.Register<BuyOnly>("BuyOnly", () => new BuyOnlyViewModel(navigationManager));
            navigationManager.Register<Subscription>("Subscription", () => new SubsciptionViewModel(navigationManager));

            //var viewModel = new MainViewModel(navigationManager);

            //window.DataContext = viewModel;
            navigationManager.Navigate("Home", null);
            window.Show();
        }
    }
}
