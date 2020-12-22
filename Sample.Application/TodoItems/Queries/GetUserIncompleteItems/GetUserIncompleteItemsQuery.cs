using MediatR;
using Sample.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.TodoItems.Queries.GetUserIncompleteItems
{
    public class GetUserIncompleteItemsQuery : IRequest<IEnumerable<TodoItemDto>>
    {
        public string UserId { get; set; }

        public GetUserIncompleteItemsQuery(string userId)
        {
            UserId = userId;
        }

        public class GetUserIncompleteItemsQueryHandler
            : IRequestHandler<GetUserIncompleteItemsQuery, IEnumerable<TodoItemDto>>
        {
            private readonly ITodoItemRepository _todoItemRepository;

            public GetUserIncompleteItemsQueryHandler(ITodoItemRepository todoItemRepository)
            {
                _todoItemRepository = todoItemRepository;
            }

            public async Task<IEnumerable<TodoItemDto>> Handle(GetUserIncompleteItemsQuery request, CancellationToken cancellationToken)
            {
                var items = await _todoItemRepository.GetUserIncompleteItemsAsync(request.UserId);
                var todoItems = new List<TodoItemDto>();

                foreach (var item in items)
                {
                    todoItems.Add(new TodoItemDto(item));
                }

                return todoItems;
            }
        }
    }
}
