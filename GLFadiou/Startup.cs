using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GLFadiou.Startup))]
namespace GLFadiou
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
