using System.Threading.Tasks;

namespace Simon.Domain.Process
{
	public interface IProcess<TDomain>
	{
		Task<TDomain> ProcessAsync();
	}
}