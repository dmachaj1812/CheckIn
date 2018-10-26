using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckIn.Website.Startup))]
namespace CheckIn.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
