using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vms.Startup))]
namespace vms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
