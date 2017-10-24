using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(qlbanxeoto.Startup))]
namespace qlbanxeoto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
