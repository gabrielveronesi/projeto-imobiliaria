using Microsoft.EntityFrameworkCore;
using server.Models.Entity;

namespace server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Casa> Casas { get; set; }
         public DbSet<Foto> Fotos { get; set; }

    }
}