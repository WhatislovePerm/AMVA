using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Alcotripnics.DAL.Entity
{
    [Table("Card")]
    public class Card
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public long OwnerId { get; set; }

    }
}

