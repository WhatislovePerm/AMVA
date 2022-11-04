using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Alcotripnics.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace Alcotripnics.WebApp.Data.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<AccountCards> AccountCards { get; set; }

        //DbSet<Account> Accounts;
     }
}

