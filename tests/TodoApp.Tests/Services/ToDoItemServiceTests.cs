using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using TodoApp.Core.Entities;
using TodoApp.Infrastructure.Commands;
using TodoApp.Infrastructure.Dto;
using TodoApp.Infrastructure.Repositories;
using TodoApp.Infrastructure.Services;
using Xunit;

namespace TodoApp.Tests.Services
{
    public class ToDoItemServiceTests
    {
        [Fact]
        public async Task When_adding_new_todoItem_it_should_invoke_add_async_on_repository()
        {
            //Arrange
            var todoRepositoryMock = new Mock<IRepository<ToDoItem>>();
            var mapperMock = new Mock<IMapper>();
            var itemService = new ToDoItemService(todoRepositoryMock.Object, mapperMock.Object);
            var itemCommandToAdd = new ToDoItemToAdd
            {
                Text = "Sample text"
            };
            
            //Act
            await itemService.AddToDoItem(itemCommandToAdd);

            //Assert
            todoRepositoryMock.Verify(x => x.AddAsync(It.IsAny<ToDoItem>()), Times.Once());
        }
        
        [Fact]
        public async Task When_invoking_get_async_it_should_invoke_get_async_on_repository()
        {
            //Arrange
            var todoItem = new ToDoItem
            {
                Text = "Sample text", 
                IsCompleted = true
            };
            var toDoItemDto = new ToDoItemDto
            {
                Id = todoItem.Id,
                Text = todoItem.Text,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt
            };
            var todoRepositoryMock = new Mock<IRepository<ToDoItem>>();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<ToDoItemDto>(todoItem));
            var itemService = new ToDoItemService(todoRepositoryMock.Object, mapperMock.Object);

            todoRepositoryMock.Setup(x => x.GetById(todoItem.Id)).ReturnsAsync(todoItem);

            //Act
            var existToDoItemDto = await itemService.GetById(todoItem.Id);

            //Assert
            todoRepositoryMock.Verify(x => x.GetById(todoItem.Id), Times.Once());
            toDoItemDto.Should().NotBeNull();
            toDoItemDto.Text.Should().BeEquivalentTo(todoItem.Text);
            toDoItemDto.IsCompleted.Should().Be(todoItem.IsCompleted);
            todoItem.Id.Should().Be(todoItem.Id);
        }
    }
}