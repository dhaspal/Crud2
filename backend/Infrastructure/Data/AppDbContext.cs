using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public AppDbContext() {} // Agregar constructor vacío

        public DbSet<Producto> Productos { get; set; }
    }
}