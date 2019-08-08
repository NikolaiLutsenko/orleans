using Microsoft.Extensions.Logging;
using Orleans;
using System;
using System.Threading.Tasks;
using Test.Orleans.Interfaces;

namespace Test.Orleans.Actors
{
	public class UserActor : Grain, IUserActor
	{
		private readonly ILogger<UserActor> _logger;
		private Guid primaryKey;

		public UserActor(ILogger<UserActor> logger)
		{
			_logger = logger;
		}

		public Task<string> SayAsync(string msg)
		{
			return Task.FromResult($"Hi, my id is {primaryKey}");
		}

		public override Task OnActivateAsync()
		{
			primaryKey = this.GetPrimaryKey();
			return base.OnActivateAsync();
		}
	}
}
