using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZeeITWebsite.Startup))]
namespace ZeeITWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
