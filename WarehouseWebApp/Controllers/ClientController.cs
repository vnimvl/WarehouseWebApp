﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseWebApp.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewClient()
        {
            return View();
        }
    }
}