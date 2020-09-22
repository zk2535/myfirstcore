using Microsoft.EntityFrameworkCore;


namespace YineBirCore.Models
{
    public class UrunlerDbContext:DbContext 
    {
        public UrunlerDbContext(DbContextOptions<UrunlerDbContext> options): base(options)
        {

        }

        public DbSet<Urunler> Urunler { get; set; }


    }
}
