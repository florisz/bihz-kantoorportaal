﻿// <auto-generated />
using System;
using BerghAdmin.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BerghAdmin.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220104121957_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BerghAdmin.Data.Betaling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float?>("Bedrag")
                        .HasColumnType("real");

                    b.Property<int>("BetalingType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DatumTijd")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Betalingen");
                });

            modelBuilder.Entity("BerghAdmin.Data.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ContentType")
                        .HasColumnType("int");

                    b.Property<bool>("IsMergeTemplate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Documenten");
                });

            modelBuilder.Entity("BerghAdmin.Data.Donateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerwijderd")
                        .HasColumnType("bit");

                    b.Property<string>("Land")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plaats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Donateur");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Donateur");
                });

            modelBuilder.Entity("BerghAdmin.Data.Donatie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float?>("Bedrag")
                        .HasColumnType("real");

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DonateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonateurId");

                    b.ToTable("Donaties");
                });

            modelBuilder.Entity("BerghAdmin.Data.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Evenement");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Evenement");
                });

            modelBuilder.Entity("BerghAdmin.Data.Factuur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float?>("Bedrag")
                        .HasColumnType("real");

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmailTekstId")
                        .HasColumnType("int");

                    b.Property<int?>("FactuurTekstId")
                        .HasColumnType("int");

                    b.Property<int>("FactuurType")
                        .HasColumnType("int");

                    b.Property<bool>("IsVerzonden")
                        .HasColumnType("bit");

                    b.Property<string>("Nummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailTekstId");

                    b.HasIndex("FactuurTekstId");

                    b.ToTable("Facturen");
                });

            modelBuilder.Entity("BerghAdmin.Data.Rol", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeervoudBeschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rollen");
                });

            modelBuilder.Entity("BerghAdmin.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CurrentUserId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BerghAdmin.Data.VerzondenMail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("InhoudId")
                        .HasColumnType("int");

                    b.Property<string>("Onderwerp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerzendDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InhoudId");

                    b.ToTable("VerzondenMails");
                });

            modelBuilder.Entity("EvenementPersoon", b =>
                {
                    b.Property<int>("DeelnemersId")
                        .HasColumnType("int");

                    b.Property<int>("IsDeelnemerVanId")
                        .HasColumnType("int");

                    b.HasKey("DeelnemersId", "IsDeelnemerVanId");

                    b.HasIndex("IsDeelnemerVanId");

                    b.ToTable("EvenementPersoon");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PersoonRol", b =>
                {
                    b.Property<int>("PersonenId")
                        .HasColumnType("int");

                    b.Property<int>("RollenId")
                        .HasColumnType("int");

                    b.HasKey("PersonenId", "RollenId");

                    b.HasIndex("RollenId");

                    b.ToTable("PersoonRol");
                });

            modelBuilder.Entity("PersoonVerzondenMail", b =>
                {
                    b.Property<int>("GeadresseerdenId")
                        .HasColumnType("int");

                    b.Property<int>("GeadresseerdenId1")
                        .HasColumnType("int");

                    b.HasKey("GeadresseerdenId", "GeadresseerdenId1");

                    b.HasIndex("GeadresseerdenId1");

                    b.ToTable("MailGeadresseerden", (string)null);
                });

            modelBuilder.Entity("PersoonVerzondenMail1", b =>
                {
                    b.Property<int>("ccGeadresseerdenId")
                        .HasColumnType("int");

                    b.Property<int>("ccGeadresseerdenId1")
                        .HasColumnType("int");

                    b.HasKey("ccGeadresseerdenId", "ccGeadresseerdenId1");

                    b.HasIndex("ccGeadresseerdenId1");

                    b.ToTable("MailccGeadresseerden", (string)null);
                });

            modelBuilder.Entity("PersoonVerzondenMail2", b =>
                {
                    b.Property<int>("bccGeadresseerdenId")
                        .HasColumnType("int");

                    b.Property<int>("bccGeadresseerdenId1")
                        .HasColumnType("int");

                    b.HasKey("bccGeadresseerdenId", "bccGeadresseerdenId1");

                    b.HasIndex("bccGeadresseerdenId1");

                    b.ToTable("MailbccGeadresseerden", (string)null);
                });

            modelBuilder.Entity("BerghAdmin.Data.FietsTocht", b =>
                {
                    b.HasBaseType("BerghAdmin.Data.Evenement");

                    b.Property<DateTime?>("GeplandJaar")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("FietsTocht");
                });

            modelBuilder.Entity("BerghAdmin.Data.GolfDag", b =>
                {
                    b.HasBaseType("BerghAdmin.Data.Evenement");

                    b.Property<DateTime>("GeplandeDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Locatie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("GolfDag");
                });

            modelBuilder.Entity("BerghAdmin.Data.Organisatie", b =>
                {
                    b.HasBaseType("BerghAdmin.Data.Donateur");

                    b.Property<int?>("ContactPersoonId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("ContactPersoonId");

                    b.HasDiscriminator().HasValue("Organisatie");
                });

            modelBuilder.Entity("BerghAdmin.Data.Persoon", b =>
                {
                    b.HasBaseType("BerghAdmin.Data.Donateur");

                    b.Property<string>("Achternaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdresExtra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("GeboorteDatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Geslacht")
                        .HasColumnType("int");

                    b.Property<string>("Mobiel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefoon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tussenvoegsel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voorletters")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Persoon");
                });

            modelBuilder.Entity("BerghAdmin.Data.Donatie", b =>
                {
                    b.HasOne("BerghAdmin.Data.Donateur", "Donateur")
                        .WithMany()
                        .HasForeignKey("DonateurId");

                    b.Navigation("Donateur");
                });

            modelBuilder.Entity("BerghAdmin.Data.Factuur", b =>
                {
                    b.HasOne("BerghAdmin.Data.Document", "EmailTekst")
                        .WithMany()
                        .HasForeignKey("EmailTekstId");

                    b.HasOne("BerghAdmin.Data.Document", "FactuurTekst")
                        .WithMany()
                        .HasForeignKey("FactuurTekstId");

                    b.Navigation("EmailTekst");

                    b.Navigation("FactuurTekst");
                });

            modelBuilder.Entity("BerghAdmin.Data.User", b =>
                {
                    b.HasOne("BerghAdmin.Data.Persoon", "CurrentUser")
                        .WithMany()
                        .HasForeignKey("CurrentUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentUser");
                });

            modelBuilder.Entity("BerghAdmin.Data.VerzondenMail", b =>
                {
                    b.HasOne("BerghAdmin.Data.Document", "Inhoud")
                        .WithMany()
                        .HasForeignKey("InhoudId");

                    b.Navigation("Inhoud");
                });

            modelBuilder.Entity("EvenementPersoon", b =>
                {
                    b.HasOne("BerghAdmin.Data.Persoon", null)
                        .WithMany()
                        .HasForeignKey("DeelnemersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerghAdmin.Data.Evenement", null)
                        .WithMany()
                        .HasForeignKey("IsDeelnemerVanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BerghAdmin.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BerghAdmin.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BerghAdmin.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersoonRol", b =>
                {
                    b.HasOne("BerghAdmin.Data.Persoon", null)
                        .WithMany()
                        .HasForeignKey("PersonenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerghAdmin.Data.Rol", null)
                        .WithMany()
                        .HasForeignKey("RollenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersoonVerzondenMail", b =>
                {
                    b.HasOne("BerghAdmin.Data.Persoon", null)
                        .WithMany()
                        .HasForeignKey("GeadresseerdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerghAdmin.Data.VerzondenMail", null)
                        .WithMany()
                        .HasForeignKey("GeadresseerdenId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersoonVerzondenMail1", b =>
                {
                    b.HasOne("BerghAdmin.Data.Persoon", null)
                        .WithMany()
                        .HasForeignKey("ccGeadresseerdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerghAdmin.Data.VerzondenMail", null)
                        .WithMany()
                        .HasForeignKey("ccGeadresseerdenId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersoonVerzondenMail2", b =>
                {
                    b.HasOne("BerghAdmin.Data.Persoon", null)
                        .WithMany()
                        .HasForeignKey("bccGeadresseerdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BerghAdmin.Data.VerzondenMail", null)
                        .WithMany()
                        .HasForeignKey("bccGeadresseerdenId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BerghAdmin.Data.Organisatie", b =>
                {
                    b.HasOne("BerghAdmin.Data.Persoon", "ContactPersoon")
                        .WithMany()
                        .HasForeignKey("ContactPersoonId");

                    b.Navigation("ContactPersoon");
                });
#pragma warning restore 612, 618
        }
    }
}
