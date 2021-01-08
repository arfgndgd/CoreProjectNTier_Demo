using Microsoft.AspNetCore.Identity;
using Project.Dal.DALModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ManageServices.Abstracts
{
    public interface ILoginManager
    {
        Task<bool> SignInUser(AppUser item, bool remember);
    }
}
