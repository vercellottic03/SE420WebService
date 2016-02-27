using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEProjectWebservice.Startup))]
namespace SEProjectWebservice
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
