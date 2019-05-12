﻿using Microsoft.AspNetCore.Mvc;
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
            
            var konkretneProdukty = _produktyCtx.Produkty.Where(p => p.SerialNumber == serial).ToList();
            if (serial > 0 || dataStart == null || dataKoniec == null)
            {
                return View("Default", konkretneProdukty);
            }else
            if(serial == 0 || dataStart != null || dataKoniec != null)
            {
                var produktyZDanegoDnia = _produktyCtx.Produkty.Where(p => p.ShipmenDate >= dataStart && p.ShipmenDate <= dataKoniec.AddDays(1)).ToList();
                return View("WybranyDzien", produktyZDanegoDnia);
            }
 
             return View("Default", konkretneProdukty);
        }
    }
}
