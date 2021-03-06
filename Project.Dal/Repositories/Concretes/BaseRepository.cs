﻿using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.CoreInterfaces;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Dal.Repositories.Concretes
{
    //BaseRepositoryi abstract yapmamıza gerek yok. Çünkü Manager katmanında instance almamız lazım.
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity,IEntity
    {

        MyContext _db;
         
        public BaseRepository(MyContext db)
        {
            _db = db;
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
    }
}
