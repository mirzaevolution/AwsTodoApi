using AwsTodoApi.Data.EntityTypeConfigurations;
using AwsTodoApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwsTodoApi.Data
{
	public class AwsTodoContext : DbContext
	{
		public AwsTodoContext(DbContextOptions<AwsTodoContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new TodoEntityTypeConfiguration());
		}

		public virtual DbSet<TodoEntity> Todos { get; set; }
	}
}
