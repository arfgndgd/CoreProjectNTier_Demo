using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ManageServices.Abstracts
{
    public interface ILoginManager
    {
        Task<bool> SignInUser(IdentityUser item, bool remember);
    }
}
