using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseWebApp.Models
{
    public class PodsumowanieZamowieniaViewModel
    {
        public Zamowienie Zamowienia { get; set; }
        public List<Lista> Lista { get; set; }
        public List<Products> Produkty { get; set; }
    }
}
