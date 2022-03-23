using AutoMapper;
using Monets.Api.Database;
using Monets.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Mapping
{
    public class MonetsProfile:Profile
    {
        public MonetsProfile()
        {
            CreateMap<Jelo,Model.Jelo>();
            CreateMap<JeloUpsertRequest,Jelo>();
            CreateMap<JeloSearchRequest,Jelo>();

            CreateMap<Kategorija, Model.Kategorija>();
            CreateMap<KategorijaSearchRequest,Kategorija>();
            CreateMap<KategorijaUpsertRequest,Kategorija>();

            CreateMap<Meni, Model.Meni>();
            CreateMap<MeniSearchRequest, Meni>();
            CreateMap<MeniUpsertRequest, Meni>();

            CreateMap<JeloMeni, Model.JeloMeni>();
            CreateMap<JeloRezervacija, Model.JeloRezervacija>();

            CreateMap<Rejting, Model.Rejting>();
            CreateMap<RejtingSearchRequest, Rejting>();
            CreateMap<RejtingUpsertRequest, Rejting>();

            CreateMap<Stol, Model.Stol>();
            CreateMap<StolSearchRequest, Stol>();
            CreateMap<StolUpsertRequest, Stol>();

            CreateMap<Favorit, Model.Favorit>().ReverseMap();
            CreateMap<Transakcija, Model.Transakcija>().ReverseMap();

            CreateMap<Rezervacija, Model.Rezervacija>();
            CreateMap<RezervacijaSearchRequest, Rezervacija>();
            CreateMap<RezervacijaUpsertRequest, Rezervacija>();

            CreateMap<Uposlenik, Model.Uposlenik>().ReverseMap(); ;
            CreateMap<UposlenikSearchRequest, Uposlenik>().ReverseMap(); ;
            CreateMap<UposlenikInsertRequest, Uposlenik>().ReverseMap(); ;
            CreateMap<UposlenikUpdateRequest, Uposlenik>().ReverseMap(); ;

            CreateMap<KorisnickiRacun, Model.KorisnickiRacun>().ReverseMap();

            CreateMap<Klijent, Model.Klijent>().ReverseMap();
            CreateMap<KlijentSearchRequest, Klijent>().ReverseMap();
            CreateMap<KlijentInsertRequest, Klijent>().ReverseMap();
            CreateMap<KlijentUpdateRequest, Klijent>().ReverseMap();

            
            CreateMap<Uloga, Model.Uloga>().ReverseMap();
            CreateMap<UposlenikUloga, Model.UposlenikUloga>().ReverseMap();

            CreateMap<Grad, Model.Grad>();

            CreateMap<KorisnickiRacun, KlijentInsertRequest>().ReverseMap();
            CreateMap<KorisnickiRacun, KlijentUpdateRequest>().ReverseMap();
            CreateMap<KorisnickiRacun, UposlenikInsertRequest>().ReverseMap();
            CreateMap<KorisnickiRacun, UposlenikUpdateRequest>().ReverseMap();

            CreateMap<KorisnickiRacun, Model.AuthKorisnickiRacun>().ReverseMap();

            CreateMap<Klijent, Model.Klijent>()
               .ForMember(s => s.Ime, x => x.MapFrom(y => y.KorisnickiRacun.Ime))
               .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiRacun.Prezime))
               .ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiRacun.Email))
               .ForMember(s => s.Telefon, x => x.MapFrom(y => y.KorisnickiRacun.Telefon))
               .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiRacun.KorisnickoIme))
               .ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiRacun.Adresa))
               .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiRacun.DatumRodjenja))
               .ForMember(s => s.SlikaPutanja, x => x.MapFrom(y => y.KorisnickiRacun.SlikaPutanja))
               .ReverseMap();

            CreateMap<Uposlenik, Model.Uposlenik>()
                .ForMember(s => s.Ime, x => x.MapFrom(y => y.KorisnickiRacun.Ime))
                .ForMember(s => s.Prezime, x => x.MapFrom(y => y.KorisnickiRacun.Prezime))
                .ForMember(s => s.Email, x => x.MapFrom(y => y.KorisnickiRacun.Email))
                .ForMember(s => s.Telefon, x => x.MapFrom(y => y.KorisnickiRacun.Telefon))
                .ForMember(s => s.KorisnickoIme, x => x.MapFrom(y => y.KorisnickiRacun.KorisnickoIme))
                .ForMember(s => s.Adresa, x => x.MapFrom(y => y.KorisnickiRacun.Adresa))
                .ForMember(s => s.DatumRodjenja, x => x.MapFrom(y => y.KorisnickiRacun.DatumRodjenja))
                .ForMember(s => s.SlikaPutanja, x => x.MapFrom(y => y.KorisnickiRacun.SlikaPutanja))
                .ReverseMap();

        }
    }
}
