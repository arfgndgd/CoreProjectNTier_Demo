using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Dal.Repositories.Concretes
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(MyContext db):base(db)
        {

        }
    }
}
