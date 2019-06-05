using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index(int? idZamowienia)
        {
            ViewBag.Klienci = _context.Klienci;

            ViewBag.Zamowienie = idZamowienia;  
            return View();
        }
    }
}