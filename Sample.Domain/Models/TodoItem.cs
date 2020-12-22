using Sample.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.Domain.Models
{
    public class TodoItem
    {
        public Guid Id { get; }

        public bool IsDone { get; set; }

        public DateTimeOffset DueAt { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        public TodoItem(string title, string userId, DateTimeOffset dueAt)
        {
            Id = Guid.NewGuid();
            IsDone = false;
            DueAt = dueAt;
            UserId = userId;
            Title = title;
        }
    }
}
