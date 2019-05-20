using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int LiczbaSztuk { get; set; }

        public int ZamowienieId { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
        public int ProductId { get; set; }
        public virtual Products Product { get; set; }
    }
}
