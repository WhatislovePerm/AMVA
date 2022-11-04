using System;
using Alcotripnics.Data.Entity;

namespace Alcotripnics.WebApp.Data.Repository
{
    public interface IOfferRepository : IBaseRepository<Offer>
    {
        public Task<IEnumerable<Offer>> GetAllNotFinished();

        public Task<Offer> GetById(long id);
    }
}

