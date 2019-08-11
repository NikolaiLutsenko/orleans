using Orleans;
using Orleans.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Test.Orleans.Actors.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Globalization;
using Orleans.Hosting;

namespace Test.Orleans.Client.Host
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
				var services = new ServiceCollection();
				await Task.Delay(10000);
				using (var client = await GetConnectClient())
				{
					await DoClientWork(client);
					Console.ReadKey();
				}

				return 0;
			}
			catch (Exception e)
			{
				Console.WriteLine($"\nException while trying to run client: {e.Message}");
				Console.WriteLine("Make sure the silo the client is trying to connect to is running.");
				Console.WriteLine("\nPress any key to exit.");
				Console.ReadKey();
				return 1;
			}
		}

		private static async Task<IClusterClient> GetConnectClient()
		{
			var connectionString = "Data Source=10.0.77.1;Initial Catalog=OrleansCluster;User Id=SA;Password=Kolian12344321@;";
			var client = new ClientBuilder()
				.Configure<ClusterOptions>(options =>
				{
					options.ClusterId = "dev";
					options.ServiceId = "OrleansBasics";
				})
				.UseAdoNetClustering(options =>
				{
					options.ConnectionString = connectionString;
					options.Invariant = "System.Data.SqlClient";
				})
				.ConfigureLogging(logging => logging.AddConsole())
				.Build();

			await client.Connect();
			Console.WriteLine("Client successfully connected to silo host \n");
			return client;
		}

		private static async Task DoClientWork(IClusterClient client)
		{
			// example of calling grains from the initialized client
			var userId = Guid.NewGuid();
			var firstCall = client.GetGrain<IUserActor>(userId);
			var secondCall = client.GetGrain<IUserActor>(userId);
			await firstCall.SayAsync("Good morning, HelloGrain!");
			await secondCall.SayAsync("Good morning, HelloGrain2!");
		}
	}
}
