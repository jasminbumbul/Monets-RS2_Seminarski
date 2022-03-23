using AutoMapper;
using Monets.Api.Database;
using Monets.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface ITransakcijaService
    {
        public List<Model.Transakcija> Get(TransakcijaSearchRequest request = null);

        public  Model.Transakcija GetById(int id);

        public Model.Transakcija Insert(Model.Transakcija request);

        public  bool Delete(int id);
    }
}
