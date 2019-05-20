using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseWebApp.Data;
using WarehouseWebApp.Models;

namespace WarehouseWebApp.Controllers
{
  
    public class ZamowienieController : Controller
    {
        private ApplicationDbContext _context;

        public ZamowienieController(ApplicationDbContext context)
        {
            _context = context;
        }
        //----------------------------------------------------------------- STRONA GLOWNA Z LISTA ZAMOWIEN ( BEZ PODZIAŁU NA STATUS OTWARTY/ZAMKNIETY)
        public IActionResult Index()
        {
            var listaZamowien = _context.Zamowienia;
            return View(listaZamowien);
        }

        //----------------------------------------------------------------- DODAWANIE PUSTEGO ZAMOWIENIA 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Zamowienie zamowienie)
        {
            _context.Zamowienia.Add(zamowienie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //-----------    W.I.P   ------------------------------------------------------ WYŚWIETLANIE LISTY PRODUKTOW ZNAJDUJACYCH SIE W ZAMOWIENIU 
        [HttpGet]
        public IActionResult SzczegolyZamowienia(int id) 
        {
            List<Products> ListaProduktow = new List<Products> { };

            var Lista = _context.Listy.Where(p => p.ZamowienieId == id).Include(p => p.Product).Select(p => p.Product.Id).ToList();

            foreach (var produkt in Lista)
            {
                ListaProduktow.Add(_context.Produkty.Where(p => p.Id == produkt).First());
            }

            PodsumowanieZamowieniaViewModel model = new PodsumowanieZamowieniaViewModel
            {
                Zamowienia = _context.Zamowienia.Where(z => z.Id == id).Include(p => p.Lista).FirstOrDefault(),
                Produkty = ListaProduktow,
                Lista = _context.Listy.Where(l => l.ZamowienieId == id).ToList()
            };
            
            // zamowienia
            return View(model); // ma zwracac listy i zamówienia
        }
        //----------------------------------------------------------------- DODAWANIE PRODUKTOW DO LISTY "ZAKUPÓW"
        [HttpGet]
        public IActionResult CreateList(int id)
        {

            ViewBag.ProductId = _context.Produkty.ToList();
            ViewBag.idZamowienia = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateList(Lista produktDoZamowienia)
        {
            _context.Listy.Add(produktDoZamowienia);
            _context.SaveChanges();
            return RedirectToAction("ListaProduktow");
        }
        //----------------------------------------------------------------- 
    }
}