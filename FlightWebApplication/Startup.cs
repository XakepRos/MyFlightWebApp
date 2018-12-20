using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlightWebApplication.Startup))]
namespace FlightWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
