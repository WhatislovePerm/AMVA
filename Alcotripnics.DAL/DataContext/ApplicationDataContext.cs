using System;
using Alcotripnics.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Alcotripnics.DAL.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }


        //DbSet<ApplicationUser> ApplicationUsers;
     }
}

