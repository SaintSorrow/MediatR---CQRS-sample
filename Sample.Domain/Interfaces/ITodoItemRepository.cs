using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<TodoItem[]> GetUserIncompleteItemsAsync(string userId);
        Task AddItemAsync(TodoItem newItem);
        Task MarkDoneAsync(Guid id);
    }
}
