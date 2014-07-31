using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Library
{
    public class AddOnBlogConfigurationHelper
    {
        //Samples.AspNet.PageAppearanceSection config =
        //(Samples.AspNet.PageAppearanceSection)System.Configuration.ConfigurationManager.GetSection(
        //"pageAppearanceGroup/pageAppearance");

        public static string PostSavePath()
        {
            AddOnBlogConfigurationSection config = (AddOnBlogConfigurationSection)System.Configuration.ConfigurationManager.GetSection(
        "addOnBlogConfiguration");

            return config.PostSaveLocation;
        }
    }
}
