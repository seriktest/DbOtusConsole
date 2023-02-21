using DbOtusConsole.Data;
using DbOtusConsole.Entity;
using DbOtusConsole.Repos;

namespace DbOtusConsole;
public static class Program
{
    
    public static async Task<int> Main(string[] args)
    {
        var context = new DataContext();
        var userRepo = new EfRepository<User>(context);
        var productRepo = new EfRepository<Product>(context);

        await userRepo.AddAsync(CreateUser());
        await productRepo.AddAsync(CreateProduct());

        
        Console.ReadLine();
        return 0;
    }

    public static User CreateUser()
    {
        return new User()
        {
            FirstName = "Igor",
            LastName = "Igorevich",
            Email = "test@mail.ru",
            Products = new List<Product>()
            
        };
    }

    public static Product CreateProduct()
    {
        return new Product()
        {
            Title = "Product",
            Description = "Good product",
            Price = 123
        };
    }
    
} 