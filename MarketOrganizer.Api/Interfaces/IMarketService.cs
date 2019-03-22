using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketOrganizer.Api.Interfaces
{
  public interface IMarketService<T>
  {
    Task<IEnumerable<T>> Find();
    Task<T> FindOne(int id);
    Task<bool> Create(T record);
    Task<bool> Update(T record);
    Task<bool> Destroy(T record);
  }
}