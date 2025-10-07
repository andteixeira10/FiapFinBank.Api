using FiapFinBank.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FiapFinBank.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<ContaBancaria> ContasBancarias => Set<ContaBancaria>();
        public DbSet<Transacao> Transacoes => Set<Transacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeia tabela CLIENTES
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES");
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id).HasColumnName("ID");
                entity.Property(c => c.NomeCompleto).HasColumnName("NOMECOMPLETO");
                entity.Property(c => c.Cpf).HasColumnName("CPF");
                entity.Property(c => c.Email).HasColumnName("EMAIL");

                entity.HasMany(c => c.Contas)
                      .WithOne(cb => cb.Cliente)
                      .HasForeignKey(cb => cb.ClienteId);
            });

            // Mapeia tabela CONTASBANCARIAS
            modelBuilder.Entity<ContaBancaria>(entity =>
            {
                entity.ToTable("CONTASBANCARIAS");
                entity.HasKey(cb => cb.Id);

                entity.Property(cb => cb.Id).HasColumnName("ID");
                entity.Property(cb => cb.NumeroConta).HasColumnName("NUMEROCONTA");
                entity.Property(cb => cb.Agencia).HasColumnName("AGENCIA");
                entity.Property(cb => cb.TipoConta).HasColumnName("TIPOCONTA");
                entity.Property(cb => cb.ClienteId).HasColumnName("CLIENTEID");

                entity.HasMany(cb => cb.Transacoes)
                      .WithOne(t => t.ContaBancaria)
                      .HasForeignKey(t => t.ContaBancariaId);
            });

            // Mapeia tabela TRANSACOES
            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.ToTable("TRANSACOES");
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Id).HasColumnName("ID");
                entity.Property(t => t.Tipo).HasColumnName("TIPO");
                entity.Property(t => t.Valor).HasColumnName("VALOR");
                entity.Property(t => t.Data).HasColumnName("DATA");
                entity.Property(t => t.ContaBancariaId).HasColumnName("CONTABANCARIAID");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
