using AwsTodoApi.Models.Enums;

namespace AwsTodoApi.Models.Entities
{
	public class TodoEntity
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public required string Title { get; set; }
		public string? Description { get; set; }
		public DateTime ModifiedTimeUtc { get; set; } = DateTime.UtcNow;

		public TodoStatus Status { get; set; } = TodoStatus.Active;
	}
}
