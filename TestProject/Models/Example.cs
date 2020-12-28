using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Example
    {
        public int Id { get; set; }

        [DisplayName("Imię")]
        public string Name { get; set; }
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }

        public virtual List<Subexample> Subexamples { get; set; }
    }
}