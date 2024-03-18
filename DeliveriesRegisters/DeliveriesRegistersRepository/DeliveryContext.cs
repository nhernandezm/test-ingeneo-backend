using DeliveriesRegistersModelos.Dominios;
using Microsoft.EntityFrameworkCore;

namespace DeliveriesRegistersRepository
{
    public class DeliveryContext : DbContext
    {
        public DbSet<DetailDelivery> detail_deliveries { get; set; }
        public DbSet<TruckDelivery> truck_deliveries { get; set; }
        public DbSet<MaritimeDelivery> maritime_deliveries { get; set; }
        public DbSet<Clients> clients { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Countries> countries { get; set; }
        public DbSet<Cities> cities { get; set; }
        public DbSet<Ports> ports { get; set; }
        public DbSet<Cellars> cellars { get; set; } 
        public DbSet<Discounts> discounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseNpgsql("Host=localhost;Port=5432;Database=test-engeo;Username=postgres;Password=nafer1104");
    }
}
