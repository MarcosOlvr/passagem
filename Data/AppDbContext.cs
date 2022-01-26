using Microsoft.EntityFrameworkCore;
using Passagem.Models;

namespace Passagem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<FaleConosco> Emails { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
        public DbSet<Cargos> Cargos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}
