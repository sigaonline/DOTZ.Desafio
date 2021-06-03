using System;
using System.Linq;

namespace DOTZ.Desafio.DAL.Loaders
{
    public class UserEqualizeDatabase
    {
        public void Equalize(DataBaseContext context)
        {
            var registerInDatabase = context.Users;
            var querySourceInDataLoader = new UserDataLoader().Load().ToList();

            var idsOnDatabase = registerInDatabase.Select(e => e.Id);

            var divisionLocalToInsert = querySourceInDataLoader.Where(x => !idsOnDatabase.Contains(x.Id));
            context.AddRange(divisionLocalToInsert);

            context.SaveChanges();
        }
    }
}
