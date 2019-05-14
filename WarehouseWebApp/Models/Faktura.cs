using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseWebApp.Models
{
    public class Faktura
    {
        public int Id { get; set; } // PK
        public int NumerFaktury { get; set; } // nuemr faktruy
        public string KodFaktury { get; set; } // kod faktury ? dzień/miesiac/rok/numer
        public int KlientId { get; set; }  // FK relacji przypisania faktury do wybranego klienta pobrana z zamówienia

    }
}
