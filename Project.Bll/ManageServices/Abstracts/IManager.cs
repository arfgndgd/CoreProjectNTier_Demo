using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.ManageServices.Abstracts
{
    public interface IManager<T> where T:BaseEntity
    {
        string Add(T item);
    }
}
