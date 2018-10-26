using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckIn.Admin.Startup))]
namespace CheckIn.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
