using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WeProtectServer.Models.ActivationKeyProviders
{
    public class AESActivationKeyProvider : IKeyProvider
    {
        private static string secretAppKey = "2e315dcaa77983999bf11106c65229dc";
        private string aesKey = "mv701+w/Lee/4rCs4L4fWTSoS5IwQ9YE0cXJA+kw79U=";
        private string aesIV = "/pkgFjPurUXl8eLbduNjcg==";
        public string CreateKey(string username, int keyNumber)
        {
            byte[] encrypted;

            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Convert.FromBase64String(aesKey);
                rijAlg.IV = Convert.FromBase64String(aesIV);

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(username + secretAppKey + keyNumber);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }
    }
}