using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddOnBlog.SampleMvcApplication2.Startup))]
namespace AddOnBlog.SampleMvcApplication2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
