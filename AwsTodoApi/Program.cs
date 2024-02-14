
using AwsTodoApi.Data;
using AwsTodoApi.Repos;
using AwsTodoApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AwsTodoApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			var services = builder.Services;
			var config = builder.Configuration;

			services.AddAutoMapper(typeof(Program));
			services.AddScoped<ITodoRepo, TodoRepo>();
			services.AddScoped<ITodoService, TodoService>();
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddDbContext<AwsTodoContext>(options =>
			{
				string connectionString = config.GetConnectionString("Default") ?? throw new Exception("Connection string is empty");
				options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			});
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}