using AutoMapper;
using Monets.Api.Filters;
using Monets.Api.Database;
using Monets.Model.Requests;
using Monets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Monets.Api.Interfaces;
using Monets.API.Helpers;
using System.IO;

namespace Monets.Api.Services
{
    public class JeloService : BaseCRUDService<Model.Jelo,Jelo,JeloSearchRequest,JeloUpsertRequest,JeloUpsertRequest>, IJeloService
    {
        private ImageHelper imageHelper = new ImageHelper();

        public JeloService(MonetsContext context, IMapper mapper) : base(context, mapper)
        {}

        public async override Task<List<Model.Jelo>> Get(JeloSearchRequest search = null)    
        {
            var entity = Context.Set<Database.Jelo>().Include("Rejting").Include("Kategorija").AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.NazivJela.Contains(search.Naziv));
            }

            if (search.JeloId != 0)
            {
                entity = entity.Where(x => x.JeloId==search.JeloId);
            }

            if (search.KategorijaId != 0)
            {
                entity = entity.Where(x => x.KategorijaId == search.KategorijaId);
            }

            var list = await entity.ToListAsync();
            var result = _mapper.Map<List<Model.Jelo>>(list);

            foreach (var item in result)
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Jelo", $"{item.SlikaPutanja}");
                item.Slika = await imageHelper.FindImage(directory);
            }

            return result;
        }

        private class BrojJelaURezervaciji { public int broj { get; set; } public int jeloId { get; set; }}

        public async Task<int> GetPreporucenoJelo(int klijentId)
        {
            var listaJelaKlijenta = await Context.JeloRezervacija.Include("Rezervacija.Klijent").Where(x => x.Rezervacija.KlijentId == klijentId).ToListAsync();

            List<BrojJelaURezervaciji> brojJelaURezervaciji = new List<BrojJelaURezervaciji>();
            bool flag = false;
            int tempJeloId = 1;

            foreach (var item in listaJelaKlijenta)
            {
                foreach (var item2 in brojJelaURezervaciji)
                {
                    if (item2.jeloId == item.JeloId)
                    {
                        item2.broj++;
                        flag = true;
                        tempJeloId = item.JeloId;
                    }
                }
                if (!flag)
                {
                    brojJelaURezervaciji.Add(new BrojJelaURezervaciji { broj=1, jeloId = item.JeloId });
                }
            }

            int najviseKoristenoJelo = brojJelaURezervaciji.OrderByDescending(x=> x.broj).Take(1).Select(x=> x.jeloId).FirstOrDefault();
            if(najviseKoristenoJelo == 0)
            {
                najviseKoristenoJelo = tempJeloId;
            }


            return najviseKoristenoJelo;
        }

        public async override Task<Model.Jelo> GetById(int id)
        {
            var entity = await Context.Jelo.Include("Kategorija").Where(x=> x.JeloId==id).SingleOrDefaultAsync();
            
            if (entity == null)
            {
                throw new UserException("Jelo sa traženim id-om nije pronađeno!");
            }

            var result = _mapper.Map<Model.Jelo>(entity);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Jelo", $"{result.SlikaPutanja}");
            result.Slika = await imageHelper.FindImage(directory);

            return result;
        }

        public async override Task<Model.Jelo> Insert(JeloUpsertRequest request)
        {
            if (await ProvjeriDaLiPostoji(request))
            {
                throw new UserException($"Jelo ¨{request.NazivJela}¨ je već dodano.");
            }

            var listaKategorija = Context.Kategorija.Select(x=> x.KategorijaId).ToList();

            if (!listaKategorija.Contains(request.KategorijaId))
            {
                throw new UserException("Kategorija nije validna");
            }

            if(request.Cijena<0)
            {
                throw new UserException("Cijena nije validna");
            }

            if (request.VrijemeIzradeUminutama < 1)
            {
                throw new UserException("Vrijeme izrade nije validno");
            }

            if (request.NazivJela.Length<3)
            {
                throw new UserException("Naziv jela nije validan");
            }

            var entity = _mapper.Map<Database.Jelo>(request);
            await Context.Jelo.AddAsync(entity);
            await Context.SaveChangesAsync();

            entity.SlikaPutanja = await imageHelper.InsertImage("Jelo", entity.JeloId, request.SlikaPutanja, request.Slika);
            await Context.SaveChangesAsync();

            return _mapper.Map<Model.Jelo>(entity);
        }

        public async override Task<Model.Jelo> Update(int id, JeloUpsertRequest request)
        {
            var entity = await Context.Jelo.FindAsync(id);

            if (entity == null)
            {
                throw new UserException("Jelo sa traženim id-om nije pronađeno!");
            }

            if (request.Cijena < 0)
            {
                throw new UserException("Cijena nije validna");
            }

            if (request.VrijemeIzradeUminutama < 1)
            {
                throw new UserException("Vrijeme izrade nije validno");
            }

            if (request.NazivJela.Length < 3)
            {
                throw new UserException("Naziv jela nije validan");
            }

            if (ProvjeriPromjene(entity, request) == false)
            {
                throw new UserException("Niste izvršili nikakve promjene u atributima!");

            }
            await UpdateEntity(entity, request);
            return _mapper.Map<Model.Jelo>(entity);
        }

        public async override Task<bool> Delete(int id)
        {
            var entity = await Context.Jelo.Where(x => x.JeloId == id).SingleOrDefaultAsync();

            if (entity == null)
            {
                throw new UserException("Jelo nije pronađeno!");
            }

            try
            {

                entity.Status = false;
                await Context.SaveChangesAsync();
                //return _mapper.Map<Model.Jelo>(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new UserException("Brisanje nije bilo moguće." + ex.InnerException);
            }
        }

        private async Task UpdateEntity(Jelo entity, JeloUpsertRequest request)
        {
            if (request.NazivJela != null && request.NazivJela != entity.NazivJela) entity.NazivJela = request.NazivJela;
            if (request.Cijena != entity.Cijena) entity.Cijena = request.Cijena;
            if (request.OpisJela != entity.OpisJela) entity.OpisJela = request.OpisJela;
            if (request.VrijemeIzradeUminutama != entity.VrijemeIzradeUminutama) entity.VrijemeIzradeUminutama = request.VrijemeIzradeUminutama;
            if (request.KategorijaId != entity.KategorijaId) entity.KategorijaId = request.KategorijaId;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.SlikaPutanja) entity.SlikaPutanja = await imageHelper.ReplaceImage("Jelo", entity.JeloId, entity.SlikaPutanja, request.SlikaPutanja, request.Slika);

            await Context.SaveChangesAsync();
        }


        private bool ProvjeriPromjene(Jelo entity, JeloUpsertRequest request)
        {
            if (request.NazivJela != entity.NazivJela) return true;
            if (request.Cijena != entity.Cijena) return true;
            if (request.OpisJela != entity.OpisJela) return true;
            if (request.VrijemeIzradeUminutama!= entity.VrijemeIzradeUminutama) return true;
            if (request.KategorijaId != entity.KategorijaId) return true;
            if (request.SlikaPutanja != null && request.Slika != null && request.SlikaPutanja != entity.SlikaPutanja) return true;

            return false;
        }

        private async Task<bool> ProvjeriDaLiPostoji(JeloUpsertRequest request)
        {
            return await Context.Jelo.AnyAsync(s => s.NazivJela == request.NazivJela);
        }
    }
}
