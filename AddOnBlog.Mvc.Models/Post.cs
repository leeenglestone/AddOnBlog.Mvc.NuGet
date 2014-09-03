using AddOnBlog.Mvc.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AddOnBlog.Mvc.Models
{
    [Serializable]
    public class Post : IPost
    {
        public Post() { }

        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string FriendlyUrl { get; set; }
        public DateTime PostDate { get; set; }
        
        private string _content;
        
        [XmlIgnore]
        public string Content { get { return _content; } set { _content = value; } }

        [XmlElement("Content")]
        public XmlCDataSection ContentTest
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                return doc.CreateCDataSection(_content);
            }
            set
            {
                _content = value.Value;
            }
        }

        public string Categories { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserWebsite { get; set; }
        public bool Approved { get; set; }
        public string SavePath { get; set; }
        public string Author { get; set; }
        public string AuthorLink { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
