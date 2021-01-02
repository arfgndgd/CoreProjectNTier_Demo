﻿using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DataStatus? Status { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;

        }
    }
}
