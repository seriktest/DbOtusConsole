using DbOtusConsole.Abstractions;

namespace DbOtusConsole.Entity;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Product> Products { get; set; }

}