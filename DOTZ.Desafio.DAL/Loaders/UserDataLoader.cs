using DOTZ.Desafio.DAL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Desafio.DAL.Loaders
{
    public class UserDataLoader
    {
        public IEnumerable<User> Load()
        {
            return new[]
           {
                new User
                {
                     Id = 1,
                     UserName = "Admin",
                     Password = "Admin",
                     Role = 2
                }
            };
        }
    }
}
