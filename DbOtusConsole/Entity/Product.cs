using DbOtusConsole.Abstractions;

namespace DbOtusConsole.Entity;

public class Product :BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public User User { get; set; }
}