using CatalogoAPI_Net5.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI_Net5.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
