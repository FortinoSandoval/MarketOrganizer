using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketOrganizer.Api.Interfaces;
using MarketOrganizer.Api.Services;
using MarketOrganizer.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketOrganizer.Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly IMarketService<Item> _itemService;

    public ItemsController(IMarketService<Item> itemService)
    {
      _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var items = await _itemService.Find();
      return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var item = await _itemService.FindOne(id);
      if (item != null)
      {
        return Ok(item);
      }
      return NotFound("Item not found");
    }

    [HttpPost]
    public async Task<IActionResult> Post(Item item)
    {
      var result = await _itemService.Create(item);
      if (result)
      {
        return Created("api/Items", item);
      }
      return BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      Item itemToRemove = await _itemService.FindOne(id);
      if (itemToRemove != null)
      {
        await _itemService.Destroy(itemToRemove);
        return NoContent();
      }
      return NotFound("Item not found");
    }

    [HttpPut]
    public async Task<IActionResult> Update(Item item)
    {
      if (item == null) return NotFound("Item not found");
      var result = await _itemService.Update(item);
      if (result)
      {
        return Ok(item);
      }
      return BadRequest();
    }

  }
}