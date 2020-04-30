using DevExpress.Mvvm;
using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeProtect.Client.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationManager _navigationManager;
        public HomeViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            Demo = new DelegateCommand(() =>
            {
                _navigationManager.Navigate("Demo");
            });

            Trial = new DelegateCommand(() =>
            {
                _navigationManager.Navigate("Trial");

            });

            BuyOnly = new DelegateCommand(() =>
            {
                _navigationManager.Navigate("BuyOnly");

            });

            Subscription = new DelegateCommand(() =>
            {
                _navigationManager.Navigate("Subscription");

            });
        }

        public DelegateCommand Demo { get; }
        public DelegateCommand Trial { get; }
        public DelegateCommand BuyOnly { get; }
        public DelegateCommand Subscription { get; }
    }
}
