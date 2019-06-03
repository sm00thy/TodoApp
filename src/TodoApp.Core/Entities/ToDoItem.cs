namespace TodoApp.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        
    }
}