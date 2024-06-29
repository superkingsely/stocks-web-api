
using Microsoft.EntityFrameworkCore;

namespace api;

public class StockRepo:IStockRepo
{
    private readonly ApplicationDb _context;

    public StockRepo(ApplicationDb context)
    {
        _context=context;
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
    //    var stock= 
       await _context.stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        // Stock stock = null;
        return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
       var delstock=await _context.stocks.FirstOrDefaultAsync(obj=>obj.Id==id);
       return delstock;
    }

    public async Task<List<Stock>> GetAllAsync()
    {
    //    var stocks= await  _context.stocks.ToListAsync();
    // to include cmments to stock
       var stocks= await  _context.stocks.Include(obj=>obj.Comments).ToListAsync();
       return stocks;
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        // var stock=await _context.stocks.FindAsync(id);
        // toadd comment tostck
        var stock=await _context.stocks.Include(obj=>obj.Comments).FirstOrDefaultAsync(obj=>obj.Id==id);
        return stock;
    }

    public Task<bool> StockExist(int id)
    {
        return _context.stocks.AnyAsync(obj=>obj.Id==id);
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto)
    {
         var stockModel=await _context.stocks.FirstOrDefaultAsync(obj=>obj.Id==id);
            if(stockModel==null){
                return null;
            }
           stockModel.Symbol=updateDto.Symbol;
           stockModel.CompanyName=updateDto.CompanyName;
           stockModel.Purchase=updateDto.Purchase;
           stockModel.LastDiv=updateDto.LastDiv;
           stockModel.Industry=updateDto.Industry;
           stockModel.MarketCap=updateDto.MarketCap;

          await _context.SaveChangesAsync();
          return stockModel;
    }
}
