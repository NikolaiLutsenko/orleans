using Microsoft.Extensions.Logging;
using System;
using Test.Orleans.Interfaces;

namespace Test.Orleans.Services
{
	public class FakeUserRepo : IUserRepo
	{
		private readonly ILogger<FakeUserRepo> _logger;

		public FakeUserRepo(ILogger<FakeUserRepo> logger)
		{
			_logger = logger;
		}

		public void Call()
		{
			_logger.LogInformation("Call");
		}
	}
}
