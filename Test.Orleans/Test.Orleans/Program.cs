using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Providers;
using Orleans.MultiCluster;
using System;
using System.Threading.Tasks;
using Test.Orleans.Actors;
using Microsoft.Extensions.Logging;
using Test.Orleans.Host.IoC;

namespace Test.Orleans
{
	class Program
	{
		static int Main(string[] args)
		{
			return RunMainAsync().Result;
		}

		private static async Task<int> RunMainAsync()
		{
			try
			{
				var host = await StartSilo();
				Console.WriteLine("\n\n Press Enter to terminate...\n\n");
				Console.ReadLine();

				await host.StopAsync();
				return 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return 1;
			}
		}

		private static async Task<ISiloHost> StartSilo()
		{
			var connectionString = @"Data Source=10.0.77.1;Initial Catalog=OrleansCluster;User Id=SA;Password=Kolian12344321@;";
			// define the cluster configuration
			
			var invariant = "System.Data.SqlClient"; // for Microsoft SQL Server
			var siloHostBuilder = new SiloHostBuilder();
			siloHostBuilder.Configure<ClusterOptions>(options =>
			 {
				 options.ClusterId = "dev";
				 options.ServiceId = "OrleansServer";
			 });
			//use AdoNet for clustering 
			siloHostBuilder.UseAdoNetClustering(options =>
			{
				options.Invariant = invariant;
				options.ConnectionString = connectionString;
			});
			//use AdoNet for reminder service
			siloHostBuilder.UseAdoNetReminderService(options =>
			{
				options.Invariant = invariant;
				options.ConnectionString = connectionString;
			});
			//use AdoNet for Persistence
			siloHostBuilder.AddAdoNetGrainStorageAsDefault(options =>
			{
				options.Invariant = invariant;
				options.ConnectionString = connectionString;
			});
			siloHostBuilder.ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000);
			siloHostBuilder.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(UserActor).Assembly).WithReferences());
			siloHostBuilder.ConfigureLogging(logging => logging.AddConsole());
			siloHostBuilder.ConfigureServices(Module.ConfigureHost);

			var host = siloHostBuilder.Build();
			await host.StartAsync();
			return host;
		}
	}
}
