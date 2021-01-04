﻿using Microsoft.AspNetCore.Mvc;
using Project.CoreUI.Models.PageVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Bll.ManageServices.Abstracts;

namespace Project.CoreUI.Controllers
{
    public class CategoryController : Controller
    {


        ICategoryManager _icm;
        public CategoryController(ICategoryManager icm)
        {
            _icm = icm;
        }

        public IActionResult CategoryList()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryPageVM item)
        {
            return View();
        }
    }
}
