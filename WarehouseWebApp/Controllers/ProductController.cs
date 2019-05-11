using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebApp.Models;
using WarehouseWebApp.Service;

namespace WarehouseWebApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        //private ApplicationDbContext _context;
        private readonly IProductRepository _products;
        public ProductController(/*ApplicationDbContext context,*/ IProductRepository products)
        {
            //_context = context;
            _products = products;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products product)
        {
            _products.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Products product)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sumuj()
        {
            _products.SumujAktywnePozycje();
            return RedirectToAction("Index");
        }
    }
}