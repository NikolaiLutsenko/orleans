using Microsoft.Extensions.Logging;
using Orleans;
using System;
using System.Threading.Tasks;
using Study.Orleans.Actors.Interfaces;
using Study.Orleans.Actors.States;
using Study.Orleans.Interfaces;

namespace Study.Orleans.Actors
{
	public class UserActor : Grain<UserState>, IUserActor
	{
		private readonly ILogger<UserActor> _logger;
		private readonly IUserRepo _userRepo;
		private Guid primaryKey;

		public UserActor(IUserRepo userRepo, ILogger<UserActor> logger)
		{
			_logger = logger;
			_userRepo = userRepo;
		}

		public async Task SayAsync(string msg)
		{
			State.CallNumber++;
			await this.WriteStateAsync();
			await _userRepo.CallAsync();
			_logger.LogInformation($"Hi, my id is [{primaryKey}], it's call number [{State.CallNumber}] and I'm talking about {msg}");
		}

		public override Task OnActivateAsync()
		{
			primaryKey = this.GetPrimaryKey();
			return base.OnActivateAsync();
		}
	}
}
