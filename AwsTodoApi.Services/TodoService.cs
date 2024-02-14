using AutoMapper;
using AwsTodoApi.Models.Dtos;
using AwsTodoApi.Models.Entities;
using AwsTodoApi.Repos;

namespace AwsTodoApi.Services
{
	public class TodoService : ITodoService
	{
		private readonly ITodoRepo _repo;
		private readonly IMapper _mapper;

		public TodoService(
				ITodoRepo todoRepo,
				IMapper mapper
			)
		{
			_repo = todoRepo;
			_mapper = mapper;
		}

		public async Task<TodoDto> CreateAsync(TodoDto dto)
		{
			TodoEntity entity = _mapper.Map<TodoEntity>(dto);
			entity = await _repo.CreateAsync(entity);
			dto = _mapper.Map<TodoDto>(entity);
			return dto;
		}

		public async Task<TodoDto> UpdateAsync(TodoDto dto)
		{
			TodoEntity entity = await _repo.GetByIdAsync(dto.Id);
			if (entity == null)
			{
				throw new Exception("Data not found");
			}
			if (entity.Title != dto.Title)
			{
				entity.Title = dto.Title;
			}
			if (entity.Description != dto.Description)
			{
				entity.Description = dto.Description;
			}
			if (entity.Status != dto.Status)
			{
				entity.Status = dto.Status;
			}
			entity.ModifiedTimeUtc = DateTime.UtcNow;
			await _repo.UpdateAsync(entity);
			dto = _mapper.Map<TodoDto>(entity);
			return dto;
		}

		public async Task<IEnumerable<TodoDto>> GetAllActiveAsync()
		{
			IEnumerable<TodoEntity> entities =
				await _repo.GetAllActiveAsync();
			IEnumerable<TodoDto> dtos = _mapper.Map<IEnumerable<TodoDto>>(entities);
			return dtos;
		}

		public async Task<IEnumerable<TodoDto>> GetAllInactiveAsync()
		{
			IEnumerable<TodoEntity> entities =
				await _repo.GetAllActiveAsync();
			IEnumerable<TodoDto> dtos = _mapper.Map<IEnumerable<TodoDto>>(entities);
			return dtos;
		}

		public async Task<TodoDto> GetByIdAsync(Guid id)
		{
			TodoEntity entity = await _repo.GetByIdAsync(id);
			if (entity == null)
			{
				throw new Exception("Data not found");
			}

			TodoDto dto = _mapper.Map<TodoDto>(entity);
			return dto;
		}
	}
}