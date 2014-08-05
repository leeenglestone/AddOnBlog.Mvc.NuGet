using AddOnBlog.Mvc.Interfaces;
using AddOnBlog.Mvc.Library;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IBlogRepository _blogRepository;
        IKernel kernel;


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            kernel = new StandardKernel();
            kernel.Bind<IBlogRepository>().To<BlogRepository>();

            _blogRepository = kernel.Get<IBlogRepository>();

        }
    }
}
