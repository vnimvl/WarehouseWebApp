using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WarehouseWebApp.Models;

namespace WarehouseWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Products> Produkty { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Kategorie> Kategorie { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Faktura> Faktury { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Lista> Listy { get; set; }
    }
}
