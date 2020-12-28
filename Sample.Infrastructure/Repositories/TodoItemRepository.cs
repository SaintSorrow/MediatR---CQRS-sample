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
            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem[]> GetUserIncompleteItemsAsync(string userId)
        {
            var items = await _context.Items
                .Where(x => x.IsDone == false && x.UserId == userId)
                .ToArrayAsync();

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
