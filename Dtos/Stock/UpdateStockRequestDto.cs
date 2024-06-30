namespace api;

public class UpdateStockRequestDto
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
    // long i.e huge amout of moni or value
    [required]
    
    public long MarketCap { get; set; }
}
