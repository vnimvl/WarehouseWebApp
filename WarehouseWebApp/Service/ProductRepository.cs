﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseWebApp.Data;
using WarehouseWebApp.Models;

namespace WarehouseWebApp.Service
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Products> Produkty => _context.Produkty;

        public void AddProduct(Products ProductData)
        {
            var NowyProdukt = new Products
            {
                SerialNumber = ProductData.SerialNumber,
                Name = ProductData.Name,
                Count = ProductData.Count,

                //Price = ProductData.Price,
                Price = 0.01f,
                //VAT = ProductData.VAT,
                VAT = 23,
                //Description = ProductData.Description,
                Description = "Brak Opisu",

                IsActive = ProductData.IsActive
            };

            _context.Produkty.Add(NowyProdukt);
            _context.SaveChanges();
        }

        public void DeleteProduct(Products ProductData)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(Products EditProduct)
        {
            throw new NotImplementedException();
        }
    }
}