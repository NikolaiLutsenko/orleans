using Microsoft.Extensions.Logging;
using Orleans;
using System;
using System.Threading.Tasks;
using Test.Orleans.Actors.Interfaces;
using Test.Orleans.Interfaces;

namespace Test.Orleans.Actors
{
	public class UserActor : Grain, IUserActor
	{
		private readonly ILogger<UserActor> _logger;
		private readonly IUserRepo _userRepo;
		private Guid primaryKey;

		public UserActor(IUserRepo userRepo, ILogger<UserActor> logger)
		{
			_logger = logger;
			_userRepo = userRepo;
		}

		public Task<string> SayAsync(string msg)
		{
			_userRepo.Call();
			var testMsg = $"Hi, my id is [{primaryKey}] and I'm talking about {msg}";
			_logger.LogInformation(testMsg);
			return Task.FromResult(testMsg);
		}

		public override Task OnActivateAsync()
		{
			primaryKey = this.GetPrimaryKey();
			return base.OnActivateAsync();
		}
	}
}
