using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeltaAlpha.Startup))]
namespace DeltaAlpha
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
