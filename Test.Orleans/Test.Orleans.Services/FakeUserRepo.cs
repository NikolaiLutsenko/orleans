using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Study.Orleans.Interfaces;

namespace Study.Orleans.Services
{
	public class FakeUserRepo : IUserRepo
	{
		private readonly ILogger<FakeUserRepo> _logger;

		public FakeUserRepo(ILogger<FakeUserRepo> logger)
		{
			_logger = logger;
		}

		public Task CallAsync()
		{
			_logger.LogInformation("Call");
			return Task.CompletedTask;
		}
	}
}
