using AwsTodoApi.Models.Dtos;

namespace AwsTodoApi.Services
{
	public interface ITodoService
	{
		Task<TodoDto> CreateAsync(TodoDto dto);
		Task<TodoDto> UpdateAsync(TodoDto dto);
		Task<TodoDto> GetByIdAsync(Guid id);
		Task<IEnumerable<TodoDto>> GetAllActiveAsync();
		Task<IEnumerable<TodoDto>> GetAllInactiveAsync();
	}
}
