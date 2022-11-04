using System;
using Microsoft.AspNetCore.Identity;

namespace Alcotripnics.Models
{
    public class ChangeRoleViewModel
    {
        public string AccountId { get; set; }

        public string Login { get; set; }

        public List<IdentityRole> AllRoles { get; set; }

        public IList<string> AccountRoles { get; set; }

        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            AccountRoles = new List<string>();
        }
    }
}

