using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Monets.Api.Database
{
    public partial class MonetsContext : DbContext
    {
        public MonetsContext()
        {
        }

        public MonetsContext(DbContextOptions<MonetsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jelo> Jelo { get; set; }
        public virtual DbSet<JeloMeni> JeloMeni { get; set; }
        public virtual DbSet<Grad>Grad{ get; set; }
        public virtual DbSet<JeloRezervacija> JeloRezervacija { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<KorisnickiRacun> KorisnickiRacun { get; set; }
        public virtual DbSet<Klijent> Klijent { get; set; }
        public virtual DbSet<UposlenikUloga> UposlenikUloga{ get; set; }
        public virtual DbSet<Meni> Meni { get; set; }
        public virtual DbSet<Rejting> Rejting { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Stol> Stol { get; set; }
        public virtual DbSet<Transakcija> Transakcija { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Uposlenik> Uposlenik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Monets; user=sa; Password=QWEasd123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
