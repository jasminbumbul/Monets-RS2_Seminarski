using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monets.Api.Interfaces
{
    public interface IPreporukaService
    {
        Task<List<Model.Jelo>> Preporuka(int id);
    }
}
