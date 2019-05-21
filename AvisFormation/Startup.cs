using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvisFormation.Startup))]
namespace AvisFormation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
