﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetMvcAds.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")/*, Authorize(Policy = "AdminPolicy")*/]

	public class MainController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

    }
}