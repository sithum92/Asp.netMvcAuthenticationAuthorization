using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Asp.netMvcAuthenticationAuthorization.Startup))]
namespace Asp.netMvcAuthenticationAuthorization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
