using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Application.TodoItems
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        public DateTimeOffset DueAt { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }

        public TodoItemDto(TodoItem todoItem)
        {
            Id = todoItem.Id;
            IsDone = todoItem.IsDone;
            DueAt = todoItem.DueAt;
            UserId = todoItem.UserId;
            Title = todoItem.Title;
        }
    }
}
