using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeProtectServer.Models.ActivationKeyProviders
{
    public interface IKeyProvider
    {
        string CreateKey(string username, int keyNumber);
    }
}
