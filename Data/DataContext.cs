using Microsoft.EntityFrameworkCore;
using Models;
using System.Reflection.Metadata.Ecma335;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaRank> CategoriaRank { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>()
                .HasOne(c => c.CatRank)
                .WithMany(cr => cr.Categoria)
                .HasForeignKey(c => c.CategoriaRankId);     
        }
    }
}
