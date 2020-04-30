using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeProtectServer.Models
{
    public class License
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfActivation { get; set; }
        public string ActivatorIpAdress { get; set; }
    }
}