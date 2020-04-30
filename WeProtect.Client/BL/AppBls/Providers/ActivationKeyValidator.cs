using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeProtectServer.Models.ActivationKeyProviders;

namespace WeProtect.Client.BL.AppBls.Providers
{
    public class ActivationKeyValidator
    {
        private static int maxKeyValue = 13;
        private static List<string> alreadyActivatedKeys = new List<string>();
        private IList<IKeyProvider> keyProviders = new List<IKeyProvider>
        {
            new Sha1ActivationKeyProvider(),
            new MD5ActivationKeyProvider(),
            new AESActivationKeyProvider(),
        };

        public bool Validate(string username, string key)
        {
            if (alreadyActivatedKeys.Exists(k => k == key))
                return false;

            foreach (var provider in keyProviders)
                for (int i = 1; i < maxKeyValue; i++)
                    if (key == provider.CreateKey(username, i))
                    {
                        alreadyActivatedKeys.Add(key);
                        return true;
                    }

            return false;
        }
    }
}
