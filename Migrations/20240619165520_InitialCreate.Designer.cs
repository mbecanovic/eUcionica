﻿// <auto-generated />
using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace eUcionica.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240619165520_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("klase1.Oblasti", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("IDPredmeta")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Oblasti");
                });

            modelBuilder.Entity("klase1.Pitanja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("IDOblast")
                        .HasColumnType("int");

                    b.Property<int>("IDPredmet")
                        .HasColumnType("int");

                    b.Property<string>("Nivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Odgovor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pitanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IDOblast");

                    b.HasIndex("IDPredmet");

                    b.ToTable("Pitanja");
                });

            modelBuilder.Entity("klase1.Predmeti", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Predmeti");
                });

            modelBuilder.Entity("klase1.Pitanja", b =>
                {
                    b.HasOne("klase1.Oblasti", "Oblast")
                        .WithMany("Pitanje")
                        .HasForeignKey("IDOblast")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("klase1.Predmeti", "Predmet")
                        .WithMany("Pitanje")
                        .HasForeignKey("IDPredmet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Oblast");

                    b.Navigation("Predmet");
                });

            modelBuilder.Entity("klase1.Oblasti", b =>
                {
                    b.Navigation("Pitanje");
                });

            modelBuilder.Entity("klase1.Predmeti", b =>
                {
                    b.Navigation("Pitanje");
                });
#pragma warning restore 612, 618
        }
    }
}
