using System;
using Alcotripnics.Data.Entity;

namespace Alcotripnics.WebApp.Data.Repository
{
    public interface IAccountCardRepository : IBaseRepository<AccountCards>
    {
        Task<AccountCards> GetByCardAndAccountIds(long cardId, string accountId);

        Task<IEnumerable<AccountCards>> GetByAccountId(string accountId);

        Task<AccountCards> GetByCardAndAccountIdsForReturn(long cardId, string accountId);
    }
}

