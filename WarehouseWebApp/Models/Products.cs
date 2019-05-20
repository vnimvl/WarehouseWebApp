using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseWebApp.Models
{
    public class Products
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public int VAT { get; set; }
        public string Description { get; set; }
        public DateTime ShipmenDate { get; set; }
        public bool IsActive { get; set; }
        
        public int? KategorieId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
