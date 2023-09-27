﻿// <auto-generated />
using System;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Application.Migrations
{
    [DbContext(typeof(AgendaContext))]
    [Migration("20230924152726_revolucaoHorario_Profissional")]
    partial class revolucaoHorario_Profissional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Application.Data.Entities.Agendamento", b =>
                {
                    b.Property<int>("IdAgendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAgendamento"));

                    b.Property<string>("DsServico")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar");

                    b.Property<DateTimeOffset>("DtAgendamento")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DtRegistro")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdDataHora")
                        .HasColumnType("int");

                    b.Property<int>("IdProfissional")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.HasKey("IdAgendamento");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdDataHora")
                        .IsUnique();

                    b.HasIndex("IdProfissional");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("Application.Data.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar");

                    b.Property<DateTimeOffset>("DtNascimento")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Application.Data.Entities.HorarioDisponivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DtHora")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdProfissional")
                        .HasColumnType("int");

                    b.Property<int?>("ProfissionalIdProfissional")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("IdProfissional");

                    b.HasIndex("ProfissionalIdProfissional");

                    b.ToTable("HorarioDisponivel");
                });

            modelBuilder.Entity("Application.Data.Entities.Preferencia", b =>
                {
                    b.Property<int>("IdPreferencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPreferencia"));

                    b.Property<string>("CdPreferencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("DsPreferencia")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar");

                    b.Property<int>("IdTipoPreferencia")
                        .HasColumnType("int");

                    b.Property<string>("ValorPreferencia")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("varchar");

                    b.HasKey("IdPreferencia");

                    b.ToTable("Preferencia");
                });

            modelBuilder.Entity("Application.Data.Entities.Profissional", b =>
                {
                    b.Property<int>("IdProfissional")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProfissional"));

                    b.Property<int>("CdIdentificacao")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("ImagemPerfil")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar");

                    b.HasKey("IdProfissional");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("Application.Data.Entities.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ExpiresIn")
                        .HasColumnType("int");

                    b.Property<int>("RefreshExpiresIn")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar");

                    b.Property<string>("TokenType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("Application.Data.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Application.Data.Entities.Agendamento", b =>
                {
                    b.HasOne("Application.Data.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdCliente");

                    b.HasOne("Application.Data.Entities.HorarioDisponivel", "HorarioDisponivel")
                        .WithOne()
                        .HasForeignKey("Application.Data.Entities.Agendamento", "IdDataHora");

                    b.HasOne("Application.Data.Entities.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("IdProfissional");

                    b.Navigation("HorarioDisponivel");

                    b.Navigation("Profissional");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Application.Data.Entities.Cliente", b =>
                {
                    b.HasOne("Application.Data.Entities.Usuario", "Usuario")
                        .WithOne()
                        .HasForeignKey("Application.Data.Entities.Cliente", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Application.Data.Entities.HorarioDisponivel", b =>
                {
                    b.HasOne("Application.Data.Entities.Profissional", null)
                        .WithMany()
                        .HasForeignKey("IdProfissional");

                    b.HasOne("Application.Data.Entities.Profissional", null)
                        .WithMany("HorariosDisponiveis")
                        .HasForeignKey("ProfissionalIdProfissional");
                });

            modelBuilder.Entity("Application.Data.Entities.Profissional", b =>
                {
                    b.HasOne("Application.Data.Entities.Usuario", "Usuario")
                        .WithOne("Profissional")
                        .HasForeignKey("Application.Data.Entities.Profissional", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Application.Data.Entities.Profissional", b =>
                {
                    b.Navigation("HorariosDisponiveis");
                });

            modelBuilder.Entity("Application.Data.Entities.Usuario", b =>
                {
                    b.Navigation("Profissional")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
