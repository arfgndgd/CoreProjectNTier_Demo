using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.ManageServices.Abstracts
{
    public interface IManager<T> where T:BaseEntity
    {
        List<T> GetAll();
        string Add(T item);
    }
}
