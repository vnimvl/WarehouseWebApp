﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebApp.Data;
using WarehouseWebApp.Models;
using WarehouseWebApp.Service;

namespace WarehouseWebApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IProductRepository _products;
        public ProductController(ApplicationDbContext context, IProductRepository products)
        {
            _context = context;
            _products = products;

        }
        public IActionResult Index(int serial)
        {
            ViewBag.kategorie = _context.Kategorie.ToList();
            ViewBag.query = serial;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products product)
        {
            _products.AddProduct(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            _products.DeleteProduct(Id);
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int Id)=> View(_products.SelectProductById(Id)); // przekazanie do widoku danych produktu zgodnie  zmodelem

        [HttpPost]
        public IActionResult Edit(Products Produkt)     //pobranie zedytowanych danych i zapisanie ich
        {
            if (ModelState.IsValid)
            {
                _products.SaveChanges(Produkt);
                return RedirectToAction("Index");
            }
            else
            {
                return View(Produkt);   // jezeli dane sa niepoprzwne strona zostanie załądowan aponownie
            }
        }

        [HttpPost]
        public IActionResult Search(int serial, string dataStart, string dataKoniec)
        {
            if(serial > 0)
            {
                return RedirectToAction("Index", new { serial });
            }
            if (dataStart != null && dataKoniec !=null )
            {
                return RedirectToAction("RaportZDnia", new { dataStart,dataKoniec });
            }
            else return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RaportZDnia(DateTime dataStart, DateTime dataKoniec)
        {
            ViewBag.dataStart = dataStart;
            ViewBag.dataKoniec = dataKoniec;
            return View();
        }

        [HttpPost]
        public IActionResult Sumuj()
        {
            _products.SumujAktywnePozycje();
            return RedirectToAction("Index");
        }
    }
}