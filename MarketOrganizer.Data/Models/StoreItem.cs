namespace MarketOrganizer.Data.Models
{
  public class StoreItem
  {
    public int Id { get; set; }
    public int Amount { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
  }
}