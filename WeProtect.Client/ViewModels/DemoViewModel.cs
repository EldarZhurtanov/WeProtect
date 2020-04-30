using DevExpress.Mvvm;
using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeProtect.Client.BL.AppBLs;
using WeProtect.Client.BL.AppBLs.Exceptions;

namespace WeProtect.Client.ViewModels
{
    public class DemoViewModel : ViewModelBase
    {
        private DemoAppModel model = new DemoAppModel();
        private INavigationManager _navigationManager;

        public DemoViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

            GoMain = new DelegateCommand(() => navigationManager.Navigate("Home"));

            Addition = new DelegateCommand(() =>
            {
                add3 = model.Addition(Convert.ToInt32(add1), Convert.ToInt32(add2)).ToString();
            });
            Subtraction = new DelegateCommand(() =>
            {
                try
                {
                    sub3 = model.Subtraction(Convert.ToInt32(sub1), Convert.ToInt32(sub2)).ToString();
                }
                catch(LicenseNotFoundException ex)
                {
                    Error = ex.Message;
                }
            });
            Multiplication = new DelegateCommand(() =>
            {
                try
                {
                    mul3 = model.Multiplication(Convert.ToInt32(mul1), Convert.ToInt32(mul2)).ToString();
                }
                catch (LicenseNotFoundException ex)
                {
                    Error = ex.Message;
                }
            });
            Division = new DelegateCommand(() =>
            {     
                try
                {
                    div3 = model.Division(Convert.ToInt32(div1), Convert.ToInt32(div2)).ToString();
                }
                catch (LicenseNotFoundException ex)
                {
                    Error = ex.Message;
                }
            });
        }
        public string Error { get; set; }
        public DelegateCommand GoMain { get; }
        #region Калькулятор
        public DelegateCommand Addition { get; }
        public DelegateCommand Subtraction { get; }
        public DelegateCommand Multiplication { get; }
        public DelegateCommand Division { get; }
        public string add1 { get; set; }
        public string add2 { get; set; }
        public string add3 { get; set; }
        public string sub1 { get; set; }
        public string sub2 { get; set; }
        public string sub3 { get; set; }
        public string mul1 { get; set; }
        public string mul2 { get; set; }
        public string mul3 { get; set; }
        public string div1 { get; set; }
        public string div2 { get; set; }
        public string div3 { get; set; }
        #endregion
    }
}
