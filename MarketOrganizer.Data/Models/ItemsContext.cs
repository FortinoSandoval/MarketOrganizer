using Microsoft.EntityFrameworkCore;

namespace MarketOrganizer.Data.Models
{
  public class ItemsContext : DbContext
  {
    public ItemsContext(DbContextOptions<ItemsContext> options) : base(options) { }

    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<SoldItem> SoldItems { get; set; }
    public DbSet<StoreItem> StoreItems { get; set; }
  }
}