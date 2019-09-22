using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EA446115_MIS4200.Startup))]
namespace EA446115_MIS4200
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
