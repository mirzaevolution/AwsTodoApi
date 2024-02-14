using AwsTodoApi.Data;
using AwsTodoApi.Models.Entities;
using AwsTodoApi.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace AwsTodoApi.Repos
{
	public class TodoRepo : ITodoRepo
	{
		private readonly AwsTodoContext _context;

		public TodoRepo(AwsTodoContext context)
		{
			_context = context;
		}

		public async Task<TodoEntity> CreateAsync(TodoEntity entity)
		{
			_context.Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<TodoEntity> UpdateAsync(TodoEntity entity)
		{
			if (!_context.Todos.Local.Contains(entity))
			{
				_context.Attach(entity);
			}
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<IEnumerable<TodoEntity>> GetAllActiveAsync()
		{
			IEnumerable<TodoEntity> entities = await _context.Todos.Where(c => c.Status == TodoStatus.Active).ToListAsync();
			return entities == null ? Enumerable.Empty<TodoEntity>() : entities;
		}

		public async Task<IEnumerable<TodoEntity>> GetAllInactiveAsync()
		{
			IEnumerable<TodoEntity> entities = await _context.Todos.Where(c => c.Status == TodoStatus.Inactive).ToListAsync();
			return entities == null ? Enumerable.Empty<TodoEntity>() : entities;
		}

		public async Task<TodoEntity> GetByIdAsync(Guid id)
		{
			TodoEntity? entity =
				await _context.Todos.FindAsync(id);
			return entity;
		}
	}
}