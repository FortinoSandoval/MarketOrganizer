namespace MarketOrganizer.Data.Models
{
  public class Items
  {
    public int Id { get; set; }
    public string ItemName { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public int HighestMarketPrice { get; set; }
  }
}