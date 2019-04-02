using System.Collections.Generic;
using System.Threading.Tasks;
using MarketOrganizer.Data.Models;

namespace MarketOrganizer.Api.Interfaces
{
  public interface IAuthService<T>
  {
    Task<bool> Register(T user);
    Task<bool> UserExists(string username);
    User Login(string username, string password);
  }
}