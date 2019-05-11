using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseWebApp.Models;

namespace WarehouseWebApp.Service
{
    public interface IProductRepository
    {
        IQueryable<Products> Produkty { get; }

        void AddProduct(Products ProductData); //dodanie nowego produktu
        void DeleteProduct(Products ProductData);
        void EditProduct(Products EditProduct);
        void SumujAktywnePozycje(); // wszystkie aktywne produkty z takim samym kodem zostaną podliczone

    }
}
