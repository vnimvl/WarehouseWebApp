using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseWebApp.Models
{
    public class Klient
    {
        public int Id { get; set; }
        public string NazwaKrotka { get; set; }
        public string NazwaDluga { get; set; }
        public string Ulica { get; set; }
        public int Numer { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public long NIP { get; set; }
        public string Emial { get; set; }

        public virtual Faktura Faktura { get; set; }
    }
}
