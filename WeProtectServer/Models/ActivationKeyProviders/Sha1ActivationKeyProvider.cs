using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WeProtectServer.Models.ActivationKeyProviders
{
    public class Sha1ActivationKeyProvider : IKeyProvider
    {
        private static string secretAppKey = "2e315dcaa77983999bf11106c65229dc";
        public string CreateKey(string username, int keyNumber)
        {
            return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(username + secretAppKey + keyNumber)));
        }
    }
}