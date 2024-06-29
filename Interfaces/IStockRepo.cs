namespace api;

public interface IStockRepo
{
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id ,UpdateStockRequestDto stockDto);
    Task<Stock?> DeleteAsync(int id);
    Task<bool>StockExist(int id);
    // Task GetByIdAsync();
}
