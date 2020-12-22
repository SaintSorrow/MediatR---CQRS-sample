using MediatR;
using Sample.Domain.Interfaces;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.TodoItems.Commands.AddTodoItem
{
    public class AddTodoItemCommand : IRequest
    {
        public string Title { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset DueAt { get; set; }

        public class AddTodoItemCommandHandler
            : IRequestHandler<AddTodoItemCommand>
        {
            private readonly ITodoItemRepository _todoItemRepository;

            public AddTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
            {
                _todoItemRepository = todoItemRepository;
            }

            public async Task<Unit> Handle(AddTodoItemCommand request, CancellationToken cancellationToken)
            {
                var todoItem = new TodoItem(request.Title, request.UserId, request.DueAt);

                await _todoItemRepository.AddItemAsync(todoItem);

                return Unit.Value;
            }
        }
    }
}
