﻿// <auto-generated />
using System;
using Canchas4.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Canchas4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230120214402_AgregaCanchaVoleiEnModelsCorreccion")]
    partial class AgregaCanchaVoleiEnModelsCorreccion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Canchas4.Models.CanchVolei", b =>
                {
                    b.Property<int>("CanchaVoleiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CanchaVoleiId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SedeId")
                        .HasColumnType("int");

                    b.Property<string>("mensajeError")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CanchaVoleiId");

                    b.HasIndex("SedeId");

                    b.ToTable("CanchVolei");
                });

            modelBuilder.Entity("Canchas4.Models.CanchaFut", b =>
                {
                    b.Property<int>("CanchaFutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CanchaFutId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SedeId")
                        .HasColumnType("int");

                    b.Property<string>("mensajeError")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CanchaFutId");

                    b.HasIndex("SedeId");

                    b.ToTable("CanchaFut");
                });

            modelBuilder.Entity("Canchas4.Models.Reservas", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int?>("CanchaFutId")
                        .HasColumnType("int");

                    b.Property<int?>("CanchaVoleiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("CanchaFutId");

                    b.HasIndex("CanchaVoleiId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Canchas4.Models.ReservasVolei", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int?>("CanchaVoleiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("CanchaVoleiId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("ReservasVolei");
                });

            modelBuilder.Entity("Canchas4.Models.Sede", b =>
                {
                    b.Property<int?>("SedeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SedeId"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MenssajeError")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SedeId");

                    b.ToTable("Sede");
                });

            modelBuilder.Entity("Canchas4.Models.Slider", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urllmagen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("Canchas4.Models.Usuario", b =>
                {
                    b.Property<int?>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UsuarioId"));

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Celular")
                        .HasColumnType("int");

                    b.Property<string>("Coreo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Canchas4.Models.CanchVolei", b =>
                {
                    b.HasOne("Canchas4.Models.Sede", "Sede")
                        .WithMany("CanchVolei")
                        .HasForeignKey("SedeId");

                    b.Navigation("Sede");
                });

            modelBuilder.Entity("Canchas4.Models.CanchaFut", b =>
                {
                    b.HasOne("Canchas4.Models.Sede", "Sede")
                        .WithMany("CanchaFut")
                        .HasForeignKey("SedeId");

                    b.Navigation("Sede");
                });

            modelBuilder.Entity("Canchas4.Models.Reservas", b =>
                {
                    b.HasOne("Canchas4.Models.CanchaFut", "CanchaFut")
                        .WithMany("Reservas")
                        .HasForeignKey("CanchaFutId");

                    b.HasOne("Canchas4.Models.CanchVolei", "CanchVolei")
                        .WithMany("Reservas")
                        .HasForeignKey("CanchaVoleiId");

                    b.HasOne("Canchas4.Models.Usuario", "Usuario")
                        .WithMany("Reservas")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("CanchVolei");

                    b.Navigation("CanchaFut");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Canchas4.Models.ReservasVolei", b =>
                {
                    b.HasOne("Canchas4.Models.CanchVolei", "CanchVolei")
                        .WithMany()
                        .HasForeignKey("CanchaVoleiId");

                    b.HasOne("Canchas4.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("CanchVolei");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Canchas4.Models.CanchVolei", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Canchas4.Models.CanchaFut", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Canchas4.Models.Sede", b =>
                {
                    b.Navigation("CanchVolei");

                    b.Navigation("CanchaFut");
                });

            modelBuilder.Entity("Canchas4.Models.Usuario", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
