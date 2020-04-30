using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeProtect.Client.BL.AppBLs.License
{
    public class LicenseProvider
    {
        private const string APP_PATH = "https://localhost:44332/";
        public bool BuyLicense(string username, string password)
        {
            using (var client = new HttpClient())
            {
                string parameters = "username=" + username + "&password=" + password; 
                var response = client.GetAsync(APP_PATH + "api/LicenseBuy/BuyLicense?" + parameters).Result;

                string result = (response.Content.ReadAsStringAsync().Result);

                return result == $"<boolean xmlns=\"http://schemas.microsoft.com/2003/10/Serialization/\">true</boolean>";
            }
        }
    }
}
