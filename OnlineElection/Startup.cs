using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineElection.Startup))]
namespace OnlineElection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
