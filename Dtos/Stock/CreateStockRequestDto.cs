namespace api;

public class CreateStockRequestDto
{
    [required]
    public string Symbol { get; set; }=string.Empty;
    [required]

    public string CompanyName { get; set; }=string.Empty;
    [required]

    public decimal Purchase{get;set;}
    [required]

    public decimal LastDiv{get;set;}
    [required]

    public string  Industry { get; set; }=string.Empty;
    [required]

    // long i.e huge amout of moni or value
    public long MarketCap { get; set; }
}
