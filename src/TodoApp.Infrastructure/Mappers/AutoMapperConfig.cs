using AutoMapper;
using TodoApp.Core.Entities;
using TodoApp.Infrastructure.Dto;

namespace TodoApp.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
                    { cfg.CreateMap<ToDoItem, ToDoItemDto>(); })
                .CreateMapper();
    }
}