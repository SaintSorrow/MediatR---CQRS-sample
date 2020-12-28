using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain.ViewModels
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set; }
    }
}
