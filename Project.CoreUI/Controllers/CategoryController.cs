using Microsoft.AspNetCore.Mvc;
using Project.CoreUI.Models.PageVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Bll.ManageServices.Abstracts;
using Project.Entities.Models;
using Microsoft.AspNetCore.Authorization;

namespace Project.CoreUI.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {


        ICategoryManager _icm;
        public CategoryController(ICategoryManager icm)
        {
            _icm = icm;
        }
        //[AllowAnonymous]
        public IActionResult CategoryList()
        {
            CategoryPageVM cpvm = new CategoryPageVM
            {
                Categories = _icm.GetAll()
            };
            return View(cpvm);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            TempData["mesaj"] = _icm.Add(category);

            return RedirectToAction("AddCategory"); 
        }
    }
}
