using System;
using Alcotripnics.Data.Entity;
using Alcotripnics.WebApp.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Alcotripnics.WebApp.Data.Repository.Implementation
{
    public class AccountCardRepository : BaseRepository<AccountCards>, IAccountCardRepository
    {
        public AccountCardRepository(ApplicationDbContext applicationDbContext) : base (applicationDbContext)
        {

        }

        public async Task<AccountCards> GetByCardAndAccountIds(long cardId, string accountId) =>
            await db.Set<AccountCards>().Where(x => x.AccountId == accountId && x.CardId == cardId && x.DateOfDelete == null).FirstOrDefaultAsync();

        public async Task<IEnumerable<AccountCards>> GetByAccountId(string accountId) =>
            await db.Set<AccountCards>().Where(x => x.AccountId == accountId && x.DateOfDelete == null).ToListAsync();

        public async Task<AccountCards> GetByCardAndAccountIdsForReturn(long cardId, string accountId) =>
            await db.Set<AccountCards>().Where(x => x.AccountId == accountId && x.CardId == cardId && x.DateOfDelete != null).FirstOrDefaultAsync();


    }
}

