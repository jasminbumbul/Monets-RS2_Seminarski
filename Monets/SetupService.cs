using Microsoft.EntityFrameworkCore;
using Monets.Api.Database;

namespace Monets.Api
{
    public class SetupService
    {
        public void Init(MonetsContext context)
        {
            context.Database.Migrate();

            ////add new new data or update data
            //if (!context.JediniceMjeres.Any(x => x.Naziv == "Test"))
            //{
            //    context.JediniceMjeres.Add(new JediniceMjere() { Naziv = "Test" });
            //}

            context.SaveChanges();
        }
    }
}
