using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alcotripnics.DAL.Entity
{
    [Table("Account")]
    public class Account
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

