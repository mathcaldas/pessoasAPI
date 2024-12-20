using pessoasAPI.src.Model;
using Microsoft.EntityFrameworkCore;

namespace pessoasAPI.src.Data
{
    public class PessoaEnderecoDb(DbContextOptions<PessoaEnderecoDb> options) : DbContext(options)
    {
        public DbSet<Pessoa>? Pessoas { get; set; }
        public DbSet<Endereco>? Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Enderecos)
                .WithOne()
                .HasForeignKey(p => p.PessoaId);
        }
    }

}