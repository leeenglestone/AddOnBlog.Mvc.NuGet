using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddOnBlog.SampleMvcApplication.Startup))]
namespace AddOnBlog.SampleMvcApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
