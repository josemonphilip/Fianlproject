using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(rc.UserInterface.MVC.Startup))]
namespace rc.UserInterface.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
