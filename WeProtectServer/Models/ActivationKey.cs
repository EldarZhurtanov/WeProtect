using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeProtectServer.Models
{
    public class ActivationKey
    {
        public long Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public string UserId { get; set; }
        public string Key { get; set; }
        public int KeyNumber { get; set; }
    }
}