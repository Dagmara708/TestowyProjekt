using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Patient
    {
        [Key]
        public int Patient_id { get; set; }

        [DisplayName("Imię pacjenta")]
        public string Name { get; set; }

        [DisplayName("Nazwisko pacjenta")]
        public string Surname { get; set; }

        public string PESEL { get; set; }

        public virtual List<Fever_Card> Fever_Cards { get; set; }
        

    }
}