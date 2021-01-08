using Microsoft.AspNetCore.Identity;
using Project.Entities.CoreInterfaces;
using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Dal.DALModel
{
    //Identity kütüphanesi ile kendi classımızı birleştirdik
    //AppUser , IdentityUser'dan miras alarak bu sınıfın özelliklerini icine almak istiyorsa artık nerede IdentityUser kullanacak isek oraya AppUser class'ını yazmalıyız...(ILoginManager, IUserManagerSpecial, UserManager..)

    public class AppUser : IdentityUser, IEntity
    {
     

        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DataStatus? Status { get; set; }
    }
}
