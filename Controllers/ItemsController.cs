using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private readonly ItemsContext _Context;

    public ItemsController(ItemsContext _context)
    {
      _Context = _context;
    }
    [HttpGet]
    public IActionResult Get()
    {
      var items = _Context.Item.ToList();
      return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Items item)
    {
      _Context.Add(item);
      await _Context.SaveChangesAsync();
      return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      Items itemToRemove = _Context.Item.SingleOrDefault(x => x.Id == id);
      if (itemToRemove != null)
      {
        _Context.Item.Remove(itemToRemove);
        await _Context.SaveChangesAsync();
        return Ok();
      }
      return NotFound("Item not found");
    }

    [HttpPut]
    public async Task<IActionResult> Update(Items item)
    {
      if (item == null) return NotFound("Item not found");
      _Context.Entry(item).State = EntityState.Modified;
      await _Context.SaveChangesAsync();
      return Ok(item);
    }

  }
}