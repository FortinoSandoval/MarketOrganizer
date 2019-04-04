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
  public class StoreService : IMarketService<Store>
  {
    private ItemsContext _context;

    public StoreService(ItemsContext context)
    {
      _context = context;
    }

    public async Task<bool> Create(Store record)
    {
      _context.Stores.Add(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(StoreService)}:Update");
        return false;
      }
    }

    public async Task<bool> Destroy(Store record)
    {
      _context.Stores.Remove(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(StoreService)}:Destroy");
        return false;
      }
    }

    public async Task<IEnumerable<Store>> Find()
    {
      return await _context.Stores.ToListAsync();
    }

    public async Task<Store> FindOne(int id)
    {
      return await _context.Stores.FindAsync(id);
    }

    public async Task<bool> Update(Store record)
    {
      _context.Stores.Update(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(StoreService)}:Update");
        return false;
      }
    }
  }
}