using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketOrganizer.Api.Interfaces;
using MarketOrganizer.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketOrganizer.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly IAuthService<User> _userService;

    public UsersController(IAuthService<User> userService)
    {
      _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User user)
    {
      if (await _userService.UserExists(user.Username))
      {
        return BadRequest("User already exist");
      }
      if (user.Username == null || user.Password == null) return BadRequest("invalid username/password");
      var result = await _userService.Register(user);
      if (result)
      {
        return Created("api/Users", user);
      }
      return BadRequest();
    }
  }
}