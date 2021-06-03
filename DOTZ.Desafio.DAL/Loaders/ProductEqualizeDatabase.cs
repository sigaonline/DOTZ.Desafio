using System;
using System.Linq;

namespace DOTZ.Desafio.DAL.Loaders
{
    public class ProductEqualizeDatabase
    {
        public void Equalize(DataBaseContext context)
        {
            var registerInDatabase = context.Products;
            var querySourceInDataLoader = new ProductDataLoader().Load().ToList();

            var idsOnDatabase = registerInDatabase.Select(e => e.Id);

            var divisionLocalToInsert = querySourceInDataLoader.Where(x => !idsOnDatabase.Contains(x.Id));
            context.AddRange(divisionLocalToInsert);

            context.SaveChanges();
        }
    }
}
