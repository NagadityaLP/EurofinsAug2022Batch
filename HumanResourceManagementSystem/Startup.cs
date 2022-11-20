using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HumanResourceManagementSystem.Startup))]
namespace HumanResourceManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
