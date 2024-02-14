using AutoMapper;
using AwsTodoApi.Models.Apis;
using AwsTodoApi.Models.Dtos;
using AwsTodoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwsTodoApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodosController : ControllerBase
	{
		private readonly ITodoService _todoService;
		private readonly IMapper _mapper;

		public TodosController(
				ITodoService todoService,
				IMapper mapper
			)
		{
			_todoService = todoService;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> Post(
				[FromBody] CreateTodoRequest request
			)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var dto = _mapper.Map<TodoDto>(request);
			dto = await _todoService.CreateAsync(dto);
			return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
		}

		[HttpPut]
		public async Task<IActionResult> Put(
				[FromBody] UpdateTodoRequest request
			)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var dto = _mapper.Map<TodoDto>(request);
			dto = await _todoService.UpdateAsync(dto);
			return Ok(dto);
		}

		[HttpGet("{id}", Name = "GetById")]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			var dto = await _todoService.GetByIdAsync(id);
			return Ok(dto);
		}

		[HttpGet("active", Name = "GetAllActive")]
		public async Task<IActionResult> GetAllActive()
		{
			var list = await _todoService.GetAllActiveAsync();
			return Ok(list);
		}

		[HttpGet("inactive", Name = "GetAllInactive")]
		public async Task<IActionResult> GetAllInactive()
		{
			var list = await _todoService.GetAllInactiveAsync();
			return Ok(list);
		}
	}
}
