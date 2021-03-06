using DOTZ.Desafio.Model.Entities;

namespace DOTZ.Desafio.DAL.Interface.Entities
{
    public class Location : BaseEntity
    {

        public int UserId { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

    }
}
