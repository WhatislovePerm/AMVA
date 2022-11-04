using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Alcotripnics.WebApp.Enums;
using Microsoft.EntityFrameworkCore;

namespace Alcotripnics.Data.Entity
{
    [Table("Card")]
    public class Card
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public CardRarityEnum CardRarityEnum { get; set; }

        public List<Offer> Offers { get; set; } = new();

        public List<AccountCards> AccountCards { get; set; } = new();

    }
}

