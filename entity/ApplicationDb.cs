using Microsoft.EntityFrameworkCore;

namespace api;

public class ApplicationDb:DbContext
{
    public ApplicationDb(DbContextOptions contextOptions):base(contextOptions)
    {
        
    }
    public DbSet<Stock>stocks{get;set;}
    public DbSet<Comment>Comments{get;set;}
}
