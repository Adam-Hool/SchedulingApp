using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchedulingApp.Startup))]
namespace SchedulingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
