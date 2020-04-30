using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeProtectServer.Startup))]
namespace WeProtectServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
