using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class FridgeDataBaseContext : DbContext
{
    public FridgeDataBaseContext()
    {
    }

    public FridgeDataBaseContext(DbContextOptions<FridgeDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fridge> Fridges { get; set; }

    public virtual DbSet<FridgeModel> FridgeModels { get; set; }

    public virtual DbSet<FridgeProduct> FridgeProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }
}
