using Microsoft.Extensions.DependencyInjection;
using Test.Orleans.Interfaces;
using Test.Orleans.Services;

namespace Test.Orleans.Host.IoC
{
	class Module
	{
		public static void ConfigureHost(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IUserRepo, FakeUserRepo>();
		}
	}
}
