using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alcotripnics.Data.Entity
{
    [Table("AccountCards")]
    public class AccountCards
    {
        [Key]
        public long Id { get; set; }

        public string AccountId { get; set; }

        public long CardId { get; set; }

        public DateTime? DateOfDelete { get; set; }

        public Account Account { get; set; }

        public Card Card { get; set; }

    }
}

