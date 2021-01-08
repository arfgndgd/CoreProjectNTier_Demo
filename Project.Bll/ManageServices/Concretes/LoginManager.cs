using Microsoft.AspNetCore.Identity;
using Project.Bll.ManageServices.Abstracts;
using Project.Dal.DALModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ManageServices.Concretes
{
    public class LoginManager : ILoginManager
    {
        SignInManager<AppUser> _smanager;
        public LoginManager(SignInManager<AppUser> smanager)
        {
            _smanager = smanager;
        }

        public async Task<bool> SignInUser(AppUser item, bool remember)
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
