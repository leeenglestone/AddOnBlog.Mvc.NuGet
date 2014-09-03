using AddOnBlog.Mvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddOnBlog.Mvc.Library
{
    public class Post : IPost
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FriendlyUrl { get; set; }
        public DateTime PostDate { get; set; }

        [XmlIgnore]
        public string Content { get; set; }

        [XmlElement("Content")]
        System.Xml.XmlCDataSection ContentCData
        {
            get
            {
                return new System.Xml.XmlDocument().CreateCDataSection(Content);
            }
            set
            {
                Content = value.Value;
            }
        }


        public string Categories { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserWebsite { get; set; }
        public string SavePath { get; set; }
        public bool Approved { get; set; }
        public string Author { get; set; }
        public string AuthorLink { get; set; }
    }
}
