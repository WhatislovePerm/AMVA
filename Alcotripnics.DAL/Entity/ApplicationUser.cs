using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Alcotripnics.DAL.Entity
{

    public class ApplicationUser : IdentityUser
    {
        public virtual Account ClientProfile { get; set; }
    }
}

