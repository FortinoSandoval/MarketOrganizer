

using System;
using System.Collections.Generic;

namespace MarketOrganizer.Data.Models
{
  public class Cart
  {
    public int Id { get; set; }

    // number of items, item, total for items
    public List<SoldItem> SoldItems { get; set; }
    public long TotalAmount { get; set; }


    public int UserId { get; set; }
    public User User { get; set; }

    public int StoreId { get; set; }
    public Store Store { get; set; }
  }
}