namespace api;

public class UpdateStockRequestDto
{
    public string Symbol { get; set; }=string.Empty;
    public string CompanyName { get; set; }=string.Empty;
    public decimal Purchase{get;set;}
    public decimal LastDiv{get;set;}
    public string  Industry { get; set; }=string.Empty;
    // long i.e huge amout of moni or value
    public long MarketCap { get; set; }
}
