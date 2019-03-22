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
  public class ItemService : IMarketService<Item>
  {
    private ItemsContext _context;

    public ItemService(ItemsContext context)
    {
      _context = context;
    }

    public async Task<bool> Create(Item record)
    {
      _context.Items.Add(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(ItemService)}:Update");
        return false;
      }
    }

    public async Task<bool> Destroy(Item record)
    {
      _context.Items.Remove(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(ItemService)}:Destroy");
        return false;
      }
    }

    public async Task<IEnumerable<Item>> Find()
    {
      return await _context.Items.ToListAsync();
    }

    public async Task<Item> FindOne(int id)
    {
      return await _context.Items.FindAsync(id);
    }

    public async Task<bool> Update(Item record)
    {
      _context.Items.Update(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(ItemService)}:Update");
        return false;
      }
    }
  }
}