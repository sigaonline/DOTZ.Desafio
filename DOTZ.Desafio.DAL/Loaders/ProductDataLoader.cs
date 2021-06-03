using DOTZ.Desafio.DAL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Desafio.DAL.Loaders
{
    public class ProductDataLoader
    {
        public IEnumerable<Product> Load()
        {
            return new[]
           {
                new Product
                {
                     Id = 1,
                     Description = "Celular",
                     PointsValue = 100
                },
                new Product
                {
                     Id = 2,
                     Description = "TV Smart",
                     PointsValue = 200
                },
                new Product
                {
                     Id = 3,
                     Description = "Notebook",
                     PointsValue = 300
                }

            };
        }
    }
}
