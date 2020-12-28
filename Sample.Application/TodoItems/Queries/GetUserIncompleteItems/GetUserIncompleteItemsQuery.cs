using MediatR;
using Sample.Domain.Interfaces;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.TodoItems.Queries.GetUserIncompleteItems
{
    public class GetUserIncompleteItemsQuery : IRequest<TodoItem[]>
    {
        public string UserId { get; set; }

        public GetUserIncompleteItemsQuery(string userId)
        {
            UserId = userId;
        }

        public class GetUserIncompleteItemsQueryHandler
            : IRequestHandler<GetUserIncompleteItemsQuery, TodoItem[]>
        {
            private readonly ITodoItemRepository _todoItemRepository;

            public GetUserIncompleteItemsQueryHandler(ITodoItemRepository todoItemRepository)
            {
                _todoItemRepository = todoItemRepository;
            }

            public async Task<TodoItem[]> Handle(GetUserIncompleteItemsQuery request, CancellationToken cancellationToken)
            {
                var items = await _todoItemRepository.GetUserIncompleteItemsAsync(request.UserId);

                return items;
            }
        }
    }
}
