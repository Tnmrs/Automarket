
using Automarket.Domain.Entity;

namespace Automarket.Data.Interfaces
{
	public interface ICarRepository : IBaseRepository<Car>
	{
		Task<Car> GetByName(string name);
	}
}

