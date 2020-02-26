using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidley2.Startup))]
namespace Vidley2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
