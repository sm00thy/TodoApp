using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Infrastructure.Commands;
using TodoApp.Infrastructure.Dto;

namespace TodoApp.Infrastructure.Services
{
    public interface IToDoItemService
    {
        Task<ToDoItemDto> GetById(Guid itemId);
        Task<IEnumerable<ToDoItemDto>> GetAll();
        Task AddToDoItem(ToDoItemToAdd toDoItemToAdd);
        Task Update(Guid itemId, ToDoItemToAdd toDoItem);
        Task Delete(Guid itemId);
    }
}