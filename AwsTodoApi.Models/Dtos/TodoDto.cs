using AwsTodoApi.Models.Enums;

namespace AwsTodoApi.Models.Dtos
{
	public class TodoDto
	{
		public Guid Id { get; set; }
		public required string Title { get; set; }
		public string? Description { get; set; }
		public DateTime ModifiedTimeUtc { get; set; } = DateTime.UtcNow;
		public TodoStatus Status { get; set; } = TodoStatus.Active;

	}
}
