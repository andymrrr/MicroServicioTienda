﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicioTienda.Api.CarritoCompra.Data.Context;

#nullable disable

namespace ServicioTienda.Api.CarritoCompra.Migrations
{
    [DbContext(typeof(ContextCarrito))]
    partial class ContextCarritoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServicioTienda.Api.CarritoCompra.Modelo.CarritoSesion", b =>
                {
                    b.Property<int>("CarritoSesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoSesionId"));

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("CarritoSesionId");

                    b.ToTable("CarritoSesions");
                });

            modelBuilder.Entity("ServicioTienda.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
                {
                    b.Property<int>("CarritoSesionDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoSesionDetalleId"));

                    b.Property<int>("CarritoSesionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("libroSeleccionado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarritoSesionDetalleId");

                    b.HasIndex("CarritoSesionId");

                    b.ToTable("CarritoSesionDetalles");
                });

            modelBuilder.Entity("ServicioTienda.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
                {
                    b.HasOne("ServicioTienda.Api.CarritoCompra.Modelo.CarritoSesion", "CarritoSesion")
                        .WithMany("CarritoSesionDetalles")
                        .HasForeignKey("CarritoSesionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarritoSesion");
                });

            modelBuilder.Entity("ServicioTienda.Api.CarritoCompra.Modelo.CarritoSesion", b =>
                {
                    b.Navigation("CarritoSesionDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
