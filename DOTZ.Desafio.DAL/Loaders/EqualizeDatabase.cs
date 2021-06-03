using DOTZ.Desafio.DAL.Interface.Loaders;

namespace DOTZ.Desafio.DAL.Loaders
{
    public class EqualizeDatabase : IEqualizeDatabase
    {
        private readonly DataBaseContext context;

        public EqualizeDatabase(DataBaseContext context)
        {
            this.context = context;
        }

        public void Sync()
        {
            new UserEqualizeDatabase().Equalize(context);
            new ProductEqualizeDatabase().Equalize(context);
        }
    }
}