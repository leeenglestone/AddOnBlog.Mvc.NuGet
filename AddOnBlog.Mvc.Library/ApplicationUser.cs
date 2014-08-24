using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddOnBlog.Mvc.Library
{
    public class ApplicationUser : IUser
    {
        public DateTime CreateDate { get; set; }
        public DateTime BirthDate { get; set; }

        public ApplicationUser()
        {
            CreateDate = DateTime.Now;
        }
        public string Id
        {
            get { return "GUID"; }
        }

        public string UserName
        {
            get
            {
                return "san";
            }
            set
            {
                ;
            }
        } 
    }
}
