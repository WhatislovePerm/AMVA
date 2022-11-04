using System;
using Alcotripnics.Data.Entity;
using Alcotripnics.WebApp.Enums;

namespace Alcotripnics.WebApp.Data.Repository
{
    public interface ICardRepository : IBaseRepository<Card>
    {
        Task<Card> GetById(long id);

        Task<IEnumerable<Card>> GetCardsWithRarity(CardRarityEnum cardRarityEnum);

    }
}
