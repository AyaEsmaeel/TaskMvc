using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ApplicationDbcontext : DbContext
    {
        
        public DbSet<Tasks> tasks{ get; set; }
        public DbSet<Clients> client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var bulider = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var connection = bulider.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                        .HasOne(e => e.client)
                        .WithMany(e => e.tasks)
                        .HasForeignKey(e => e.ClientsId);


            modelBuilder.Entity<Clients>()
                        .HasMany(e => e.tasks)
                        .WithOne(e => e.client)
                        .HasPrincipalKey(e => e.ClientsId);
        }
    }
}
