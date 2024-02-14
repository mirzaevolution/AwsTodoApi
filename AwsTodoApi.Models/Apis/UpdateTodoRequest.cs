using AwsTodoApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AwsTodoApi.Models.Apis
{
	public class UpdateTodoRequest
	{
		[Required]
		public Guid Id { get; set; }

		[Required]
		[MinLength(3), MaxLength(100)]
		public required string Title { get; set; }

		[MaxLength(255)]
		public string? Description { get; set; }

		public TodoStatus Status { get; set; } = TodoStatus.Active;

	}
}
