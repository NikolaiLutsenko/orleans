using System;
using System.Threading.Tasks;

namespace Test.Orleans.Interfaces
{
	public interface IUserRepo
	{
		Task CallAsync();
	}
}
