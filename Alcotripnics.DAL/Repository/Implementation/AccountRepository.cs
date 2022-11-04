using System;
using Alcotripnics.DAL.DataContext;
using Alcotripnics.DAL.Entity;
using Alcotripnics.DAL.Repository.Implementation;

namespace Alcotripnics.DAL.Repository.Implementation
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

