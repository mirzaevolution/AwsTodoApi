using AwsTodoApi.Models.Entities;

namespace AwsTodoApi.Repos
{
	public interface ITodoRepo
	{
		Task<TodoEntity> CreateAsync(TodoEntity entity);
		Task<TodoEntity> UpdateAsync(TodoEntity entity);
		Task<TodoEntity> GetByIdAsync(Guid id);
		Task<IEnumerable<TodoEntity>> GetAllActiveAsync();
		Task<IEnumerable<TodoEntity>> GetAllInactiveAsync();
	}
}
