using Application.Data.Entities;
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
        public DbSet<UserTokenTO> UserToken { get; set; }
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

            modelBuilder.Entity<UserTokenTO>(u =>
            {
                u.HasKey(us => us.Id);

                u.Property(us => us.AccessToken)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("nvarchar");

                u.Property(us => us.RefreshToken)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnType("nvarchar");

                u.Property(us => us.TokenType)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

                u.Property(us => us.ExpiresIn)
                .IsRequired()
                .HasColumnType("int");

                u.Property(us => us.UserId)
                .IsRequired()
                .HasColumnType("int");

                u.Property(us => us.CreatedAt)
                .IsRequired()
                .HasColumnType("datetimeoffset");

                u.Property(us => us.UpdatedAt)
                .HasColumnType("datetimeoffset");

                u.Property(us => us.Scope)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
