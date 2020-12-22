using Microsoft.EntityFrameworkCore;
using Sample.Domain.Interfaces;
using Sample.Domain.Models;
using Sample.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(TodoItem newItem)
        {
            await this._context.Items.AddAsync(newItem);
        }

        public async Task<IEnumerable<TodoItem>> GetUserIncompleteItemsAsync(string userId)
        {
            var items = await _context.Items
                .Where(x => x.IsDone == false && x.UserId == userId)
                .ToListAsync();

            return items;
        }

        public async Task MarkDoneAsync(Guid id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);

            item.IsDone = true;

            await _context.SaveChangesAsync();
        }
    }
}
