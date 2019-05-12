using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseWebApp.Data;
using WarehouseWebApp.Service;

namespace WarehouseWebApp.ViewComponents
{
    public class ProduktyViewComponent : ViewComponent
    {
        private readonly IProductRepository _produktyCtx;
        private readonly ApplicationDbContext _context;
        public ProduktyViewComponent(IProductRepository produktyCtx, ApplicationDbContext context)
        {
            _produktyCtx = produktyCtx;
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Kategorie = _context.Kategorie.ToList();
            var wszystkieprodukty = _produktyCtx.Produkty.ToList();
            return View("Default", wszystkieprodukty);
        }
    }
}
