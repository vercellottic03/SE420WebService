using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEWebService.Startup))]
namespace SEWebService
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
