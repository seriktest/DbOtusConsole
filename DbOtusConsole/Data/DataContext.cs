using DbOtusConsole.Entity;
using Microsoft.EntityFrameworkCore;

namespace DbOtusConsole.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }
}