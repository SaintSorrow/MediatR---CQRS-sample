using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models;
using Sample.Domain.Roles;
using Sample.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Presentation.Controllers
{
    [Authorize(Roles = RoleNames.Administrator)]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ManageUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager
                .GetUsersInRoleAsync(RoleNames.Administrator))
                .ToArray();

            var everyone = await _userManager.Users
                .ToArrayAsync();

            var viewModel = new ManageUsersViewModel
            {
                Administrators = admins,
                Everyone = everyone
            };

            return View(viewModel);
        }
    }
}
