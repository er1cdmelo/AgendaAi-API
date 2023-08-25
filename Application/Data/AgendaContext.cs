using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class AgendaContext : DbContext
    {
        public AgendaContext (DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Profissional> Profissional { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(u => {
                u.HasKey(us => us.IdUsuario);

                u.Property(us => us.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                u.Property(us => us.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                u.Property(us => us.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                u.Property(us => us.Senha)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(120);
            });

            modelBuilder.Entity<Profissional>(p => {
                p.HasKey(pr => pr.IdProfissional);

                p.Property(pr => pr.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                p.Property(pr => pr.Sexo)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("varchar");

                p.Property(pr => pr.Especialidade)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                p.Property(pr => pr.Cidade)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                p.Property(pr => pr.Estado)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar");

                p.Property(pr => pr.ImagemPerfil)
                .HasColumnType("varchar");

                p.Property(pr => pr.CdIdentificacao)
                .IsRequired()
                .HasColumnType("int");

                p.HasOne(p => p.Usuario) // Profissional tem um Usuário
                .WithOne() // Sem navegação inversa, pois um Usuário não precisa apontar para um Profissional
                .HasForeignKey<Profissional>(p => p.IdUsuario);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
