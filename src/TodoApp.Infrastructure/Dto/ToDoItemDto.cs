using System;

namespace TodoApp.Infrastructure.Dto
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}