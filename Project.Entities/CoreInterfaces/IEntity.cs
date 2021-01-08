using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities.CoreInterfaces
{
    public interface IEntity
    {
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DataStatus? Status { get; set; }

    } 
}
