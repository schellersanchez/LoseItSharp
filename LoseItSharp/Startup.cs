using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoseItSharp.Startup))]
namespace LoseItSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
