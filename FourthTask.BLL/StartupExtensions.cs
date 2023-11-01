﻿using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace FourthTask.BLL
{
	public static class StartupExtensions
	{
		public static IServiceCollection ConfigureBLL(this IServiceCollection services)
			=> services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(StartupExtensions).Assembly));
	}
}