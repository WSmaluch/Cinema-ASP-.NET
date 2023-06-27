﻿// <auto-generated />
using System;
using Firma.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Firma.Data.Migrations
{
    [DbContext(typeof(FirmaContext))]
    [Migration("20230622151805_m23")]
    partial class m23
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Firma.Data.Data.CMS.Kategorie", b =>
                {
                    b.Property<int>("IdKategorii")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKategorii"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKategorii");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Komentarz", b =>
                {
                    b.Property<int>("IdKomentarza")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKomentarza"), 1L, 1);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKomentarza");

                    b.ToTable("Komentarz");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Oferty", b =>
                {
                    b.Property<int>("IdOferty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOferty"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zdjecie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOferty");

                    b.ToTable("Oferty");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.ONas", b =>
                {
                    b.Property<int>("IdONas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdONas"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<string>("Historia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("Kontakt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naglowek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tekst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zdjecia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdONas");

                    b.ToTable("ONas");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Posty", b =>
                {
                    b.Property<int>("IdPostu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPostu"), 1L, 1);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataPublikacji")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObrazekUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPostu");

                    b.ToTable("Posty");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Prezenty", b =>
                {
                    b.Property<int>("IdPrezentu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrezentu"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zdjecie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPrezentu");

                    b.ToTable("Prezenty");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Prywatnosc", b =>
                {
                    b.Property<int>("IdPrywatnosci")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrywatnosci"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naglowek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tresc5")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPrywatnosci");

                    b.ToTable("Prywatnosc");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Strona", b =>
                {
                    b.Property<int>("IdStrony")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStrony"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkTytul")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Pozycja")
                        .HasColumnType("int");

                    b.Property<string>("Tresc")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdStrony");

                    b.ToTable("Strona");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.StronaGlowna", b =>
                {
                    b.Property<int>("IdStronyGlownej")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdStronyGlownej"), 1L, 1);

                    b.Property<string>("Bannery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartnerzyZdjecia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReklamyZdjecia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TekstyBanner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TekstyReklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdStronyGlownej");

                    b.ToTable("StronaGlowna");
                });

            modelBuilder.Entity("Firma.Data.Data.CMS.Szczegoly", b =>
                {
                    b.Property<int>("IdSzczegolu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSzczegolu"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSzczegolu");

                    b.ToTable("Szczegoly");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Bilet", b =>
                {
                    b.Property<int>("IdBiletu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBiletu"), 1L, 1);

                    b.Property<DateTime>("CzasProjekcji")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataProjekcji")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NrTelefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumerSiedzenia")
                        .HasColumnType("int");

                    b.Property<string>("ZarezerwowanyPrzez")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBiletu");

                    b.HasIndex("FilmId");

                    b.ToTable("Bilet");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Filmy", b =>
                {
                    b.Property<int>("IdFilmu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFilmu"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataPremiery")
                        .HasColumnType("datetime2");

                    b.Property<int>("Dlugosc")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DoKiedyGrany")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gatunek")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("GatunekIdGatunku")
                        .HasColumnType("int");

                    b.Property<string>("GodzinyGrania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkDoZwiastunu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OdKiedyGrany")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rezyser")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tytuł")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Zdjecie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFilmu");

                    b.HasIndex("GatunekIdGatunku");

                    b.ToTable("Filmy");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Gatunek", b =>
                {
                    b.Property<int>("IdGatunku")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGatunku"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGatunku");

                    b.ToTable("Gatunek");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Miejsce", b =>
                {
                    b.Property<int>("IdMiejsca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMiejsca"), 1L, 1);

                    b.Property<bool>("CzyAktywny")
                        .HasColumnType("bit");

                    b.Property<int?>("FilmyIdFilmu")
                        .HasColumnType("int");

                    b.Property<DateTime>("KiedyDodal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyWykasowal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("KiedyZmodyfikowal")
                        .HasColumnType("datetime2");

                    b.Property<string>("KtoDodal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoWykasowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KtoZmodyfikowal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumerMiejsca")
                        .HasColumnType("int");

                    b.Property<bool>("Zarezerwowane")
                        .HasColumnType("bit");

                    b.HasKey("IdMiejsca");

                    b.HasIndex("FilmyIdFilmu");

                    b.ToTable("Miejsce");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Bilet", b =>
                {
                    b.HasOne("Firma.Data.Data.Kino.Filmy", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Filmy", b =>
                {
                    b.HasOne("Firma.Data.Data.Kino.Gatunek", null)
                        .WithMany("Filmy")
                        .HasForeignKey("GatunekIdGatunku");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Miejsce", b =>
                {
                    b.HasOne("Firma.Data.Data.Kino.Filmy", null)
                        .WithMany("Miejsca")
                        .HasForeignKey("FilmyIdFilmu");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Filmy", b =>
                {
                    b.Navigation("Miejsca");
                });

            modelBuilder.Entity("Firma.Data.Data.Kino.Gatunek", b =>
                {
                    b.Navigation("Filmy");
                });
#pragma warning restore 612, 618
        }
    }
}
