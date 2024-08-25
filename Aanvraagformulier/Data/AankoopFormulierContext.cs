using Microsoft.EntityFrameworkCore;
using Aanvraagformulier.Models;

namespace Aanvraagformulier.Data
{
    public class AankoopFormulierContext : DbContext
    {
        public AankoopFormulierContext(DbContextOptions<AankoopFormulierContext> options)
            : base(options)
        {
        }

        public DbSet<Aankoop> Aankopen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Bijlage> Bijlagen { get; set; }
        public DbSet<Vak> Vakken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Zorg ervoor dat de Aankoop class een Gebruiker heeft en dat de foreign key correct is ingesteld
            modelBuilder.Entity<Aankoop>()
                .HasOne(a => a.Gebruiker)
                .WithMany(g => g.Aankopen)
                .HasForeignKey(a => a.NaamAanvragerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Zorg ervoor dat Product een AankoopId heeft die naar Aankoop verwijst
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Aankoop)
                .WithMany(a => a.Producten)
                .HasForeignKey(p => p.AankoopId)
                .OnDelete(DeleteBehavior.Cascade);

            // Zorg ervoor dat Bijlage een AankoopId heeft die naar Aankoop verwijst
            modelBuilder.Entity<Bijlage>()
                .HasOne(b => b.Aankoop)
                .WithMany(a => a.Bijlagen)
                .HasForeignKey(b => b.AankoopId)
                .OnDelete(DeleteBehavior.Cascade);

            // Unieke indexen op gebruikersnaam en email
            modelBuilder.Entity<Gebruiker>()
                .HasIndex(g => g.Gebruikersnaam)
                .IsUnique();

            modelBuilder.Entity<Gebruiker>()
                .HasIndex(g => g.Email)
                .IsUnique();

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gebruiker>().HasData(
                new Gebruiker
                {
                    Id = 1,
                    Voornaam = "Admin",
                    Achternaam = "Istrator",
                    Initialen = "AI",
                    Gebruikersnaam = "admin",
                    Wachtwoord = "admin", // Dit zou uiteraard in een echte app gehasht moeten zijn
                    Email = "admin@school.nl",
                    Rol = "Beheerder",
                    Verwijderd = false
                }
            );

            modelBuilder.Entity<Vak>().HasData(
                new Vak
                {
                    Id = 1,
                    Naam = "Wiskunde",
                    Verwijderd = false
                },
                new Vak
                {
                    Id = 2,
                    Naam = "Nederlands",
                    Verwijderd = false
                }
            );
        }
    }
}
