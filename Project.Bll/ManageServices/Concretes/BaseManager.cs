using Project.Bll.ManageServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.ManageServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : BaseEntity
    {
        protected IRepository<T> _irp;

        public BaseManager(IRepository<T> irp)
        {
            _irp = irp;
        }

        public virtual string Add(T item)
        {
            if (item.CreatedDate != null)
            {
                _irp.Add(item);
                return "Ekleme başarılı";
            }
            return "Ekleme başarısız";
        }
    }
}
