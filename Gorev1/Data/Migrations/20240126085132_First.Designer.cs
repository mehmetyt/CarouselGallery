﻿// <auto-generated />
using Gorev1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gorev1.Data.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    [Migration("20240126085132_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gorev1.Data.Slayt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sira")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Slaytlar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aciklama = "Yavru kediler",
                            Baslik = "Kedi",
                            Resim = "kedi.jpg",
                            Sira = 1
                        },
                        new
                        {
                            Id = 2,
                            Aciklama = "Aç sincap",
                            Baslik = "Sincap",
                            Resim = "sincap.jpg",
                            Sira = 2
                        },
                        new
                        {
                            Id = 3,
                            Aciklama = "Fil ailesi",
                            Baslik = "Fil",
                            Resim = "fil.jpg",
                            Sira = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
