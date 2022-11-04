using System;
using Alcotripnics.Data.Entity;

namespace Alcotripnics.Models
{
    public class OfferViewModel
    {
        public long SellerId { get; set; }

        public long Price { get; set; }

        public CardViewModel Card { get; set;} 

        public DateTime DateOfCreated { get; set; }

        public DateTime? DateOfFinishing { get; set; }

    }
}
