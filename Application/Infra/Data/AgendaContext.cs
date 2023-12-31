﻿using Application.Data.Entities;
using Application.Infra.DTO;
using Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
    public class AgendaContext : DbContext
    {
        public AgendaContext()
        {
        }

        public AgendaContext (DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Preferencia> Preferencia { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<HorarioDisponivel> HorarioDisponivel { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<ProfissionalServico> ProfissionalServico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(); // Habilita o lazy loading
            base.OnConfiguring(optionsBuilder);
        }
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
                .HasColumnType("VARCHAR(MAX)");

                p.Property(pr => pr.CdIdentificacao)
                .IsRequired()
                .HasColumnType("int");

                p.HasOne(p => p.Usuario)
                .WithOne(u => u.Profissional)
                .HasForeignKey<Profissional>(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasKey(cl => cl.IdCliente);

                c.Property(cl => cl.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                c.Property(cl => cl.Sexo)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("varchar");

                c.Property(cl => cl.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar");

                c.Property(cl => cl.DtNascimento)
                .IsRequired()
                .HasColumnType("datetimeoffset");

                c.Property(cl => cl.Cidade)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

                c.Property(cl => cl.Estado)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar");

                c.Property(cl => cl.Telefone)
                .HasMaxLength(18)
                .HasColumnType("varchar");

                c.HasOne(c => c.Usuario)
                .WithOne(u => u.Cliente)
                .HasForeignKey<Cliente>(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserToken>(u =>
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

            modelBuilder.Entity<Preferencia>(p =>
            {
                p.HasKey(pr => pr.IdPreferencia);

                p.Property(pr => pr.CdPreferencia)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

                p.Property(pr => pr.DsPreferencia)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(80);

                p.Property(pr => pr.IdTipoPreferencia)
                .IsRequired()
                .HasColumnType("int");

                p.Property(pr => pr.ValorPreferencia)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(180);
            });

            modelBuilder.Entity<Agendamento>(a =>
            {
                a.HasKey(ag => ag.IdAgendamento);

                a.Property(ag => ag.DtRegistro)
                .IsRequired()
                .HasColumnType("datetimeoffset");

                a.Property(ag => ag.DtAgendamento)
                .IsRequired()
                .HasColumnType("datetimeoffset");

                a.Property(ag => ag.Status)
                .IsRequired()
                .HasColumnType("int");

                a.Property(ag => ag.NmServico)
                .HasColumnType("varchar")
                .HasMaxLength(80);

                a.Property(ag => ag.VlServico)
                .HasColumnType("float");

                a.HasOne(ag => ag.Profissional)
                .WithMany(p => p.Agendamentos)
                .HasForeignKey(ag => ag.IdProfissional)
                .IsRequired(false);

                a.HasOne(ag => ag.HorarioDisponivel)
                .WithOne()
                .HasForeignKey<Agendamento>(ag => ag.IdDataHora)
                .IsRequired(false);

                a.HasOne(ag => ag.Cliente)
                .WithMany(c => c.Agendamentos)
                .HasForeignKey(ag => ag.IdCliente)
                .IsRequired(false);

                a.HasOne(ag => ag.Servico)
                .WithOne()
                .HasForeignKey<Agendamento>(ag => ag.IdServico)
                .IsRequired(false);
            });

            modelBuilder.Entity<HorarioDisponivel>(h =>
            {
                h.HasKey(hd => hd.Id);

                h.Property(hd => hd.DtHora)
                .IsRequired()
                .HasColumnType("datetimeoffset");

                h.Property(hd => hd.Status)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(20);

                h.HasOne(hd => hd.Profissional)
                .WithMany(p => p.HorariosDisponiveis)
                .HasForeignKey(hd => hd.IdProfissional)
                .IsRequired(false);
            });

            modelBuilder.Entity<Servico>(s =>
            {
                s.HasKey(se => se.IdServico);

                s.Property(se => se.NmServico)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

                s.Property(se => se.DsServico)
                .HasColumnType("varchar")
                .HasMaxLength(80);

                s.Property(se => se.VlServico)
                .HasColumnType("float")
                .IsRequired();

                s.Property(se => se.FlAtivo)
                .HasColumnType("bit")
                .IsRequired();
            });

            modelBuilder.Entity<ProfissionalServico>(p =>
            {
                p.HasKey(ps => new { ps.IdProfissional, ps.IdServico });

                p.HasOne(ps => ps.Profissional)
                    .WithMany(p => p.ProfissionalServicos)
                    .HasForeignKey(ps => ps.IdProfissional);

                p.HasOne(ps => ps.Servico)
                    .WithMany(s => s.ProfissionalServicos)
                    .HasForeignKey(ps => ps.IdServico);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
