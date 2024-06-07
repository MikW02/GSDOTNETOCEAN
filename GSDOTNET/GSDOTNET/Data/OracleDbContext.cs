using System.Data.Entity;
using YourNamespace.Models; 

namespace YourNamespace.Data
{
    public class OracleDbContext : DbContext
    {
        
        public OracleDbContext() : base("name=OracleDbContext")
        {
        }

        
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.HasDefaultSchema("RM551382");
            base.OnModelCreating(modelBuilder);
        }
    }
}