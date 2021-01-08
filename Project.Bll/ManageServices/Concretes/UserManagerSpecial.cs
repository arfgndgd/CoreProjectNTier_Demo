﻿using Microsoft.AspNetCore.Identity;
using Project.Bll.ManageServices.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.ManageServices.Concretes
{
    public class UserManagerSpecial : IUserManagerSpecial
    {
        UserManager<IdentityUser> _umanager;
        SignInManager<IdentityUser> _smanager;

        public UserManagerSpecial(UserManager<IdentityUser> umanager,SignInManager<IdentityUser> smanager)
        {
            _umanager = umanager;
            _smanager = smanager;

        }

        public async Task<bool> AddUser(IdentityUser item)
        {
            //Sadece ASenkron olarak yaratılmıs metotlara await diyebilirsiniz...
            //UserManager CreateAsync metodu ilgili kullanıcıyı eklemenizi saglayan metottur...CreateAsync metodu size bir task result döndürür(yani ilgili görev basarılı oldu mu olmadı mı ) 
            IdentityResult result = await _umanager.CreateAsync(item, item.PasswordHash);

            if (result.Succeeded)
            {
                //SignInAsync metodu kişinin login olmasını saglayan bir SignInManager metodudur... Kendisi iki tane argüman alır...Kim login olmus...Ve login durumu SessionCookie mi (yani browser kapandıgında kapanacak mı) yoksa Persisten Cookie mi (yani browser kapandıgında da kalacak mı)

                await _smanager.SignInAsync(item, isPersistent: false);
                return true;
            }
            return false;
        }
    }
}
