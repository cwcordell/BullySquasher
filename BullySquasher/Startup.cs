using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BullySquasher.Startup))]
namespace BullySquasher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
