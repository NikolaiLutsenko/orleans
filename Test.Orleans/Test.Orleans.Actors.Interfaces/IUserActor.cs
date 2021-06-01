using Orleans;
using System.Threading.Tasks;

namespace Study.Orleans.Actors.Interfaces
{
	public interface IUserActor: IGrainWithGuidKey
	{
		Task SayAsync(string msg);
	}
}
