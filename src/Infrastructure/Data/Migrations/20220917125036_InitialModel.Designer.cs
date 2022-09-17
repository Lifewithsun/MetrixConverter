﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MatrixDataContext))]
    [Migration("20220917125036_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.HasSequence("matrix_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("ApplicationCore.Entities.MatrixDataItem", b =>
                {
                    b.Property<int>("Id")                    
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "matrix_hilo");

                    b.Property<string>("ConvertFrom")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("ConvertTo")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsDecimal")
                        .HasColumnType("bit");

                    b.Property<string>("MutliplyBy")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("MatrixData", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}