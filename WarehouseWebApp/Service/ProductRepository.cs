using System;
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
                Price = ProductData.Price,
                VAT = ProductData.VAT,
                Description = ProductData.Description,
                IsActive = ProductData.IsActive,
                ShipmenDate = DateTime.Now,
                KategorieId = ProductData.KategorieId
            };

            _context.Produkty.Add(NowyProdukt);
            _context.SaveChanges();
        }

        public void DeleteProduct(int Id)
        {
            var Produkt = _context.Produkty.Where(p => p.Id == Id).Single();
            _context.Remove(Produkt);
            _context.SaveChanges();
        }

        public void SaveChanges(Products produkt)
        {
            _context.Update(produkt);
            _context.SaveChanges();
        }

        public Products SelectProductById(int id)
        {
            return _context.Produkty.Where(p => p.Id == id).Single();
        }

        public void SumujAktywnePozycje()
        {
            var WszystkieProdukty = _context.Produkty.Where(p => p.IsActive == true).OrderBy(p=>p.SerialNumber).ToList();
            int liczbaElementow = WszystkieProdukty.Count();

            // PROCES SUMOWANIA I USTAWIANIA WARTOSCI -1 DLA ELEMENTOW ZSUMOWANYCH PRZEZNACZONYCH DO POZNIEJSZEGO USUNIECIA
            int index = 0;
            
            for (int i = 1; i < liczbaElementow; i++)
            {
                var ProduktBazowy = WszystkieProdukty.ElementAt(index);
                var ProduktDoZsumowania = WszystkieProdukty.ElementAt(i);

                if(ProduktBazowy.SerialNumber == ProduktDoZsumowania.SerialNumber)
                    {
                        ProduktBazowy.Count += ProduktDoZsumowania.Count;
                    ProduktDoZsumowania.Count = -666;

                        _context.Produkty.Update(ProduktBazowy);
                        _context.Produkty.Update(ProduktDoZsumowania);

                }
                else
                {
                    index = i;
                }
            }
            _context.SaveChanges();

            //USUWANIE ELEMENTOW Z FLAGĄ -666
            foreach (var Produkt in WszystkieProdukty)
            {
                if (Produkt.Count == -666)
                {
                    _context.Produkty.Remove(Produkt);
                }
            }
            _context.SaveChanges();
        }
    }
}
