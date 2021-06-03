using DOTZ.Desafio.Model.Entities;

namespace DOTZ.Desafio.DAL.Interface.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
