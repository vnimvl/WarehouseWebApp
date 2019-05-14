﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseWebApp.Models
{
    public class Zamowienie
    {
        public int Id { get; set; } // PK
        public int? FakturaId { get; set; } // FK połączenie z przygowaną fakturą
        public Klient Klient { get; set; } // zamówienie przypisane do wybranego klienta
        public DateTime DataZamowienia { get; set; } // data przyjecia zamowienia    
        public DateTime? DataWystawieniaFaktury { get; set; } // data wystawienia faktury

        public bool IsCompleted { get; set; } // czy skompletowana
        public bool IsDone { get; set; } // czy wystawiona faktura

    }
}