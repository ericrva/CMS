using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebChurchManagement.Startup))]
namespace WebChurchManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
