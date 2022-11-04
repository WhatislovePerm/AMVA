using System;
using Alcotripnics.DAL.DataContext;
using Alcotripnics.DAL.Entity;

namespace Alcotripnics.DAL.Repository.Implementation
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    { 
        public CardRepository(ApplicationDbContext context) : base(context)
        {
        
        }
    }
}

