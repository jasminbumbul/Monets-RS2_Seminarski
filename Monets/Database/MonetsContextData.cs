using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Monets.Api.Helper;

#nullable disable

namespace Monets.Api.Database
{
    public partial class MonetsContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            #region Grad
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 1,
                Naziv = "Sarajevo"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 2,
                Naziv = "Mostar"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 3,
                Naziv = "Bugojno"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 4,
                Naziv = "Gornji Vakuf"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 5,
                Naziv = "Tuzla"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 6,
                Naziv = "Zenica"
            });
            modelBuilder.Entity<Grad>().HasData(new Grad()
            {
                GradId = 7,
                Naziv = "Bihać"
            });
            #endregion

            #region KorisnickiRacun

            KorisnickiRacun k1 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 1,
                Ime = "Desktop",
                Prezime = "Korisnik",
                Email = "desktop@monets.com",
                Telefon = "061-222-333",
                DatumRodjenja = new DateTime(1991, 05, 23),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "profile_pic.png",
                KorisnickoIme = "desktop",
                DatumIzmjene = new DateTime(2021, 04, 12),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };
            k1.LozinkaSalt = HashGenerator.GenerateSalt();
            k1.LozinkaHash = HashGenerator.GenerateHash(k1.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k1);

            KorisnickiRacun k2 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 2,
                Ime = "Uposlenik1",
                Prezime = "Korisnik",
                Email = "uposlenik1@monets.com",
                Telefon = "061-111-333",
                DatumRodjenja = new DateTime(1995, 12, 03),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "profile_pic.png",
                KorisnickoIme = "uposlenik1",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };
            k2.LozinkaSalt = HashGenerator.GenerateSalt();
            k2.LozinkaHash = HashGenerator.GenerateHash(k2.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k2);

            KorisnickiRacun k3 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 3,
                Ime = "Uposlenik2",
                Prezime = "Korisnik2",
                Email = "uposlenik2@monets.com",
                Telefon = "061-111-4444",
                DatumRodjenja = new DateTime(1985, 05, 13),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "profile_pic.png",
                KorisnickoIme = "uposlenik2",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };
            k3.LozinkaSalt = HashGenerator.GenerateSalt();
            k3.LozinkaHash = HashGenerator.GenerateHash(k3.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k3);

            KorisnickiRacun k4 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 4,
                Ime = "Uposlenik3",
                Prezime = "Korisnik3",
                Email = "uposlenik3@monets.com",
                Telefon = "062-333-333",
                DatumRodjenja = new DateTime(1982, 05, 03),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "profile_pic.png",
                KorisnickoIme = "uposlenik2",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };
            k4.LozinkaSalt = HashGenerator.GenerateSalt();
            k4.LozinkaHash = HashGenerator.GenerateHash(k4.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k4);

            KorisnickiRacun k5 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 5,
                Ime = "Uposlenik4",
                Prezime = "Korisnik4",
                Email = "uposlenik4@monets.com",
                Telefon = "063-123-323",
                DatumRodjenja = new DateTime(1989, 07, 21),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "profile_pic.png",
                KorisnickoIme = "uposlenik4",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };
            k5.LozinkaSalt = HashGenerator.GenerateSalt();
            k5.LozinkaHash = HashGenerator.GenerateHash(k5.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k5);

            KorisnickiRacun k6 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 6,
                Ime = "Uposlenik5",
                Prezime = "Korisnik5",
                Email = "uposlenik5@monets.com",
                Telefon = "063-423-444",
                DatumRodjenja = new DateTime(1999, 07, 11),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "profile_pic.png",
                KorisnickoIme = "uposlenik5",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k6.LozinkaSalt = HashGenerator.GenerateSalt();
            k6.LozinkaHash = HashGenerator.GenerateHash(k6.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k6);

            KorisnickiRacun k7 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 7,
                Ime = "Uposlenik6",
                Prezime = "Korisnik6",
                Email = "uposlenik6@monets.com",
                Telefon = "062-223-666",
                DatumRodjenja = new DateTime(1992, 07, 18),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "profile_pic.png",
                KorisnickoIme = "uposlenik6",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k7.LozinkaSalt = HashGenerator.GenerateSalt();
            k7.LozinkaHash = HashGenerator.GenerateHash(k7.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k7);

            KorisnickiRacun k8 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 8,
                Ime = "Mobile",
                Prezime = "Korisnik",
                Email = "mobile@monets.com",
                Telefon = "062-223-666",
                DatumRodjenja = new DateTime(1999, 07, 18),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "mobile",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k8.LozinkaSalt = HashGenerator.GenerateSalt();
            k8.LozinkaHash = HashGenerator.GenerateHash(k8.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k8);

            KorisnickiRacun k9 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 9,
                Ime = "Klijent",
                Prezime = "Korisnik",
                Email = "klijent@monets.com",
                Telefon = "063-223-666",
                DatumRodjenja = new DateTime(1999, 07, 18),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "Klijent",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k9.LozinkaSalt = HashGenerator.GenerateSalt();
            k9.LozinkaHash = HashGenerator.GenerateHash(k9.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k9);

            KorisnickiRacun k10 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 10,
                Ime = "Klijent1",
                Prezime = "Korisnik1",
                Email = "klijent1@monets.com",
                Telefon = "061-123-966",
                DatumRodjenja = new DateTime(2001, 03, 08),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "klijent1",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k10.LozinkaSalt = HashGenerator.GenerateSalt();
            k10.LozinkaHash = HashGenerator.GenerateHash(k10.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k10);

            KorisnickiRacun k11 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 11,
                Ime = "Klijent2",
                Prezime = "Korisnik2",
                Email = "klijent2@monets.com",
                Telefon = "061-123-966",
                DatumRodjenja = new DateTime(1992, 11, 16),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "klijent2",
                DatumIzmjene = new DateTime(2021, 05, 22),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k11.LozinkaSalt = HashGenerator.GenerateSalt();
            k11.LozinkaHash = HashGenerator.GenerateHash(k11.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k11);

            KorisnickiRacun k12 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 12,
                Ime = "Klijent3",
                Prezime = "Korisnik3",
                Email = "klijent3@monets.com",
                Telefon = "061-923-922",
                DatumRodjenja = new DateTime(1995, 12, 06),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "klijent3",
                DatumIzmjene = new DateTime(2021, 03, 04),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };


            k12.LozinkaSalt = HashGenerator.GenerateSalt();
            k12.LozinkaHash = HashGenerator.GenerateHash(k12.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k12);

            KorisnickiRacun k13 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 13,
                Ime = "Klijent4",
                Prezime = "Korisnik4",
                Email = "klijent4@monets.com",
                Telefon = "061-923-922",
                DatumRodjenja = new DateTime(1998, 02, 06),
                Adresa = "Adresa BB",
                Status = false,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "klijent4",
                DatumIzmjene = new DateTime(2021, 03, 07),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k13.LozinkaSalt = HashGenerator.GenerateSalt();
            k13.LozinkaHash = HashGenerator.GenerateHash(k13.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k13);

            KorisnickiRacun k14 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 14,
                Ime = "Klijent5",
                Prezime = "Korisnik5",
                Email = "klijent5@monets.com",
                Telefon = "061-923-922",
                DatumRodjenja = new DateTime(1998, 08, 16),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "klijent5",
                DatumIzmjene = new DateTime(2021, 05, 07),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k14.LozinkaSalt = HashGenerator.GenerateSalt();
            k14.LozinkaHash = HashGenerator.GenerateHash(k14.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k14);

            KorisnickiRacun k15 = new KorisnickiRacun()
            {
                KorisnickiRacunId = 15,
                Ime = "Klijent6",
                Prezime = "Korisnik6",
                Email = "klijent6@monets.com",
                Telefon = "061-223-122",
                DatumRodjenja = new DateTime(1995, 03, 11),
                Adresa = "Adresa BB",
                Status = true,
                SlikaPutanja = "mobile_user.jpg",
                KorisnickoIme = "klijent6",
                DatumIzmjene = new DateTime(2021, 06, 03),
                EmailVerified = true,
                DatumKreiranja = DateTime.Now
            };

            k15.LozinkaSalt = HashGenerator.GenerateSalt();
            k15.LozinkaHash = HashGenerator.GenerateHash(k15.LozinkaSalt, "test");

            modelBuilder.Entity<KorisnickiRacun>().HasData(k15);
            #endregion

            #region Klijent

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 1,
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 8,
            });

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 2,
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 9
            });

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 3,
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 10
            });

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 4,
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 11
            });

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 5,
                Status = false,
                GradId = 1,
                KorisnickiRacunId = 12
            });

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 6,
                Status = false,
                GradId = 1,
                KorisnickiRacunId = 13
            });

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 7,
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 14
            });

            modelBuilder.Entity<Klijent>().HasData(new Klijent()
            {
                KlijentId = 8,
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 15
            });
            #endregion

            #region Uposlenik

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 1,
                DatumZaposlenja = new DateTime(2021, 03, 12),
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 1
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 2,
                DatumZaposlenja = new DateTime(2021, 01, 22),
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 2
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 3,
                DatumZaposlenja = new DateTime(2020, 11, 12),
                Status = true,
                GradId = 2,
                KorisnickiRacunId = 3
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 4,
                DatumZaposlenja = new DateTime(2020, 01, 03),
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 4
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 5,
                DatumZaposlenja = new DateTime(2020, 03, 13),
                Status = true,
                GradId = 1,
                KorisnickiRacunId = 5
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 6,
                DatumZaposlenja = new DateTime(2019, 06, 11),
                Status = false,
                GradId = 1,
                KorisnickiRacunId = 6
            });

            modelBuilder.Entity<Uposlenik>().HasData(new Uposlenik()
            {
                UposlenikId = 7,
                DatumZaposlenja = new DateTime(2019, 06, 11),
                Status = false,
                GradId = 1,
                KorisnickiRacunId = 7
            });

            #endregion

            #region Uloga

            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                UlogaId = 1,
                Naziv = "Admin"
            });

            modelBuilder.Entity<Uloga>().HasData(new Uloga()
            {
                UlogaId = 2,
                Naziv = "Uposlenik"
            });
            #endregion

            #region UposlenikUloga

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 1,
                UposlenikId = 1,
                UlogaId = 1,
                DatumIzmjene = new DateTime(2021, 03, 12)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 2,
                UposlenikId = 1,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 03, 12)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 3,
                UposlenikId = 2,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 4,
                UposlenikId = 3,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 5,
                UposlenikId = 4,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 6,
                UposlenikId = 5,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 7,
                UposlenikId = 6,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            modelBuilder.Entity<UposlenikUloga>().HasData(new UposlenikUloga()
            {
                UposlenikUlogaId = 8,
                UposlenikId = 7,
                UlogaId = 2,
                DatumIzmjene = new DateTime(2021, 01, 22)
            });

            #endregion

            #region Kategorija
            modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
            {
                KategorijaId = 1,
                Naziv = "Pite"
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
            {
                KategorijaId = 2,
                Naziv = "Pize"
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
            {
                KategorijaId = 3,
                Naziv = "Čorbe i supe"
            });

            modelBuilder.Entity<Kategorija>().HasData(new Kategorija()
            {
                KategorijaId = 4,
                Naziv = "Piće"
            });
            #endregion

            #region Jelo

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 1,
                NazivJela = "Burek",
                Cijena = 10,
                KategorijaId = 1,
                OpisJela = "Burek je jelo od razvučenog tijesta sa mesom",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "burek.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 2,
                NazivJela = "Sirnica",
                Cijena = 8,
                KategorijaId = 1,
                OpisJela = "Sirnica je jelo od razvučenog tijesta sa sirom",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "burek.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 3,
                NazivJela = "Zeljanica",
                Cijena = 7,
                KategorijaId = 1,
                OpisJela = "Zeljanica je jelo od razvučenog tijesta sa zeljom",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "burek.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 4,
                NazivJela = "Krompiruša",
                Cijena = 7,
                KategorijaId = 1,
                OpisJela = "Krompiruša je jelo od razvučenog tijesta sa krompirom",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "burek.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 5,
                NazivJela = "Tirit",
                Cijena = 9,
                KategorijaId = 1,
                OpisJela = "Tirit je jelo od razvučenog tijesta sa piletinom",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "burek.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 6,
                NazivJela = "Margarita",
                Cijena = 10,
                KategorijaId = 2,
                OpisJela = "Klasična pizza oljuštenim paradajzom i mocarelom",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "pizza.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 7,
                NazivJela = "Capricosa",
                Cijena = 11,
                KategorijaId = 2,
                OpisJela = "Pizza sa paradaz-pireom, gaudom, šampinjonima i maslinama",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "pizza.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 8,
                NazivJela = "Piza - 4 god. doba",
                Cijena = 12,
                KategorijaId = 2,
                OpisJela = "Sastojci : paradajz, mocarela, gljive, školjke, rakovi, paprika, crne masline, maslinovo ulje, limunov sok",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "pizza.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 9,
                NazivJela = "Pizza četiri sira",
                Cijena = 15,
                KategorijaId = 2,
                OpisJela = "Pizza od 4 sira: mocarela, straćino, fontina, gorgonzola",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "pizza.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 10,
                NazivJela = "Funghi ",
                Cijena = 12,
                KategorijaId = 2,
                OpisJela = "Pizza sa umakom od paradajza, kačkavalj, šampinjoni, ljute papričice",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "pizza.png",
            });
            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 11,
                NazivJela = "Funghi ",
                Cijena = 12,
                KategorijaId = 2,
                OpisJela = "Pizza sa umakom od paradajza, kačkavalj, šampinjoni, ljute papričice",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "pizza.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 12,
                NazivJela = "Grah",
                Cijena = 6,
                KategorijaId = 3,
                OpisJela = "Tradicionalni grah sa sudžukom",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "supa.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 13,
                NazivJela = "Goveđa supa",
                Cijena = 3,
                KategorijaId = 3,
                OpisJela = "Supa od govedine",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "supa.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 22,
                NazivJela = "Pileća supa",
                Cijena = 2,
                KategorijaId = 3,
                OpisJela = "Supa od piletine",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "supa.png",
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 14,
                NazivJela = "Coca Cola",
                Cijena = 3,
                KategorijaId = 4,
                OpisJela = "Klasična Coca Cola",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "drink.png"
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 15,
                NazivJela = "Fanta",
                Cijena = 3,
                KategorijaId = 4,
                OpisJela = "Klasična Fanta",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "drink.png"
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 16,
                NazivJela = "Pepsi",
                Cijena = 3,
                KategorijaId = 4,
                OpisJela = "Klasični pepsi",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "drink.png"
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 17,
                NazivJela = "Cockta",
                Cijena = 3,
                KategorijaId = 4,
                OpisJela = "Klasična Cockta",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "drink.png"
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 18,
                NazivJela = "Mineralna voda",
                Cijena = 2,
                KategorijaId = 4,
                OpisJela = "Mineralna voda",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "drink.png"
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 19,
                NazivJela = "Orangina",
                Cijena = 5,
                KategorijaId = 4,
                OpisJela = "Osvježavajuće bezalkoholno piće od narandže",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "drink.png"
            });

            modelBuilder.Entity<Jelo>().HasData(new Jelo()
            {
                JeloId = 20,
                NazivJela = "Schweppes",
                Cijena = 5,
                KategorijaId = 4,
                OpisJela = "Osvježavajuće bezalkoholno piće",
                Status = true,
                VrijemeIzradeUminutama = 10,
                SlikaPutanja = "drink.png"
            });
            #endregion

            #region Stol
            modelBuilder.Entity<Stol>().HasData(new Stol()
            {
                StolId = 1,
                NazivStola = "Stol br. 1",
                BrojMjesta = 2
            });
            modelBuilder.Entity<Stol>().HasData(new Stol()
            {
                StolId = 2,
                NazivStola = "Stol br. 2",
                BrojMjesta = 3
            });
            modelBuilder.Entity<Stol>().HasData(new Stol()
            {
                StolId = 3,
                NazivStola = "Stol br. 3",
                BrojMjesta = 4
            });
            modelBuilder.Entity<Stol>().HasData(new Stol()
            {
                StolId = 4,
                NazivStola = "Stol br. 4",
                BrojMjesta = 4
            });
            modelBuilder.Entity<Stol>().HasData(new Stol()
            {
                StolId = 5,
                NazivStola = "Stol br. 5",
                BrojMjesta = 4
            });
            #endregion

            #region Rezervacija

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 1,
                DatumKreiranja = new DateTime(2021, 03, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 1,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 2,
                DatumKreiranja = new DateTime(2021, 04, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 1,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 3,
                DatumKreiranja = new DateTime(2021, 05, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 1,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 4,
                DatumKreiranja = new DateTime(2020, 03, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 1,
                OnlinePlacanje = false,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 23,
                DatumKreiranja = new DateTime(2020, 01, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 1,
                OnlinePlacanje = false,
                Placena = true,
                Potvrdjena = true,
                PotvrdjenaKlijent = true,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 3
            });


            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 22,
                DatumKreiranja = new DateTime(2020, 04, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 2,
                OnlinePlacanje = false,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 5,
                DatumKreiranja = new DateTime(2020, 06, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 2,
                OnlinePlacanje = false,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 3
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 6,
                DatumKreiranja = new DateTime(2021, 06, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 2,
                OnlinePlacanje = false,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 3
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 7,
                DatumKreiranja = new DateTime(2021, 12, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 2,
                OnlinePlacanje = false,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 8,
                DatumKreiranja = new DateTime(2021, 07, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 3,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });


            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 9,
                DatumKreiranja = new DateTime(2021, 08, 12),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 3,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 1
            });


            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 10,
                DatumKreiranja = new DateTime(2021, 01, 13),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 3,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 3
            });


            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 11,
                DatumKreiranja = new DateTime(2021, 07, 15),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 4,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 12,
                DatumKreiranja = new DateTime(2021, 07, 16),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 4,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 13,
                DatumKreiranja = new DateTime(2021, 07, 17),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 5,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 14,
                DatumKreiranja = new DateTime(2021, 07, 18),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 5,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 15,
                DatumKreiranja = new DateTime(2021, 07, 19),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 5,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 16,
                DatumKreiranja = new DateTime(2021, 07, 20),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 6,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 1
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 17,
                DatumKreiranja = new DateTime(2021, 07, 21),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 6,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 18,
                DatumKreiranja = new DateTime(2021, 07, 22),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 7,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 3
            });


            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 19,
                DatumKreiranja = new DateTime(2021, 07, 23),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 7,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 4
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 20,
                DatumKreiranja = new DateTime(2021, 07, 24),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 7,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 4
            });

            modelBuilder.Entity<Rezervacija>().HasData(new Rezervacija()
            {
                RezervacijaId = 21,
                DatumKreiranja = new DateTime(2021, 07, 25),
                PocetakRezervacije = new DateTime(2023, 01, 01, 12, 30, 0),
                KrajRezervacije = new DateTime(2023, 01, 01, 13, 30, 0),
                KlijentId = 8,
                OnlinePlacanje = true,
                Placena = false,
                Potvrdjena = false,
                PotvrdjenaKlijent = false,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                StolId = 2
            });



            #endregion

            #region JeloRezervacija
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 1,
                JeloId = 1,
                Kolicina = 4,
                RezervacijaId = 1
            });

            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 2,
                JeloId = 12,
                Kolicina = 3,
                RezervacijaId = 1
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 3,
                JeloId = 13,
                Kolicina = 2,
                RezervacijaId = 1
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 4,
                JeloId = 1,
                Kolicina = 1,
                RezervacijaId = 2
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 5,
                Kolicina = 1,
                JeloId = 5,
                RezervacijaId = 2
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 6,
                JeloId = 7,
                Kolicina = 1,
                RezervacijaId = 3
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 7,
                JeloId = 8,
                Kolicina = 1,
                RezervacijaId = 3
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 8,
                JeloId = 15,
                Kolicina = 4,
                RezervacijaId = 4
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 9,
                JeloId = 16,
                Kolicina = 2,
                RezervacijaId = 4
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 10,
                JeloId = 2,
                Kolicina = 2,
                RezervacijaId = 5
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 11,
                JeloId = 3,
                Kolicina = 3,
                RezervacijaId = 5
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 12,
                JeloId = 3,
                Kolicina = 3,
                RezervacijaId = 6
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 13,
                JeloId = 5,
                Kolicina = 3,
                RezervacijaId = 6
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 14,
                JeloId = 7,
                Kolicina = 2,
                RezervacijaId = 7
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 15,
                JeloId = 2,
                Kolicina = 2,
                RezervacijaId = 7
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 16,
                JeloId = 15,
                Kolicina = 2,
                RezervacijaId = 8
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 35,
                JeloId = 15,
                Kolicina = 2,
                RezervacijaId = 8
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 17,
                JeloId = 12,
                Kolicina = 3,
                RezervacijaId = 9
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 18,
                JeloId = 7,
                Kolicina = 1,
                RezervacijaId = 9
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 19,
                JeloId = 2,
                Kolicina = 2,
                RezervacijaId = 9
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 20,
                JeloId = 9,
                Kolicina = 2,
                RezervacijaId = 10
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 21,
                JeloId = 2,
                Kolicina = 2,
                RezervacijaId = 10
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 22,
                JeloId = 11,
                Kolicina = 6,
                RezervacijaId = 11
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 23,
                JeloId = 18,
                Kolicina = 2,
                RezervacijaId = 11
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 24,
                JeloId = 11,
                Kolicina = 2,
                RezervacijaId = 12
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 25,
                JeloId = 1,
                Kolicina = 2,
                RezervacijaId = 12
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 26,
                JeloId = 3,
                Kolicina = 1,
                RezervacijaId = 13
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 27,
                JeloId = 7,
                Kolicina = 1,
                RezervacijaId = 14
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 28,
                JeloId = 7,
                Kolicina = 1,
                RezervacijaId = 15
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 29,
                JeloId = 9,
                Kolicina = 1,
                RezervacijaId = 16
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 30,
                JeloId = 1,
                Kolicina = 1,
                RezervacijaId = 17
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 31,
                JeloId = 12,
                Kolicina = 2,
                RezervacijaId = 18
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 32,
                JeloId = 19,
                Kolicina = 2,
                RezervacijaId = 19
            });
            modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 33,
                JeloId = 19,
                Kolicina = 2,
                RezervacijaId = 20
            }); modelBuilder.Entity<JeloRezervacija>().HasData(new JeloRezervacija()
            {
                JeloRezervacijaId = 34,
                JeloId = 19,
                Kolicina = 2,
                RezervacijaId = 21
            });

            #endregion

            #region Transakcija

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 1,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 1,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 1
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 2,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 20.00,
                KorisnikId = 1,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 2,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 3,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 15.00,
                KorisnikId = 1,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 3,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 4,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 50.00,
                KorisnikId = 1,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 4,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 5,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 120.00,
                KorisnikId = 1,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 5
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 6,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 1,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 6
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 7,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 1,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 7
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 8,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 8
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 9,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 9,
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 10,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 10
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 11,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 10
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 12,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 10
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 13,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                Status = true,
                RezervacijaId = 10
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 14,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 11,
                Status = true,
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 15,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 11,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 16,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 12,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 17,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 12,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 18,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 12,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 19,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 2,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 12,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 20,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 3,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 12,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 21,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 3,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 13,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 22,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 3,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 13,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 23,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 3,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 14,
                Status = true
            });


            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 24,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 3,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 15,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 25,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 3,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 16,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 26,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 3,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 16,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 27,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 4,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 16,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 28,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 4,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 16,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 29,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 4,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 17,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 30,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 4,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 17,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 31,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 5,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 18,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 32,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 5,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 18,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 33,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 5,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 19,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 34,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 6,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 19,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 35,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 6,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 20,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 36,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 7,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 20,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 37,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 7,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 20,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 38,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 8,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 21,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 39,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 8,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 21,
                Status = true
            });

            modelBuilder.Entity<Transakcija>().HasData(new Transakcija()
            {
                TransakcijaId = 40,
                Datum = new DateTime(2020, 01, 03),
                Iznos = 25.00,
                KorisnikId = 8,
                Sifra = RandomStringGenerator.GenerateRandomCode(6),
                RezervacijaId = 21,
                Status = true
            });
            #endregion

            #region Rejting
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 1,
                KlijentId = 1,
                Ocjena = 5,
                JeloId = 1,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 2,
                KlijentId = 2,
                Ocjena = 4,
                JeloId = 1,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 3,
                KlijentId = 3,
                Ocjena = 4,
                JeloId = 2,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 4,
                KlijentId = 4,
                Ocjena = 4.5,
                JeloId = 3,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 5,
                KlijentId = 5,
                Ocjena = 4.5,
                JeloId = 4,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 6,
                KlijentId = 6,
                Ocjena = 4.5,
                JeloId = 5,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 7,
                KlijentId = 7,
                Ocjena = 4.5,
                JeloId = 6,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 8,
                KlijentId = 8,
                Ocjena = 4.5,
                JeloId = 7,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 9,
                KlijentId = 8,
                Ocjena = 4.5,
                JeloId = 8,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 10,
                KlijentId = 8,
                Ocjena = 4.5,
                JeloId = 9,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 11,
                KlijentId = 7,
                Ocjena = 4.5,
                JeloId = 10,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 12,
                KlijentId = 6,
                Ocjena = 4.5,
                JeloId = 11,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 13,
                KlijentId = 5,
                Ocjena = 4.5,
                JeloId = 12,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 14,
                KlijentId = 6,
                Ocjena = 4.5,
                JeloId = 13,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 15,
                KlijentId = 5,
                Ocjena = 4.5,
                JeloId = 14,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 16,
                KlijentId = 4,
                Ocjena = 4.5,
                JeloId = 15,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 17,
                KlijentId = 4,
                Ocjena = 4.5,
                JeloId = 16,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 18,
                KlijentId = 3,
                Ocjena = 4.5,
                JeloId = 17,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 19,
                KlijentId = 2,
                Ocjena = 4.5,
                JeloId = 18,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 20,
                KlijentId = 1,
                Ocjena = 4.5,
                JeloId = 19,
            });
            modelBuilder.Entity<Rejting>().HasData(new Rejting()
            {
                RejtingId = 21,
                KlijentId = 1,
                Ocjena = 4.5,
                JeloId = 20,
            });
            #endregion
        }
    }
}
