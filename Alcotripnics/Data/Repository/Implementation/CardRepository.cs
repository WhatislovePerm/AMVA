using System;
using Alcotripnics.WebApp.Data.DataContext;
using Alcotripnics.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Alcotripnics.WebApp.Enums;

namespace Alcotripnics.WebApp.Data.Repository.Implementation
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(ApplicationDbContext context) : base(context)
        { }

        public async Task<Card> GetById(long id)
            => await db.Set<Card>().Where(c => c.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Card>> GetCardsWithRarity(CardRarityEnum cardRarityEnum)
            => await db.Set<Card>().Where(x => x.CardRarityEnum == cardRarityEnum).ToListAsync();
    }
}

