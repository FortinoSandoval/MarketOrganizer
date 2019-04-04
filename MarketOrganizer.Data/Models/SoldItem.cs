using System;
using System.Collections.Generic;

namespace MarketOrganizer.Data.Models
{
  public class SoldItem
  {
    public int Id { get; set; }

    public int Amount { get; set; }
    public long TotalAmount { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int CartId { get; set; }
    public Cart Cart { get; set; }
  }
}