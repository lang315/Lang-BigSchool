using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lang_BigSchool.Startup))]
namespace Lang_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
