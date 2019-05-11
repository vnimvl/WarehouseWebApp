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

        void AddProduct(Products ProductData);
        void DeleteProduct(Products ProductData);
        void EditProduct(Products EditProduct);

    }
}
