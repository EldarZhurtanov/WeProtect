using System;


namespace WeProtect.Client.BL.AppBLs
{
    public class TrialAppModel : BuyOnlyModel
    {
        private TimeSpan trialPeriod = TimeSpan.FromSeconds(15);

        public TrialAppModel()
        {
            LicenseEndTime = DateTime.Now + trialPeriod;
        }
    }
}
