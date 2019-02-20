using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCRM.Startup))]
namespace MyCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
