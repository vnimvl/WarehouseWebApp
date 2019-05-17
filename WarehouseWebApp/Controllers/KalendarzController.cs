using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebApp.Data;

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
            return View();
        }

        public JsonResult GetEvents()
        {
            var events = _context.Events.ToList();
            return new JsonResult(events);
        }

    }
}