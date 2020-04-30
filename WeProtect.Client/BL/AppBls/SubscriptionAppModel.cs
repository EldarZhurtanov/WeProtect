using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeProtect.Client.BL.AppBLs.Models;

namespace WeProtect.Client.BL.AppBLs
{
    class SubscriptionAppModel : BuyOnlyModel
    {
        public override DateTime? LicenseEndTime
        {
            get => base.LicenseEndTime;
            protected set
            {
                if (value == null)
                {
                    base.LicenseEndTime = DateTime.Now + TimeSpan.FromMinutes(1);
                }
                else
                {
                    base.LicenseEndTime = value;
                }
            }
        }
    }
}
