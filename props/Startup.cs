using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(props.Startup))]
namespace props
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
