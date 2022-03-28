﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pasticceria.Models;

#nullable disable

namespace Pasticceria.Migrations
{
    [DbContext(typeof(PasticceriaContext))]
    partial class PasticceriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Pasticceria.Models.Dolce", b =>
                {
                    b.Property<int>("DolceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DolceId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DolceId");

                    b.ToTable("Dolci");
                });

            modelBuilder.Entity("Pasticceria.Models.Ingrediente", b =>
                {
                    b.Property<int>("IngredienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredienteId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IngredienteId");

                    b.ToTable("Ingredienti");
                });

            modelBuilder.Entity("Pasticceria.Models.Ricetta", b =>
                {
                    b.Property<int>("RicettaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RicettaId"), 1L, 1);

                    b.Property<int>("DolceId")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantita")
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("UM")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("RicettaId");

                    b.ToTable("Ricette");
                });

            modelBuilder.Entity("Pasticceria.Models.TabellaTest", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("TestId");

                    b.ToTable("TabellaTest");
                });

            modelBuilder.Entity("Pasticceria.Models.Vetrina", b =>
                {
                    b.Property<int>("VetrinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VetrinaId"), 1L, 1);

                    b.Property<int>("DolceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MessaInVendita")
                        .HasColumnType("date");

                    b.Property<decimal>("Prezzo")
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("Quantita")
                        .HasColumnType("int");

                    b.HasKey("VetrinaId");

                    b.ToTable("Vetrina");
                });
#pragma warning restore 612, 618
        }
    }
}
