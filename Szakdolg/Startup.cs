using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Szakdolg.Startup))]
namespace Szakdolg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
