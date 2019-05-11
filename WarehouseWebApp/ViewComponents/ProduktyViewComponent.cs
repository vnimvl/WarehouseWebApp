using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseWebApp.Service;

namespace WarehouseWebApp.ViewComponents
{
    public class ProduktyViewComponent : ViewComponent
    {
        private readonly IProductRepository _produktyCtx;
        public ProduktyViewComponent(IProductRepository produktyCtx)
        {
            _produktyCtx = produktyCtx;
        }

        public IViewComponentResult Invoke()
        {
            var wszystkieprodukty = _produktyCtx.Produkty.ToList();
            return View("Default", wszystkieprodukty);
        }
    }
}
