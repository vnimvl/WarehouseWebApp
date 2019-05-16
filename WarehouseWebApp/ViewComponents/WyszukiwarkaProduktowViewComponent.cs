using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseWebApp.Models;
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

        public IViewComponentResult Invoke(int serial, DateTime? dataStart, DateTime? dataKoniec, string nazwa, bool? status, int type)
        {
            if (type == 1) {
                List<Products> wybraneProdukty = null;
                if (dataStart == null)
                {
                    if(nazwa!=null && serial ==0)
                    {
                        wybraneProdukty = _produktyCtx.Produkty.Where(p => p.Name == nazwa).ToList();

                    }else
                    wybraneProdukty = _produktyCtx.Produkty.Where(p => p.IsActive == status || p.SerialNumber == serial || p.Name == nazwa).ToList();
                    return View("WybranyDzien", wybraneProdukty);
                }
                else
                {
                    wybraneProdukty = _produktyCtx.Produkty.Where(p => p.ShipmenDate >= dataStart && p.ShipmenDate <= dataKoniec && p.IsActive == status && p.SerialNumber == serial).ToList();

                    if (nazwa != null)
                    {
                        wybraneProdukty = _produktyCtx.Produkty.Where(p => p.ShipmenDate >= dataStart && p.ShipmenDate <= dataKoniec && p.Name == nazwa && p.IsActive == status && p.SerialNumber == serial).ToList();

                    }
                }
                return View("WybranyDzien", wybraneProdukty);

                }
                var konkretneProdukty = _produktyCtx.Produkty.Where(p => p.SerialNumber == serial).ToList();
            if (serial > 0 || dataStart == null || dataKoniec == null)
            {
                return View("Default", konkretneProdukty);
            } else
            if (serial == 0 || dataStart != null || dataKoniec != null)
            {
                DateTime dataKoniec2 = Convert.ToDateTime(dataKoniec.ToString()).AddDays(1);
                var produktyZDanegoDnia = _produktyCtx.Produkty.Where(p => p.ShipmenDate >= dataStart && p.ShipmenDate <= dataKoniec2).ToList();
                ViewBag.SumaWartosciWszystkichElementow = _produktyCtx.SumujWszystkieWartosci(produktyZDanegoDnia);
                ViewBag.SumaWartosciAktywnychPozycji = _produktyCtx.SumujWarosciAktywnychPozycji(produktyZDanegoDnia);
                ViewBag.SumaWartosciNieaktywnychPozycj = _produktyCtx.SumujWartosciNieaktywnychPozycji(produktyZDanegoDnia);

                return View("WybranyDzien", produktyZDanegoDnia);
            }
 
             return View("Default", konkretneProdukty);
        }
    }
}
