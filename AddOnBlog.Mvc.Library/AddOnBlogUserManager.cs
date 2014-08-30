using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Library
{
    public class AddOnBlogUserManager :UserManager<AddOnBlogUser>
    {
        public AddOnBlogUserManager()
            : base(new AddOnBlogUserStore<AddOnBlogUser>())
        {

        }

        public override System.Threading.Tasks.Task<AddOnBlogUser> FindAsync(string userName, string password)
        {
            Task<AddOnBlogUser> taskInvoke = Task<AddOnBlogUser>.Factory.StartNew(() =>
            {
                //First Verify Password... 
                //PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(userName, password);
                //if (result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    //Return User Profile Object... 
                    //So this data object will come from Database we can write custom ADO.net to retrieve details/ 

                    if (userName == AddOnBlogSettings.Settings.UserName
                        && password == AddOnBlogSettings.Settings.Password)
                    {
                        AddOnBlogUser applicationUser = new AddOnBlogUser();
                        applicationUser.UserName = AddOnBlogSettings.Settings.UserName;
                        applicationUser.Id = "SomeId";
                        return applicationUser;
                    }
                }
                return null;
            });
            return taskInvoke;
        }       
    }
}
