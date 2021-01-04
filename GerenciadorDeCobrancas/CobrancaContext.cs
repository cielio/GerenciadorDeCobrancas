using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCobrancas
{
    public class CobrancaContext : DbContext
    {
        public DbSet<Cobranca> Cobrancas { get; set; }
        public DbSet<Conta> Contas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=Cobrancas.db");
    }
}
