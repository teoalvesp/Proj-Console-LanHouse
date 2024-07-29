using Microsoft.EntityFrameworkCore;

namespace ProjConsoleLanHouse.Data
{
    public class LanHouseContext : DbContext
    {
        public DbSet<DVD> DVDs { get; set; }
        public DbSet<Client> Clients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuração da string de conexão com o banco de dados
            optionsBuilder.UseSqlServer("Server=DESKTOP-G1T7SAC;Database=LanHouseDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DVD>()
                .HasOne(d => d.RentedBy)
                .WithMany(c => c.RentedDVDs)
                .HasForeignKey(d => d.RentedById)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
