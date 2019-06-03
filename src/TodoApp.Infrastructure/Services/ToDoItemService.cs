using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TodoApp.Core.Entities;
using TodoApp.Infrastructure.Commands;
using TodoApp.Infrastructure.Dto;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Infrastructure.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IRepository<ToDoItem> _itemRepository;
        private readonly IMapper _mapper;
        public ToDoItemService(IRepository<ToDoItem> itemRepository,
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;

        }
        
        public async Task<ToDoItemDto> GetById(Guid itemId)
        {
            var item = await _itemRepository.GetById(itemId);
            return _mapper.Map<ToDoItemDto>(item);
        }

        public async Task<IEnumerable<ToDoItemDto>> GetAll()
        {
            var items = await _itemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToDoItemDto>>(items);
        }

        public async Task AddToDoItem(ToDoItemToAdd toDoItemToAdd)
        {
            var item = new ToDoItem {
                Text = toDoItemToAdd.Text,
                IsCompleted = toDoItemToAdd.IsCompleted
            };
            await _itemRepository.AddAsync(item);
        }

        public async Task Update(Guid itemId, ToDoItemToAdd toDoItem)
        {
            var item = await _itemRepository.GetById(itemId);
            if(item == null)
                throw new Exception($"Item with id: {itemId} doesn't exist.");
            item.Text = toDoItem.Text;
            item.IsCompleted = toDoItem.IsCompleted;
            await _itemRepository.UpdateAsync(item);
        }

        public async Task Delete(Guid itemId)
        {
            var @item = await _itemRepository.GetById(itemId);
                
            await _itemRepository.DeleteAsync(@item);
        }
    }
}