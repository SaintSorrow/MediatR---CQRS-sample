using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.TodoItems.Commands.AddTodoItem;
using Sample.Application.TodoItems.Commands.MarkDone;
using Sample.Application.TodoItems.Queries.GetUserIncompleteItems;
using Sample.Domain.Models;
using Sample.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Presentation.Controllers
{
    [Authorize]
    public class TodoItemController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public TodoItemController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var query = new GetUserIncompleteItemsQuery(currentUser.Id);
            var result = await _mediator.Send(query);

            var viewModel = new TodoViewModel()
            {
                Items = result
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AddItem(AddTodoItemCommand command)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            command.UserId = currentUser.Id;

            await _mediator.Send(command);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MarkDone([FromBody]MarkDoneCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction("Index");
        }
    }
}
