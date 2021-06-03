using DOTZ.Desafio.Model.Entities;

namespace DOTZ.Desafio.DAL.Interface.Entities
{
    public class Discharge : BaseEntity
    {

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int PointsValue { get; set; }
    }
}
