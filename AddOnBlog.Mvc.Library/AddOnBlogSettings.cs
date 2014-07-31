using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Library
{
    public class AddOnBlogSettings : ConfigurationSection
    {
        [ConfigurationProperty("postSavePath")]
        public string PostSavePath { 
            get { return (string)this["postSavePath"]; }
            set { this["postSavePath"] = value;} 
        }

        private static AddOnBlogSettings settings = 
            ConfigurationManager.GetSection("addOnBlogSettings") as AddOnBlogSettings;


        public static AddOnBlogSettings Settings
        {
            get {
                return settings;
            }
        }

    }
}
