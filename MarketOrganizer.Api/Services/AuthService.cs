using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MarketOrganizer.Api.Interfaces;
using MarketOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using MarketOrganizer.Api.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MarketOrganizer.Api.Services
{
  public class AuthService : IAuthService<User>
  {
    private ItemsContext _context;
    private readonly AppSettings _appSettings;

    public AuthService(ItemsContext context, IOptions<AppSettings> appSettings)
    {
      _appSettings = appSettings.Value;
      _context = context;
    }

    public User Login(string username, string password)
    {
      var user = _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
      if (user == null)
      {
        return null;
      }
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
          }),
        Expires = DateTime.UtcNow.AddMinutes(5),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      user.Token = tokenHandler.WriteToken(token);
      user.Password = null;

      return user;
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