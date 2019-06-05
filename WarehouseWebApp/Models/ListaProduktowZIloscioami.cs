using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseWebApp.Models
{
    public class ListaProduktowZIloscioami
    {
        public int IdProduktu { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public int IloscWZamowieniu { get; set; }
        public double CenaZaSztuke { get; set; }
        public int Vat { get; set; }
        public double CenaNettoCalosci { get; set; }
        public double CenaVatCalosci { get; set; }
        public double CenaBruttoCalosci { get; set; }
    }
}
