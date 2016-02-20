using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GiftBox.Web.Startup))]
namespace GiftBox.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
