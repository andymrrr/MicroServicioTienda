﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServicioTienda.Api.Autor.Data.Context;

#nullable disable

namespace ServicioTienda.Api.Autor.Migrations
{
    [DbContext(typeof(ContextAutor))]
    partial class ContextAutorModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ServicioTienda.Api.Autor.Modelo.AutorLibro", b =>
                {
                    b.Property<int>("AutorlibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AutorlibroId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AutorlibroGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AutorlibroId");

                    b.ToTable("AutorLibros");
                });

            modelBuilder.Entity("ServicioTienda.Api.Autor.Modelo.GradoAcademico", b =>
                {
                    b.Property<int>("GradoAcademicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GradoAcademicoId"));

                    b.Property<int>("AutorlibroId")
                        .HasColumnType("integer");

                    b.Property<string>("CentroAcademico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaGrado")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GradoAcademicoGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GradoAcademicoId");

                    b.HasIndex("AutorlibroId");

                    b.ToTable("GradoAcademicos");
                });

            modelBuilder.Entity("ServicioTienda.Api.Autor.Modelo.GradoAcademico", b =>
                {
                    b.HasOne("ServicioTienda.Api.Autor.Modelo.AutorLibro", "AutorLibro")
                        .WithMany("gradoAcademicos")
                        .HasForeignKey("AutorlibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutorLibro");
                });

            modelBuilder.Entity("ServicioTienda.Api.Autor.Modelo.AutorLibro", b =>
                {
                    b.Navigation("gradoAcademicos");
                });
#pragma warning restore 612, 618
        }
    }
}
