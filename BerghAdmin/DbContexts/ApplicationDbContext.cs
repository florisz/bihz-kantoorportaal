﻿using BerghAdmin.Authorization;
using BerghAdmin.Data.Kentaa;
using BerghAdmin.Pages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BerghAdmin.DbContexts;

public class ApplicationDbContext : IdentityUserContext<User, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Persoon>? Personen { get; set; }
    public DbSet<Rol>? Rollen { get; set; }
    public DbSet<Document>? Documenten { get; set; }
    public DbSet<Factuur>? Facturen { get; set; }
    public DbSet<Betaling>? Betalingen { get; set; }
    public DbSet<VerzondenMail>? VerzondenMails { get; set; }
    public DbSet<Donatie>? Donaties { get; set; }
    public DbSet<Fietstocht>? Fietstochten { get; set; }
    public DbSet<Golfdag>? Golfdagen { get; set; }
    public DbSet<Sponsor>? Sponsoren{ get; set; }
    public DbSet<Ambassadeur>? Ambassadeurs{ get; set; }
    public DbSet<GolfdagSponsor>? GolfdagSponsoren { get; set; }
    public DbSet<BihzActie>? BihzActies { get; set; }
    public DbSet<BihzDonatie>? BihzDonaties { get; set; }
    public DbSet<BihzProject>? BihzProjects { get; set; }
    public DbSet<BihzUser>? BihzUsers { get; set; }
    public DbSet<MagazineJaar>? MagazineJaren { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Persoon
        modelBuilder
            .Entity<Persoon>()
            .HasMany(p => p.Geadresseerden)
            .WithMany(m => m.Geadresseerden)
            .UsingEntity(j => j.ToTable("MailGeadresseerden"));
        modelBuilder
            .Entity<Persoon>()
            .HasMany(p => p.ccGeadresseerden)
            .WithMany(m => m.ccGeadresseerden)
            .UsingEntity(j => j.ToTable("MailccGeadresseerden"));
        modelBuilder
            .Entity<Persoon>()
            .HasMany(p => p.bccGeadresseerden)
            .WithMany(m => m.bccGeadresseerden)
            .UsingEntity(j => j.ToTable("MailbccGeadresseerden"));
        modelBuilder
            .Entity<Persoon>()
            .HasIndex(p => new { p.IsVerwijderd, p.EmailAdres })
            .IsUnique();
        modelBuilder
            .Entity<Persoon>()
            .HasMany(p => p.Rollen)
            .WithMany(r => r.Personen);
        modelBuilder
            .Entity<Persoon>()
            .HasMany(persoon => persoon.Fietstochten)
            .WithMany(fietstocht => fietstocht.Deelnemers);
        modelBuilder
            .Entity<Persoon>()
            .HasMany(persoon => persoon.Golfdagen)
            .WithMany(golfdag => golfdag.Deelnemers);
        // Persoon - End

        // Evenementen
        modelBuilder
            .Entity<Fietstocht>()
            .ToTable("Fietstochten", tb => tb.Property(ft => ft.Id).HasColumnName("FietstochtId"));
        modelBuilder
            .Entity<Golfdag>()
            .ToTable("Golfdagen", tb => tb.Property(gd => gd.Id).HasColumnName("GolfdagId"));
        modelBuilder
            .Entity<Fietstocht>()
            .HasMany(f => f.Deelnemers)
            .WithMany(p => p.Fietstochten);
        modelBuilder
            .Entity<Golfdag>()
            .HasMany(g => g.Deelnemers)
            .WithMany(p => p.Golfdagen);
        modelBuilder
            .Entity<Golfdag>()
            .HasMany(g => g.Sponsoren)
            .WithMany(s => s.GolfdagenGesponsored);
        // Evenementen - end

        // Sponsor
        modelBuilder
            .Entity<Sponsor>()
            .HasMany(e => e.Facturen);
        // Sponsor - end

        // Ambassadeurs
        modelBuilder
            .Entity<Ambassadeur>()
            .HasOne(a => a.ContactPersoon1);
        modelBuilder
            .Entity<Ambassadeur>()
            .HasOne(a => a.ContactPersoon2);
        modelBuilder
            .Entity<Ambassadeur>()
            .HasOne(a => a.Compagnon);
        modelBuilder
            .Entity<Ambassadeur>()
            .HasMany(a => a.MagazineJaren);
        modelBuilder
            .Entity<Ambassadeur>()
            .Property(d => d.ToegezegdBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<Ambassadeur>()
            .Property(d => d.TotaalBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<Ambassadeur>()
            .ToTable("Ambassadeur");
        // Ambassadeurs - end

        // GolfdagSponsor 
        modelBuilder
            .Entity<GolfdagSponsor>()
            .HasOne(g => g.Compagnon);
        modelBuilder
            .Entity<GolfdagSponsor>()
            .HasOne(g => g.ContactPersoon1);
        modelBuilder
            .Entity<GolfdagSponsor>()
            .ToTable("GolfdagSponsor");
        // GolfdagSponsor - end

        // Facturen
        modelBuilder
            .Entity<Factuur>()
            .HasOne(f => f.FactuurTekst);
        modelBuilder
            .Entity<Factuur>()
            .HasOne(f => f.EmailTekst);
        // Facturen - end

        // Money fields
        modelBuilder
            .Entity<Donatie>()
            .Property(d => d.Bedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<Betaling>()
            .Property(f => f.Bedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<Factuur>()
            .Property(f => f.Bedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<Ambassadeur>()
            .Property(a => a.ToegezegdBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<Ambassadeur>()
            .Property(a => a.TotaalBedrag).HasPrecision(18, 2);
        // Money fields - end

        // Users
        modelBuilder
            .Entity<BihzUser>()
            .HasIndex(u => u.UserId)
            .IsUnique();
        // Users - end

        // BihzDonatie
        modelBuilder
            .Entity<BihzDonatie>()
            .ToTable("BihzDonaties");
        modelBuilder
            .Entity<BihzDonatie>()
            .Property(p => p.DonatieBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzDonatie>()
            .Property(p => p.TransactionKosten).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzDonatie>()
            .Property(p => p.RegistratieFeeBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzDonatie>()
            .Property(p => p.TotaalBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzDonatie>()
            .Property(p => p.NettoBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzDonatie>()
            .HasIndex(d => d.DonationId)
            .IsUnique();
        // BihzDonatie

        // BihzActie
        modelBuilder
            .Entity<BihzActie>()
            .Property(p => p.DoelBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzActie>()
            .Property(p => p.TotaalBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzActie>()
            .HasIndex(a => a.ActionId)
            .IsUnique();
        // BihzActie

        // BihzProject
        modelBuilder
            .Entity<BihzProject>()
            .Property(p => p.DoelBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzProject>()
            .Property(p => p.TotaalBedrag).HasPrecision(18, 2);
        modelBuilder
            .Entity<BihzProject>()
            .HasIndex(p => p.ProjectId)
            .IsUnique();
        // BihzProject
    }

}
