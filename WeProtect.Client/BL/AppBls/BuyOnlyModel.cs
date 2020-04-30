using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeProtect.Client.BL.AppBls.Providers;
using WeProtect.Client.BL.AppBLs.Exceptions;
using WeProtect.Client.BL.AppBLs.License;
using WeProtect.Client.BL.AppBLs.Models;

namespace WeProtect.Client.BL.AppBLs
{
    public class BuyOnlyModel
    {
        protected Calc calc = new Calc();
        virtual public DateTime? LicenseEndTime { get; protected set; } = DateTime.Now.AddMilliseconds(-1);

        public bool BuyLicense(AuthParameters authParameters)
        {
            LicenseProvider licenseProvider = new LicenseProvider();
            bool buySuccess = licenseProvider.BuyLicense(authParameters.Username, authParameters.Password);

            if (buySuccess)
                LicenseEndTime = null;

            return buySuccess;
        }

        public bool ActivateKey(string username, string activationKey)
        {
            LicenseEndTime = null;
            bool activateSuccess = new ActivationKeyValidator().Validate(username, activationKey);

            if (activateSuccess)
                LicenseEndTime = null;

            return activateSuccess;
        }

        #region Доступ к "логике" приложения
        virtual public int Addition(int a, int b)
        {
            if (LicenseEndTime <= DateTime.Now)
                throw new LicenseTimeEndException();

            return calc.Addition(a, b);
        }
        virtual public int Subtraction(int a, int b)
        {
            if (LicenseEndTime <= DateTime.Now)
                throw new LicenseTimeEndException();

            return calc.Subtraction(a, b);
        }
        virtual public int Multiplication(int a, int b)
        {
            if (LicenseEndTime <= DateTime.Now)
                throw new LicenseTimeEndException();

            return calc.Multiplication(a, b);
        }
        virtual public int Division(int a, int b)
        {
            if (LicenseEndTime <= DateTime.Now)
                throw new LicenseTimeEndException();

            return calc.Division(a, b);
        }
        #endregion
    }
}
