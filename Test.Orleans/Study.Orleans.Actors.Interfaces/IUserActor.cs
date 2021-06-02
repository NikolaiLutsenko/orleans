using Orleans;
using Study.Orleans.Actors.Interfaces.Models;
using System.Threading.Tasks;

namespace Study.Orleans.Actors.Interfaces
{
	public interface IUserActor: IGrainWithGuidKey
	{
		Task SayAsync(string msg);
	}
}
