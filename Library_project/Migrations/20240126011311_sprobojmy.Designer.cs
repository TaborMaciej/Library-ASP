﻿// <auto-generated />
using System;
using Library_project.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_project.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240126011311_sprobojmy")]
    partial class sprobojmy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library_project.Models.Admin", b =>
                {
                    b.Property<Guid>("IDAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDDanaLogowania")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDAdmin");

                    b.HasIndex("IDDanaLogowania")
                        .IsUnique();

                    b.ToTable("Admini");
                });

            modelBuilder.Entity("Library_project.Models.Adres", b =>
                {
                    b.Property<Guid>("IDAdres")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDUlica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NumerBudynku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerMieszkania")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDAdres");

                    b.HasIndex("IDUlica");

                    b.ToTable("Adresy");
                });

            modelBuilder.Entity("Library_project.Models.Bibliotekarz", b =>
                {
                    b.Property<Guid>("IDBibliotekarz")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDDanaLogowania")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDDanaOsobowe")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Pensja")
                        .HasColumnType("int");

                    b.HasKey("IDBibliotekarz");

                    b.HasIndex("IDDanaLogowania")
                        .IsUnique();

                    b.HasIndex("IDDanaOsobowe")
                        .IsUnique();

                    b.ToTable("Bibliotekarze");
                });

            modelBuilder.Entity("Library_project.Models.Czytelnik", b =>
                {
                    b.Property<Guid>("IDCzytelnik")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDDanaLogowania")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDDanaOsobowe")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDCzytelnik");

                    b.HasIndex("IDDanaLogowania")
                        .IsUnique();

                    b.HasIndex("IDDanaOsobowe")
                        .IsUnique();

                    b.ToTable("Czytelnicy");
                });

            modelBuilder.Entity("Library_project.Models.DanaLogowania", b =>
                {
                    b.Property<Guid>("IDDanaLogowania")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDDanaLogowania");

                    b.ToTable("DaneLogowania");
                });

            modelBuilder.Entity("Library_project.Models.DanaOsobowa", b =>
                {
                    b.Property<Guid>("IDDanaOsobowa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDAdres")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDOsoba")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefon")
                        .HasColumnType("int");

                    b.HasKey("IDDanaOsobowa");

                    b.HasIndex("IDAdres");

                    b.HasIndex("IDOsoba");

                    b.ToTable("DaneOsobowe");
                });

            modelBuilder.Entity("Library_project.Models.Egzemplarz", b =>
                {
                    b.Property<Guid>("IDEgzemplarz")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("Dostepnosc")
                        .HasColumnType("bit");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RokZakupu")
                        .HasColumnType("int");

                    b.HasKey("IDEgzemplarz");

                    b.HasIndex("ISBN");

                    b.ToTable("Egzemplarze");
                });

            modelBuilder.Entity("Library_project.Models.Gatunek", b =>
                {
                    b.Property<Guid?>("IDGatunek")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDGatunek");

                    b.ToTable("Gatunki");
                });

            modelBuilder.Entity("Library_project.Models.Ksiazka", b =>
                {
                    b.Property<string>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDGatunek")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDWydawnictwo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LiczbaStron")
                        .HasColumnType("int");

                    b.Property<int>("RokWydania")
                        .HasColumnType("int");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISBN");

                    b.HasIndex("IDGatunek");

                    b.HasIndex("IDWydawnictwo");

                    b.ToTable("Ksiazki");
                });

            modelBuilder.Entity("Library_project.Models.KsiazkaAutor", b =>
                {
                    b.Property<Guid>("IDKsiazkaAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDOsoba")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IDKsiazkaAutor");

                    b.HasIndex("IDOsoba");

                    b.HasIndex("ISBN");

                    b.ToTable("KsiazkaAutorzy");
                });

            modelBuilder.Entity("Library_project.Models.Miasto", b =>
                {
                    b.Property<Guid>("IDMiasto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDWojewodztwo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDMiasto");

                    b.HasIndex("IDWojewodztwo");

                    b.ToTable("Miasta");
                });

            modelBuilder.Entity("Library_project.Models.Osoba", b =>
                {
                    b.Property<Guid>("IDOsoba")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("CzyAutor")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataUrodzenia")
                        .HasColumnType("Date");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDOsoba");

                    b.ToTable("Osoby");
                });

            modelBuilder.Entity("Library_project.Models.Ulica", b =>
                {
                    b.Property<Guid>("IDUlica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("IDMiasto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("KodPocztowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDUlica");

                    b.HasIndex("IDMiasto");

                    b.ToTable("Ulice");
                });

            modelBuilder.Entity("Library_project.Models.Wojewodztwo", b =>
                {
                    b.Property<Guid>("IDWojewodztwo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDWojewodztwo");

                    b.ToTable("Wojewodztwa");
                });

            modelBuilder.Entity("Library_project.Models.Wydawnictwo", b =>
                {
                    b.Property<Guid>("IDWydawnictwo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDWydawnictwo");

                    b.ToTable("Wydawnictwa");
                });

            modelBuilder.Entity("Library_project.Models.Wypozyczenie", b =>
                {
                    b.Property<Guid?>("IDWypozyczenie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime?>("DataOddania")
                        .IsRequired()
                        .HasColumnType("Date");

                    b.Property<Guid?>("IDBibliotekarza")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDCzytelnika")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDWypozyczenie");

                    b.HasIndex("IDBibliotekarza");

                    b.HasIndex("IDCzytelnika");

                    b.ToTable("Wypozyczenia");
                });

            modelBuilder.Entity("Library_project.Models.WypozyczenieEgzemplarz", b =>
                {
                    b.Property<Guid>("IDWypozyczenieEgzemplarz")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("DataOddania")
                        .HasColumnType("Date");

                    b.Property<Guid>("IDEgzemplarz")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDWypozyczenia")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IDWypozyczenieEgzemplarz");

                    b.HasIndex("IDEgzemplarz");

                    b.HasIndex("IDWypozyczenia");

                    b.ToTable("WypozyczenieEgzemplarze");
                });

            modelBuilder.Entity("Library_project.Models.Admin", b =>
                {
                    b.HasOne("Library_project.Models.DanaLogowania", "DanaLogowania")
                        .WithOne("Admin")
                        .HasForeignKey("Library_project.Models.Admin", "IDDanaLogowania")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanaLogowania");
                });

            modelBuilder.Entity("Library_project.Models.Adres", b =>
                {
                    b.HasOne("Library_project.Models.Ulica", "Ulica")
                        .WithMany()
                        .HasForeignKey("IDUlica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ulica");
                });

            modelBuilder.Entity("Library_project.Models.Bibliotekarz", b =>
                {
                    b.HasOne("Library_project.Models.DanaLogowania", "DanaLogowania")
                        .WithOne("Bibliotekarz")
                        .HasForeignKey("Library_project.Models.Bibliotekarz", "IDDanaLogowania")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_project.Models.DanaOsobowa", "DanaOsobowa")
                        .WithOne("Bibliotekarz")
                        .HasForeignKey("Library_project.Models.Bibliotekarz", "IDDanaOsobowe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanaLogowania");

                    b.Navigation("DanaOsobowa");
                });

            modelBuilder.Entity("Library_project.Models.Czytelnik", b =>
                {
                    b.HasOne("Library_project.Models.DanaLogowania", "DanaLogowania")
                        .WithOne("Czytelnik")
                        .HasForeignKey("Library_project.Models.Czytelnik", "IDDanaLogowania")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_project.Models.DanaOsobowa", "DanaOsobowa")
                        .WithOne("Czytelnik")
                        .HasForeignKey("Library_project.Models.Czytelnik", "IDDanaOsobowe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanaLogowania");

                    b.Navigation("DanaOsobowa");
                });

            modelBuilder.Entity("Library_project.Models.DanaOsobowa", b =>
                {
                    b.HasOne("Library_project.Models.Adres", "Adres")
                        .WithMany("DanaOsobowe")
                        .HasForeignKey("IDAdres")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_project.Models.Osoba", "Osoba")
                        .WithMany()
                        .HasForeignKey("IDOsoba")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");

                    b.Navigation("Osoba");
                });

            modelBuilder.Entity("Library_project.Models.Egzemplarz", b =>
                {
                    b.HasOne("Library_project.Models.Ksiazka", "Ksiazka")
                        .WithMany("Egzemplarz")
                        .HasForeignKey("ISBN");

                    b.Navigation("Ksiazka");
                });

            modelBuilder.Entity("Library_project.Models.Ksiazka", b =>
                {
                    b.HasOne("Library_project.Models.Gatunek", "Gatunek")
                        .WithMany("Ksiazki")
                        .HasForeignKey("IDGatunek")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_project.Models.Wydawnictwo", "Wydawnictwo")
                        .WithMany("Ksiazki")
                        .HasForeignKey("IDWydawnictwo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gatunek");

                    b.Navigation("Wydawnictwo");
                });

            modelBuilder.Entity("Library_project.Models.KsiazkaAutor", b =>
                {
                    b.HasOne("Library_project.Models.Osoba", "Osoba")
                        .WithMany()
                        .HasForeignKey("IDOsoba")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_project.Models.Ksiazka", "Ksiazka")
                        .WithMany("KsiazkaAutorzy")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ksiazka");

                    b.Navigation("Osoba");
                });

            modelBuilder.Entity("Library_project.Models.Miasto", b =>
                {
                    b.HasOne("Library_project.Models.Wojewodztwo", "Wojewodztwo")
                        .WithMany("Miasta")
                        .HasForeignKey("IDWojewodztwo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wojewodztwo");
                });

            modelBuilder.Entity("Library_project.Models.Ulica", b =>
                {
                    b.HasOne("Library_project.Models.Miasto", "Miasto")
                        .WithMany("Ulica")
                        .HasForeignKey("IDMiasto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miasto");
                });

            modelBuilder.Entity("Library_project.Models.Wypozyczenie", b =>
                {
                    b.HasOne("Library_project.Models.Bibliotekarz", "Bibliotekarz")
                        .WithMany()
                        .HasForeignKey("IDBibliotekarza");

                    b.HasOne("Library_project.Models.Czytelnik", "Czytelnik")
                        .WithMany()
                        .HasForeignKey("IDCzytelnika");

                    b.Navigation("Bibliotekarz");

                    b.Navigation("Czytelnik");
                });

            modelBuilder.Entity("Library_project.Models.WypozyczenieEgzemplarz", b =>
                {
                    b.HasOne("Library_project.Models.Egzemplarz", "Egzemplarz")
                        .WithMany("WypozyczenieEgzemplarz")
                        .HasForeignKey("IDEgzemplarz")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library_project.Models.Wypozyczenie", "Wypozyczenie")
                        .WithMany("WypozyczenieEgzemplarz")
                        .HasForeignKey("IDWypozyczenia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Egzemplarz");

                    b.Navigation("Wypozyczenie");
                });

            modelBuilder.Entity("Library_project.Models.Adres", b =>
                {
                    b.Navigation("DanaOsobowe");
                });

            modelBuilder.Entity("Library_project.Models.DanaLogowania", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Bibliotekarz");

                    b.Navigation("Czytelnik");
                });

            modelBuilder.Entity("Library_project.Models.DanaOsobowa", b =>
                {
                    b.Navigation("Bibliotekarz");

                    b.Navigation("Czytelnik");
                });

            modelBuilder.Entity("Library_project.Models.Egzemplarz", b =>
                {
                    b.Navigation("WypozyczenieEgzemplarz");
                });

            modelBuilder.Entity("Library_project.Models.Gatunek", b =>
                {
                    b.Navigation("Ksiazki");
                });

            modelBuilder.Entity("Library_project.Models.Ksiazka", b =>
                {
                    b.Navigation("Egzemplarz");

                    b.Navigation("KsiazkaAutorzy");
                });

            modelBuilder.Entity("Library_project.Models.Miasto", b =>
                {
                    b.Navigation("Ulica");
                });

            modelBuilder.Entity("Library_project.Models.Wojewodztwo", b =>
                {
                    b.Navigation("Miasta");
                });

            modelBuilder.Entity("Library_project.Models.Wydawnictwo", b =>
                {
                    b.Navigation("Ksiazki");
                });

            modelBuilder.Entity("Library_project.Models.Wypozyczenie", b =>
                {
                    b.Navigation("WypozyczenieEgzemplarz");
                });
#pragma warning restore 612, 618
        }
    }
}