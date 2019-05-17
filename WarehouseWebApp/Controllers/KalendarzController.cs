using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebApp.Data;
using WarehouseWebApp.Models;

namespace WarehouseWebApp.Controllers
{
    public class KalendarzController : Controller
    {
        private readonly ApplicationDbContext _context;
        public KalendarzController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var model = _context.Events;
            return View(model);
        }

        public IActionResult Dodaj()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event dostawa)
        {
            _context.Events.Add(dostawa);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Kalendarz/Delete/{title}")]
        public IActionResult Delete(string title)
        {
            Event data = _context.Events.Where(e => e.Title == title).Single();
            _context.Events.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetEvents()
        {
            var events = _context.Events.ToList();
            return new JsonResult(events);
        }

        [Route("Kalendarz/GetDescription/{title}")]
        public String GetDescription(string title)
        {
            string opis = _context.Events.Where(e => e.Title == title).FirstOrDefault().Description.ToString();
            return opis;
        }

    }
}