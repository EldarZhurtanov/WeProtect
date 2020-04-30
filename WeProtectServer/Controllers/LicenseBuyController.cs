using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WeProtectServer.Models;

namespace WeProtectServer.Controllers
{
    public class LicenseBuyController : ApiController
    {
        ApplicationDbContext DbContext => Request.GetOwinContext().Get<ApplicationDbContext>();
        // GET api/LicenseBuy/BuyLicense
        [HttpGet]
        async public Task<bool> BuyLicense(string username, string password)
        {
            var result = await Request.GetOwinContext().Get<ApplicationSignInManager>()
                .PasswordSignInAsync(username, password, false, false);

            if(result == SignInStatus.Failure)
                return false;

            License newLicense = new License
            {
                ActivatorIpAdress = HttpContext.Current.Request.UserHostAddress,
                DateOfActivation = DateTime.Now,
                UserId = User.Identity.GetUserId()
            };

            DbContext.Licenses.Add(newLicense);

            await DbContext.SaveChangesAsync();
            return true;
        }
    }
}