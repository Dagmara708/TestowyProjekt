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
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<FeverCard> FeverCards { get; set; }
        public DbSet<Measure> Measures { get; set; }
    }
}