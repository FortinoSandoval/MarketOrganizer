using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketOrganizer.Api.Interfaces
{
  public interface IAuthService<T>
  {
    Task<bool> Register(T user);
    Task<bool> UserExists(string username);
    // string Login(string username, string password);
  }
}