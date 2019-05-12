using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseWebApp.Service;

namespace WarehouseWebApp.ViewComponents
{
    public class WyszukiwarkaProduktowViewComponent : ViewComponent
    {
        private readonly IProductRepository _produktyCtx;
        public WyszukiwarkaProduktowViewComponent(IProductRepository produktyCtx)
        {
            _produktyCtx = produktyCtx;
        }

        public IViewComponentResult Invoke(int serial, DateTime dataStart, DateTime dataKoniec)
        {
            if (dataStart == null && dataKoniec == null)
            {
                var konkretneProdukty = _produktyCtx.Produkty.Where(p => p.SerialNumber == serial).ToList();
                return View("Default", konkretneProdukty);
            }
            else
            {

                var produktyZDanegoDnia = _produktyCtx.Produkty.Where(p => p.ShipmenDate >= dataStart || p.ShipmenDate <= dataKoniec).ToList();
                return View("WybranyDzien", produktyZDanegoDnia);
            }

        }
    }
}
