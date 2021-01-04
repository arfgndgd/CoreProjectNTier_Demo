using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Dal.Repositories.Abstracts
{
    //IRepository açılması anlaşılabilir ancak Product ve Category için de interface olarak Abstract classlar açmanın da bir neddeni vardır. Dependency Inversion tetiklenmesi gerekir.
    public interface IRepository<T> where T:BaseEntity
    {

        List<T> GetAll();
        void Add(T item);
       
    }
}
