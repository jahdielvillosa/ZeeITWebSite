using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelPackage.Startup))]
namespace TravelPackage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
