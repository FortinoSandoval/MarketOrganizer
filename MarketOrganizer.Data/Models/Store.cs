

using System;
using System.Collections.Generic;

namespace MarketOrganizer.Data.Models
{
  public class Store
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }

    public List<StoreItem> SalesList { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

  }
}