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
  public class StoreItemService : IMarketService<StoreItem>
  {
    private ItemsContext _context;

    public StoreItemService(ItemsContext context)
    {
      _context = context;
    }

    public async Task<bool> Create(StoreItem record)
    {
      _context.StoreItems.Add(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(StoreItemService)}:Update");
        return false;
      }
    }

    public async Task<bool> Destroy(StoreItem record)
    {
      _context.StoreItems.Remove(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(StoreItemService)}:Destroy");
        return false;
      }
    }

    public async Task<IEnumerable<StoreItem>> Find()
    {
      return await _context.StoreItems.ToListAsync();
    }

    public async Task<StoreItem> FindOne(int id)
    {
      return await _context.StoreItems.FindAsync(id);
    }

    public async Task<bool> Update(StoreItem record)
    {
      _context.StoreItems.Update(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(StoreItemService)}:Update");
        return false;
      }
    }
  }
}