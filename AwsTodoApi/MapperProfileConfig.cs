using AutoMapper;
using AwsTodoApi.Models.Apis;
using AwsTodoApi.Models.Dtos;
using AwsTodoApi.Models.Entities;

namespace AwsTodoApi
{
	public class MapperProfileConfig : Profile
	{
		public MapperProfileConfig()
		{
			MapTodos();
		}

		private void MapTodos()
		{
			CreateMap<CreateTodoRequest, TodoDto>();
			CreateMap<UpdateTodoRequest, TodoDto>();
			CreateMap<TodoDto, TodoEntity>().ReverseMap();
		}
	}
}
