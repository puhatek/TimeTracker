using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimeTracker.Startup))]
namespace TimeTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
