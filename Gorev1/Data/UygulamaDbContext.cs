using Microsoft.EntityFrameworkCore;

namespace Gorev1.Data
{
    public class UygulamaDbContext:DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }
        public DbSet<Slayt> Slaytlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slayt>().HasData(
                new Slayt() { Id=1,Baslik="Kedi",Aciklama="Yavru kediler",Resim="kedi.jpg",Sira=1},
                new Slayt() { Id=2,Baslik="Sincap",Aciklama="Aç sincap",Resim="sincap.jpg",Sira=2},
                new Slayt() { Id=3,Baslik="Fil",Aciklama="Fil ailesi",Resim="fil.jpg",Sira=3}
                );
        }
    }

   
}
