using Microsoft.EntityFrameworkCore;

namespace Application
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
                u.HasKey(us => us.IdPessoa);

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

            modelBuilder.Entity<Profissional>(u => {
                u.HasKey(us => us.IdPessoa);

                u.Property(us => us.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                u.Property(us => us.Sexo)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("varchar");

                u.Property(us => us.Especialidade)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                u.Property(us => us.Cidade)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                u.Property(us => us.Estado)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar");

                u.Property(us => us.CdIdentificacao)
                .IsRequired()
                .HasColumnType("int");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
