using MediatR;
using Sample.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.TodoItems.Commands.MarkDone
{
    public class MarkDoneCommand : IRequest<Unit>
    {
        public Guid TodoItemId { get; set; }

        public class MarkDoneCommandHandler : IRequestHandler<MarkDoneCommand, Unit>
        {
            private ITodoItemRepository _todoItemRepository;

            public MarkDoneCommandHandler(ITodoItemRepository todoItemRepository)
            {
                _todoItemRepository = todoItemRepository;
            }

            public async Task<Unit> Handle(MarkDoneCommand request, CancellationToken cancellationToken)
            {
                await _todoItemRepository.MarkDoneAsync(request.TodoItemId);

                return Unit.Value;
            }
        }
    }
}
