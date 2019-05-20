using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebApp.Data;

namespace WarehouseWebApp.Controllers
{
    public class FakturaController : Controller
    {
        private ApplicationDbContext _context;

        public FakturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Klienci = _context.Klienci;
            return View();
        }
    }
}