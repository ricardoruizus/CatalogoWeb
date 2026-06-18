using Microsoft.EntityFrameworkCore;
using CatalogoWeb.Entities;

namespace CatalogoWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Esto creará de forma automática una tabla llamada "Contenidos"
        public DbSet<Contenido> Contenidos { get; set; }
    }
}