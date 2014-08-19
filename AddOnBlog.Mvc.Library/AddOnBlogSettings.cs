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

        [ConfigurationProperty("userName")]
        public string UserName
        {
            get { return (string)this["userName"]; }
            set { this["postSavePath"] = value; }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
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
