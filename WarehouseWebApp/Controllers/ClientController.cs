using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebApp.Data;
using WarehouseWebApp.Models;

namespace WarehouseWebApp.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewClient()
        {
            return View();
        }

        public IActionResult List()
        {
            var wszyscyKlienci = _context.Klienci;
            return View(wszyscyKlienci);
        }

        [HttpPost]
        public IActionResult Create(Klient klient)
        {
            _context.Klienci.Add(klient);
            _context.SaveChanges();
            return RedirectToAction("NewClient");
        }
    }
}