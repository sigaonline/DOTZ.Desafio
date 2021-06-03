using DOTZ.Desafio.Model.Entities;

namespace DOTZ.Desafio.DAL.Interface.Entities
{
    public class Product : BaseEntity
    {

        public string Description { get; set; }
        public int PointsValue { get; set; }
    }
}
