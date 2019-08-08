using Orleans;
using System.Threading.Tasks;

namespace Test.Orleans.Interfaces
{
	public interface IUserActor: IGrainWithGuidKey
	{
		Task<string> SayAsync(string msg);
	}
}
