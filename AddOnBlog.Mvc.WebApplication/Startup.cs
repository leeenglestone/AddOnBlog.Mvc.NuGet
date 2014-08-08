using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddOnBlog.MvcApplication.Startup))]
namespace AddOnBlog.MvcApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
