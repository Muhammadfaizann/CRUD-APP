using Microsoft.EntityFrameworkCore;
using ServerApplication.Models.UserModels;

namespace ServerApplication
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set;}
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
             modelBuilder.Entity<Product>()
                    .Property(s => s.Name)
                    .HasColumnName("ProductName")
                    .IsRequired();


        }
    }
}
