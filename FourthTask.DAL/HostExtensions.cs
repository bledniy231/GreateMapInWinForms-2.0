using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FourthTask.DAL
{
	public static class HostExtensions
	{
		public static IHostBuilder ConfigureDbContext(this IHostBuilder hostBuilder)
			=> hostBuilder.ConfigureServices((ctx, s) =>
			{
				s.AddDbContext<FourthTaskDbContext>((sp, opt) =>
				{
					opt.UseSqlServer(ctx.Configuration.GetConnectionString("FourthTaskDbConnectionString"));
				});
			});

		public static IServiceProvider MigrateDbContext(this IServiceProvider services)
		{
			using var scope = services.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<FourthTaskDbContext>();
			dbContext.Database.Migrate();
			return services;
		}
	}
}
