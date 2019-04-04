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
  public class SoldItemService : IMarketService<SoldItem>
  {
    private ItemsContext _context;

    public SoldItemService(ItemsContext context)
    {
      _context = context;
    }

    public async Task<bool> Create(SoldItem record)
    {
      _context.SoldItems.Add(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(SoldItemService)}:Update");
        return false;
      }
    }

    public async Task<bool> Destroy(SoldItem record)
    {
      _context.SoldItems.Remove(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(SoldItemService)}:Destroy");
        return false;
      }
    }

    public async Task<IEnumerable<SoldItem>> Find()
    {
      return await _context.SoldItems.ToListAsync();
    }

    public async Task<SoldItem> FindOne(int id)
    {
      return await _context.SoldItems.FindAsync(id);
    }

    public async Task<bool> Update(SoldItem record)
    {
      _context.SoldItems.Update(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(SoldItemService)}:Update");
        return false;
      }
    }
  }
}