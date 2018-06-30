using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GJF.Startup))]
namespace GJF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
