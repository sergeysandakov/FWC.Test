using System.Data.Entity;

namespace FunnyWaterCarrier.Models.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("FunnyWaterCarrierDb")
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departament>()
                .HasMany(d => d.Employees)
                .WithRequired(us => us.Departament);

            modelBuilder.Entity<Departament>()
                .HasOptional(d => d.Leader);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithRequired(o => o.Worker);

            base.OnModelCreating(modelBuilder);
        }
    }
}
