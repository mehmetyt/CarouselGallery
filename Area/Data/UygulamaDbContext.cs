
using Microsoft.EntityFrameworkCore;

namespace Area.Data
{
    public class UygulamaDbContext:DbContext
    {

        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }
        public DbSet<Atasozu> Atasozleri { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atasozu>().HasData(
                new Atasozu() {Id=1,Icerik="atasozu1" },
                new Atasozu() {Id=2,Icerik= "atasozu2" },
                new Atasozu() {Id=3,Icerik= "atasozu3" },
                new Atasozu() {Id=4,Icerik= "atasozu4" }
                );
        }
    }
}
