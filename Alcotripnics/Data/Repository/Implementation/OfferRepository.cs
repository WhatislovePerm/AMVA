using System;
using Alcotripnics.Data.Entity;
using Alcotripnics.WebApp.Data.DataContext;
using Alcotripnics.WebApp.Data.Repository;
using Alcotripnics.WebApp.Data.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Alcotripnics.Data.Repository.Implementation
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {}

        public async Task<IEnumerable<Offer>> GetAllNotFinished() =>
             await db.Set<Offer>().Include(x => x.Card).Include(x => x.Seller).Where(x => x.DateOfFinishing == null).ToListAsync();

        public async Task<Offer> GetById(long id) =>
            await db.Set<Offer>()
            .Include(x => x.Card)
            .Include(x => x.Seller)
            .Where(x => x.DateOfFinishing == null)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();


    }

}