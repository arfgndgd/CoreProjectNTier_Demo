using Microsoft.AspNetCore.Identity;
using Project.Bll.ManageServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ManageServices.Concretes
{
    public class LoginManager : ILoginManager
    {
        SignInManager<IdentityUser> _smanager;
        public LoginManager(SignInManager<IdentityUser> smanager)
        {
            _smanager = smanager;
        }

        public async Task<bool> SignInUser(IdentityUser item, bool remember)
        {
            //await keyword'u sadece asenkron olarak yaratılmıs metotların icinde ve asenkron olarak hizmet yapabilen metot cagrımlarında kullanılabilir...
            SignInResult result =  await _smanager.PasswordSignInAsync(item.UserName,item.PasswordHash,remember,false);

            if (result.Succeeded) 
            {
                return true;
            }
            return false;
        }
    }
}
