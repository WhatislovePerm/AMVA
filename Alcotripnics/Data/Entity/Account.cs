using System;
using Microsoft.AspNetCore.Identity;

namespace Alcotripnics.Data.Entity
{
    public class Account : IdentityUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public decimal MoneyAmount { get; set; }

        public List<AccountCards> AccountCards { get; set; } = new(); 
    }
}

