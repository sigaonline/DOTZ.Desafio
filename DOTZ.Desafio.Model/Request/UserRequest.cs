using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Desafio.Model.Request
{
    public class UserRequest
    {
        public int Id{ get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }

    }
}
