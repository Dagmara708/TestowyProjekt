using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }
        public DbSet<Lekarz> Lekarze { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<Karta_goraczkowa> Karty_gorączkowe { get; set; }
        public DbSet<Pomiar> Pomiary { get; set; }
    }
}