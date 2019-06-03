using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Infrastructure.Commands;
using TodoApp.Infrastructure.Services;

namespace TodoApp.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IToDoItemService _itemService;
        public ItemsController(IToDoItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{itemId}")]
        public async Task<IActionResult> GetById(Guid itemId)
        {
            var item = await _itemService.GetById(itemId);
            return Json(item);
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _itemService.GetAll();
            return Json(items);
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateItem(ToDoItemToAdd itemToAdd)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _itemService.AddToDoItem(itemToAdd);
            return StatusCode(201);
        }
        
        [HttpPut("{itemId}")]
        public async Task<IActionResult> UpdateItem(ToDoItemToAdd itemToAdd, Guid itemId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _itemService.Update(itemId, itemToAdd);
            return StatusCode(204);
        }
        
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> DeleteItem(Guid itemId)
        {
            await _itemService.Delete(itemId);
            return StatusCode(204);
        }
    }
}