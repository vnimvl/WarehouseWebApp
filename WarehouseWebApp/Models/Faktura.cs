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

        public int KlientId { get; set; }
        public virtual Klient Klient { get; set; }
        public int ZamowienieId { get; set; }
        public virtual Zamowienie Zamowienie { get; set; }
    }
}
