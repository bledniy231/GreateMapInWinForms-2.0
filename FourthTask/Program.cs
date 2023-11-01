using FirstTask;
using FourthTask.BackgroundServices;
using FourthTask.BLL;
using FourthTask.DAL;
using FourthTask.Forms;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using WindowsFormsLifetime;

namespace FourthTask
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		//[STAThread]
		static void Main()
		{
			var builder = Host.CreateDefaultBuilder()
				.UseWindowsFormsLifetime<MainForm>()
				.ConfigureAppConfiguration((ctx, cfg) =>
				{
					cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				})
				.ConfigureDbContext();

			builder.ConfigureServices(s =>
			{
				s.ConfigureBLL()
				.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
				.AddTransient<MarkerInfoForm>()
				.AddSingleton<NmeaParser>()
				.AddHostedService<GpggaGenerator>()
				.AddSingleton<OverlaysCreator>()
				.AddSingleton<CancellationTokenSourcesFactory>();
			});


			var host = builder.Build();

			host.Services.MigrateDbContext();

			host.Run();
		}
	}
}