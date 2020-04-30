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
    public class TrialViewModel : ViewModelBase
    {
        private TrialAppModel model = new TrialAppModel();
        private INavigationManager _navigationManager;
        public TrialViewModel(INavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

            LicenseEndTime = model.LicenseEndTime.GetValueOrDefault();

            BuyLicense = new DelegateCommand(() =>
            {
                bool success = model.BuyLicense(new BL.AppBLs.Models.AuthParameters 
                {
                    Password = this.Password,
                    Username = this.Username

                });
                if(success)
                {
                    Error = "";
                    State = "Вы активировали ключ";
                    LicenseAtivatedSuccessfully();
                }
                else
                {
                    Error = "Неверный логин или пароль";
                }
            });

            ActivateKey = new DelegateCommand(() =>
            {
                bool success = model.ActivateKey(ActivationKeyUsername, ActivationKey);

                if (success)
                {
                    Error = "";
                    State = "Вы приобрели лицензию";
                    LicenseAtivatedSuccessfully();
                }
                else
                {
                    Error = "Неверный логин или ключ(возможно ключ уже был активирован)";
                }
            });

            GoMain = new DelegateCommand(() => navigationManager.Navigate("Home"));
            Addition = new DelegateCommand(() =>
            {
                try
                {
                    add3 = model.Addition(Convert.ToInt32(add1), Convert.ToInt32(add2)).ToString();
                }
                catch (LicenseTimeEndException ex)
                {
                    Error = "Пробный период истёк";
                }
        });
            Subtraction = new DelegateCommand(() =>
            {
                try
                {
                    sub3 = model.Subtraction(Convert.ToInt32(sub1), Convert.ToInt32(sub2)).ToString();
                }
                catch (LicenseTimeEndException ex)
                {
                    Error = "Пробный период истёк";
                }
            });
            Multiplication = new DelegateCommand(() =>
            {
                try
                {
                    mul3 = model.Multiplication(Convert.ToInt32(mul1), Convert.ToInt32(mul2)).ToString();
                }
                catch (LicenseTimeEndException ex)
                {
                    Error = "Пробный период истёк";
                }
            });
            Division = new DelegateCommand(() =>
            {
                try
                {
                    div3 = model.Division(Convert.ToInt32(div1), Convert.ToInt32(div2)).ToString();
                }
                catch (LicenseTimeEndException ex)
                {
                    Error = "Пробный период истёк";
                }
            });
        }
        public string Error { get; set; }
        public string State { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ActivationKey { get; set; }
        public string ActivationKeyUsername { get; set; }
        public DateTime LicenseEndTime { get; set; }
        public DelegateCommand BuyLicense { get; }
        public DelegateCommand ActivateKey { get; }
        public DelegateCommand GoMain { get; }

        public delegate void LicenseAtivatedHandler();
        public event LicenseAtivatedHandler LicenseAtivatedSuccessfully;
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
