using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MarketOrganizer.Api.Interfaces;
using MarketOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MarketOrganizer.Api.Services
{
  public class AuthService : IAuthService<User>
  {
    private ItemsContext _context;

    public AuthService(ItemsContext context)
    {
      _context = context;
    }

    public async Task<bool> Register(User user)
    {
      _context.Users.Add(user);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(AuthService)}:Update");
        return false;
      }
    }

    public async Task<bool> UserExists(string username)
    {
      if (await _context.Users.AnyAsync(x => x.Username == username))
      {
        return true;
      }
      return false;
    }
  }
}