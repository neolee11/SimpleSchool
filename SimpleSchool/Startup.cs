using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleSchool.Startup))]
namespace SimpleSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
