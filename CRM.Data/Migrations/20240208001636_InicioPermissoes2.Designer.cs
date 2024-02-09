﻿// <auto-generated />
using System;
using CRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRM.Data.Migrations
{
    [DbContext(typeof(CRMDbContext))]
    [Migration("20240208001636_InicioPermissoes2")]
    partial class InicioPermissoes2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CRM.Domain.Componente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ComponenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(7603));

                    b.Property<Guid>("Hash")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("JsonCampos")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComponenteId");

                    b.ToTable("Componente");
                });

            modelBuilder.Entity("CRM.Domain.ComponenteEndPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComponenteID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(7871));

                    b.Property<string>("EndPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.HasIndex("ComponenteID");

                    b.ToTable("ComponenteEndPoint");
                });

            modelBuilder.Entity("CRM.Domain.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8048));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RegiaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.HasIndex("RegiaoId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("CRM.Domain.Municipio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8184));

                    b.Property<Guid?>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("CRM.Domain.Pais", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8281));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("CRM.Domain.Papel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8425));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Json")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PapelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PapelId");

                    b.ToTable("Papel");
                });

            modelBuilder.Entity("CRM.Domain.PapelComponente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ComponenteID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8576));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("PapelID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ComponenteID");

                    b.HasIndex("PapelID");

                    b.ToTable("PapelComponente");
                });

            modelBuilder.Entity("CRM.Domain.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8752));

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentoTipo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("CRM.Domain.PessoaEndereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8872));

                    b.Property<Guid?>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MunicipioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("PaisId");

                    b.HasIndex("PessoaId");

                    b.ToTable("PessoaEnderecos");
                });

            modelBuilder.Entity("CRM.Domain.Regiao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(8990));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PaisId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Regioes");
                });

            modelBuilder.Entity("CRM.Domain.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(9110));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Inativo")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Teste");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CRM.Domain.UsuarioPapel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 2, 7, 21, 16, 35, 989, DateTimeKind.Local).AddTicks(9232));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("PapelID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PapelID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("UsuarioPapel");
                });

            modelBuilder.Entity("CRM.Domain.Componente", b =>
                {
                    b.HasOne("CRM.Domain.Componente", null)
                        .WithMany("Componentes")
                        .HasForeignKey("ComponenteId");
                });

            modelBuilder.Entity("CRM.Domain.ComponenteEndPoint", b =>
                {
                    b.HasOne("CRM.Domain.Componente", "Componente")
                        .WithMany("ComponenteEndPoints")
                        .HasForeignKey("ComponenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Componente_EndPoint");

                    b.Navigation("Componente");
                });

            modelBuilder.Entity("CRM.Domain.Estado", b =>
                {
                    b.HasOne("CRM.Domain.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");

                    b.HasOne("CRM.Domain.Regiao", "Regiao")
                        .WithMany()
                        .HasForeignKey("RegiaoId");

                    b.Navigation("Pais");

                    b.Navigation("Regiao");
                });

            modelBuilder.Entity("CRM.Domain.Municipio", b =>
                {
                    b.HasOne("CRM.Domain.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("CRM.Domain.Papel", b =>
                {
                    b.HasOne("CRM.Domain.Papel", null)
                        .WithMany("Papeis")
                        .HasForeignKey("PapelId");
                });

            modelBuilder.Entity("CRM.Domain.PapelComponente", b =>
                {
                    b.HasOne("CRM.Domain.Componente", "Componente")
                        .WithMany()
                        .HasForeignKey("ComponenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.Domain.Papel", "Papel")
                        .WithMany("PapelComponentes")
                        .HasForeignKey("PapelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Papel_PapelComponentes");

                    b.Navigation("Componente");

                    b.Navigation("Papel");
                });

            modelBuilder.Entity("CRM.Domain.PessoaEndereco", b =>
                {
                    b.HasOne("CRM.Domain.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");

                    b.HasOne("CRM.Domain.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.HasOne("CRM.Domain.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");

                    b.HasOne("CRM.Domain.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("Estado");

                    b.Navigation("Municipio");

                    b.Navigation("Pais");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CRM.Domain.Regiao", b =>
                {
                    b.HasOne("CRM.Domain.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("CRM.Domain.Usuario", b =>
                {
                    b.HasOne("CRM.Domain.Usuario", null)
                        .WithMany("Usuarios")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("CRM.Domain.UsuarioPapel", b =>
                {
                    b.HasOne("CRM.Domain.Papel", "Papel")
                        .WithMany()
                        .HasForeignKey("PapelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRM.Domain.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CRM.Domain.Componente", b =>
                {
                    b.Navigation("ComponenteEndPoints");

                    b.Navigation("Componentes");
                });

            modelBuilder.Entity("CRM.Domain.Papel", b =>
                {
                    b.Navigation("Papeis");

                    b.Navigation("PapelComponentes");
                });

            modelBuilder.Entity("CRM.Domain.Usuario", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
