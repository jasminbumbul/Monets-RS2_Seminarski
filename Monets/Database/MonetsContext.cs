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

        public virtual DbSet<Favorit> Favorit { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Jelo> Jelo { get; set; }
        public virtual DbSet<JeloMeni> JeloMeni { get; set; }
        public virtual DbSet<JeloRezervacija> JeloRezervacija { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Klijent> Klijent { get; set; }
        public virtual DbSet<KorisnickiRacun> KorisnickiRacun { get; set; }
        public virtual DbSet<Meni> Meni { get; set; }
        public virtual DbSet<Rejting> Rejting { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Stol> Stol { get; set; }
        public virtual DbSet<Transakcija> Transakcija { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Uposlenik> Uposlenik { get; set; }
        public virtual DbSet<UposlenikUloga> UposlenikUloga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=monets-sql, 1433;Initial Catalog=180070; user=sa; Password=Password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Favorit>(entity =>
            {
                entity.ToTable("Favorit");

                entity.HasIndex(e => e.JeloId, "IX_Favorit_JeloId");

                entity.HasIndex(e => e.KlijentId, "IX_Favorit_KlijentId");

                entity.HasOne(d => d.Jelo)
                    .WithMany(p => p.Favorit)
                    .HasForeignKey(d => d.JeloId);

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Favorit)
                    .HasForeignKey(d => d.KlijentId);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("Grad");
            });

            modelBuilder.Entity<Jelo>(entity =>
            {
                entity.ToTable("Jelo");

                entity.HasIndex(e => e.KategorijaId, "IX_Jelo_KategorijaId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Jelo)
                    .HasForeignKey(d => d.KategorijaId);
            });

            modelBuilder.Entity<JeloMeni>(entity =>
            {
                entity.ToTable("JeloMeni");

                entity.HasIndex(e => e.JeloId, "IX_JeloMeni_JeloId");

                entity.HasIndex(e => e.MeniId, "IX_JeloMeni_MeniId");

                entity.HasOne(d => d.Jelo)
                    .WithMany(p => p.JeloMeni)
                    .HasForeignKey(d => d.JeloId);

                entity.HasOne(d => d.Meni)
                    .WithMany(p => p.JeloMeni)
                    .HasForeignKey(d => d.MeniId);
            });

            modelBuilder.Entity<JeloRezervacija>(entity =>
            {
                entity.ToTable("JeloRezervacija");

                entity.HasIndex(e => e.JeloId, "IX_JeloRezervacija_JeloId");

                entity.HasIndex(e => e.RezervacijaId, "IX_JeloRezervacija_RezervacijaId");

                entity.HasOne(d => d.Jelo)
                    .WithMany(p => p.JeloRezervacija)
                    .HasForeignKey(d => d.JeloId);

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.JeloRezervacija)
                    .HasForeignKey(d => d.RezervacijaId);
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.ToTable("Kategorija");
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.ToTable("Klijent");

                entity.HasIndex(e => e.GradId, "IX_Klijent_GradId");

                entity.HasIndex(e => e.KorisnickiRacunId, "IX_Klijent_KorisnickiRacunId")
                    .IsUnique();

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Klijent)
                    .HasForeignKey(d => d.GradId);

                entity.HasOne(d => d.KorisnickiRacun)
                    .WithOne(p => p.Klijent)
                    .HasForeignKey<Klijent>(d => d.KorisnickiRacunId);
            });

            modelBuilder.Entity<KorisnickiRacun>(entity =>
            {
                entity.ToTable("KorisnickiRacun");

                entity.Property(e => e.EmailVerified)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.Guid).HasColumnName("GUID");

                entity.Property(e => e.PassCodeCreated).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");
            });

            modelBuilder.Entity<Meni>(entity =>
            {
                entity.ToTable("Meni");
            });

            modelBuilder.Entity<Rejting>(entity =>
            {
                entity.ToTable("Rejting");

                entity.HasIndex(e => e.JeloId, "IX_Rejting_JeloId");

                entity.HasIndex(e => e.KlijentId, "IX_Rejting_KlijentId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Jelo)
                    .WithMany(p => p.Rejting)
                    .HasForeignKey(d => d.JeloId);

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Rejting)
                    .HasForeignKey(d => d.KlijentId);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.ToTable("Rezervacija");

                entity.HasIndex(e => e.KlijentId, "IX_Rezervacija_KlijentId");

                entity.HasIndex(e => e.StolId, "IX_Rezervacija_StolId");

                entity.Property(e => e.KrajRezervacije).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.OnlinePlacanje)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KlijentId);

                entity.HasOne(d => d.Stol)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.StolId);
            });

            modelBuilder.Entity<Stol>(entity =>
            {
                entity.ToTable("Stol");
            });

            modelBuilder.Entity<Transakcija>(entity =>
            {
                entity.ToTable("Transakcija");

                entity.HasIndex(e => e.KorisnikId, "IX_Transakcija_KorisnikId");

                entity.HasIndex(e => e.RezervacijaId, "IX_Transakcija_RezervacijaId");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Transakcija)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Transakcija)
                    .HasForeignKey(d => d.RezervacijaId);
            });

            modelBuilder.Entity<Uloga>(entity =>
            {
                entity.ToTable("Uloga");
            });

            modelBuilder.Entity<Uposlenik>(entity =>
            {
                entity.ToTable("Uposlenik");

                entity.HasIndex(e => e.GradId, "IX_Uposlenik_GradId");

                entity.HasIndex(e => e.KorisnickiRacunId, "IX_Uposlenik_KorisnickiRacunId")
                    .IsUnique();

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Uposlenik)
                    .HasForeignKey(d => d.GradId);

                entity.HasOne(d => d.KorisnickiRacun)
                    .WithOne(p => p.Uposlenik)
                    .HasForeignKey<Uposlenik>(d => d.KorisnickiRacunId);
            });

            modelBuilder.Entity<UposlenikUloga>(entity =>
            {
                entity.ToTable("UposlenikUloga");

                entity.HasIndex(e => e.UlogaId, "IX_UposlenikUloga_UlogaId");

                entity.HasIndex(e => e.UposlenikId, "IX_UposlenikUloga_UposlenikId");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.UposlenikUloga)
                    .HasForeignKey(d => d.UlogaId);

                entity.HasOne(d => d.Uposlenik)
                    .WithMany(p => p.UposlenikUloga)
                    .HasForeignKey(d => d.UposlenikId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
