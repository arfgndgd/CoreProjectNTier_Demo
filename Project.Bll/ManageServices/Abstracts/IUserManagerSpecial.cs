using Microsoft.AspNetCore.Identity;
using Project.Dal.DALModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ManageServices.Abstracts
{

    //Identity aslında bir API'dır...  

    //Identity kullanıyorsanız sizi Async metotlarla calısma durumunda bırakır
    public interface IUserManagerSpecial
    {
        //Normal bir metodumuz asenkron calısmak istiyorsa basına Task almak zorundadır...

        //Eger kendimize has bir User'imiz yok ise IdentityUser üzerinden bu işlemleri yaparız...
        Task<bool> AddUser(AppUser item);
    }
}
