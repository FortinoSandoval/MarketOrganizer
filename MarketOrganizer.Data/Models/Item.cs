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
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public int HighestMarketPrice { get; set; }
  }
}