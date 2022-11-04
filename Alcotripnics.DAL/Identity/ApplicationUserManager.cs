using System;
using Alcotripnics.DAL.Entity;
using Microsoft.AspNet.Identity;

namespace Alcotripnics.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}

