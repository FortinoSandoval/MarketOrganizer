namespace MarketOrganizer.Data.Models
{
  ///
  /// {
  ///   "ItemName": "Sword",
  ///   "BuyPrice": "50",
  ///   "SellPrice": "45",
  ///   "HighestMarketPrice": "60"
  /// }
  ///
  public class Item
  {
    public int Id { get; set; }
    public string ItemName { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }
    public decimal HighestMarketPrice { get; set; }
  }
}