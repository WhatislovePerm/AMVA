using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Alcotripnics.Data.Entity;
using Alcotripnics.Models;

namespace Alcotripnics.Data.Entity
{
    [Table("Offer")]
    public class Offer
    {
        [Key]
        public long Id { get; set; }

        public Account Seller { get; set; }

        public Account Customer { get; set; }

        public Card Card { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfCreated { get; set; }

        public DateTime? DateOfFinishing { get; set; }
    }
}

