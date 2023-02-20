using DbOtusConsole.Entity;
using Microsoft.EntityFrameworkCore;

namespace DbOtusConsole.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options): base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Port=5432;Host=localhost;Password=123;Database=otus");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(opt =>
        {
            opt.ToTable("users")
                .HasKey(x => x.Id);
            opt.Property(x => x.Id).HasColumnName("id");
            opt.Property(x => x.FirstName).HasColumnName("first_name")
                .IsRequired();
            opt.Property(x => x.LastName).HasColumnName("last_name");
            opt.Property(x => x.Email).HasColumnName("email")
                .IsRequired();
        });

        modelBuilder.Entity<Product>(opt =>
        {
            opt.ToTable("produscts")
                .HasKey(x => x.Id);
            opt.Property(x => x.Id).HasColumnName("id");
            opt.Property(x => x.Title).HasColumnName("title")
                .IsRequired();
            opt.Property(x => x.Description).HasColumnName("description")
                .HasMaxLength(300);
            opt.Property(x => x.Price).HasColumnName("price");

            opt.HasOne(u => u.User)
                .WithMany(p => p.Products);
        });
            
            






        base.OnModelCreating(modelBuilder);
    }
}