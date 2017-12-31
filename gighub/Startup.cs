using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gighub.Startup))]
namespace gighub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
