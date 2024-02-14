using AwsTodoApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwsTodoApi.Data.EntityTypeConfigurations
{
	public class TodoEntityTypeConfiguration : IEntityTypeConfiguration<TodoEntity>
	{
		public void Configure(EntityTypeBuilder<TodoEntity> builder)
		{
			builder.ToTable("Todos");
			builder.HasKey(c => c.Id);
			builder.Property(c => c.Title)
				.HasMaxLength(100)
				.IsRequired();
			builder.Property(c => c.Description)
				.HasMaxLength(255);
			builder.HasIndex(c => c.Status);
		}
	}
}
