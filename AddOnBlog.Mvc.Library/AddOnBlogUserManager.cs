using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddOnBlog.Mvc.Library
{
    public class AddOnBlogUserManager :UserManager<ApplicationUser>
    {
        public AddOnBlogUserManager() : base(new CustomUserStore<ApplicationUser>())
        {
            //We can retrieve Old System Hash Password and can encypt or decrypt old password using custom approach. 
            //When we want to reuse old system password as it would be difficult for all users to initiate pwd change as per Idnetity Core hashing. 
            this.PasswordHasher = new OldSystemPasswordHasher(); 
        }
        public override System.Threading.Tasks.Task<ApplicationUser> FindAsync(string userName, string password)
        {
            Task<ApplicationUser> taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
            {
                //First Verify Password... 
                PasswordVerificationResult result = this.PasswordHasher.VerifyHashedPassword(userName, password);
                if (result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    //Return User Profile Object... 
                    //So this data object will come from Database we can write custom ADO.net to retrieve details/ 
                    ApplicationUser applicationUser = new ApplicationUser();
                    applicationUser.UserName = "san";
                    return applicationUser;
                }
                return null;
            });
            return taskInvoke;
        }       
    }
}
