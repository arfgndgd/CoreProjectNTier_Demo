using Project.Bll.ManageServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.ManageServices.Concretes
{
    public class CategoryManager:BaseManager<Category>, ICategoryManager
    {

        public CategoryManager(IRepository<Category> crp):base(crp)
        {

        }
    }
}
