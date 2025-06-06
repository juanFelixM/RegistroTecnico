﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RegistroTecnicos.DAL;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250526211604_Tabla en clientes")]
    partial class Tablaenclientes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RegistroTecnicos.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("LimiteCredito")
                        .HasColumnType("double precision");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RNC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TecnicoEncargadoId")
                        .HasColumnType("integer");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RegistroTecnicos.Models.Tecnicos", b =>
                {
                    b.Property<int>("TecnicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TecnicoId"));

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("SueldoHora")
                        .HasColumnType("double precision");

                    b.HasKey("TecnicoId");

                    b.ToTable("Tecnicos");
                });
#pragma warning restore 612, 618
        }
    }
}
