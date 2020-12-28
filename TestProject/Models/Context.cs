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

        public DbSet<Example> Examples { get; set; }
        public DbSet<Subexample> Subexamples { get; set; }
    }
}