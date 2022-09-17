﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(MatrixDataContext))]
    partial class MatrixDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

         

            modelBuilder.Entity("ApplicationCore.Entities.MatrixDataItem", b =>
                {
                    b.Property<int>("Id")
                      .IsRequired()
                        .HasColumnType("int");

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