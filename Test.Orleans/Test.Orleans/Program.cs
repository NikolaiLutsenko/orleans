﻿using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using System;
using System.Threading.Tasks;
using Test.Orleans.Actors;
using Microsoft.Extensions.Logging;

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
			// define the cluster configuration
			var builder = new SiloHostBuilder()
				.UseLocalhostClustering()
				.Configure<ClusterOptions>(options =>
				{
					options.ClusterId = "dev";
					options.ServiceId = "OrleansBasics";
				})
				.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(UserActor).Assembly).WithReferences())
				.ConfigureLogging(logging => logging.AddConsole());

			var host = builder.Build();
			await host.StartAsync();
			return host;
		}
	}
}
