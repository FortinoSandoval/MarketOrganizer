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
  public class CartService : IMarketService<Cart>
  {
    private ItemsContext _context;

    public CartService(ItemsContext context)
    {
      _context = context;
    }

    public async Task<bool> Create(Cart record)
    {
      _context.Carts.Add(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(CartService)}:Update");
        return false;
      }
    }

    public async Task<bool> Destroy(Cart record)
    {
      _context.Carts.Remove(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(CartService)}:Destroy");
        return false;
      }
    }

    public async Task<IEnumerable<Cart>> Find()
    {
      return await _context.Carts.ToListAsync();
    }

    public async Task<Cart> FindOne(int id)
    {
      return await _context.Carts.FindAsync(id);
    }

    public async Task<bool> Update(Cart record)
    {
      _context.Carts.Update(record);
      try
      {
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message, $"{typeof(CartService)}:Update");
        return false;
      }
    }
  }
}