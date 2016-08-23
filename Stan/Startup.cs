using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stan.Startup))]
namespace Stan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
