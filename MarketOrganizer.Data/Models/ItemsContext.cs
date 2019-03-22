using Microsoft.EntityFrameworkCore;

namespace MarketOrganizer.Data.Models
{
  public class ItemsContext : DbContext
  {
    public ItemsContext(DbContextOptions<ItemsContext> options) : base(options) { }

    public DbSet<Items> Item { get; set; }
  }
}