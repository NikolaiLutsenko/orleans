using Microsoft.Extensions.DependencyInjection;
using Study.Orleans.Interfaces;
using Study.Orleans.Services;

namespace Study.Orleans.Host.IoC
{
	class Module
	{
		public static void ConfigureHost(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IUserRepo, FakeUserRepo>();
		}
	}
}
