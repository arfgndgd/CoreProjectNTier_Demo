using Project.Bll.ManageServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.ManageServices.Concretes
{
    public class ProductManager:BaseManager<Product>,IProductManager
    {
        public ProductManager(IRepository<Product> prp):base(prp)
        {

        }

        public override string Add(Product item)
        {
            if (item.ProductName == null || item.ProductName.Trim() == ""|||| item.CreatedDate == null)
            {
                return "Ekleme basarısız... İsim hatası var";
            }
            _irp.Add(item);
            return "Ekleme başarılı  ";
        }
    }
}
