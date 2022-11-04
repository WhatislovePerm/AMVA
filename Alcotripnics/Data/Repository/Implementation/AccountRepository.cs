using System;
using Alcotripnics.Data.Entity;
using Alcotripnics.Models;
using Alcotripnics.WebApp.Data.DataContext;
using Alcotripnics.WebApp.Data.Repository;

namespace Alcotripnics.WebApp.Data.Repository.Implementation
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

