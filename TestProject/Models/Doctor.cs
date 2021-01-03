using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Doctor
    {
        [Key]
        public int Doctor_id { get; set; }

        [DisplayName("Imię lekarza")]
        public string Doctor_name { get; set; }

        [DisplayName("Nazwisko lekarza")]
        public string Doctor_surname { get; set; }

        [DisplayName("PESEL lekarza")]
        public string Doctor_PESEL { get; set; }

        public virtual List<Fever_Card> Fever_Cards { get; set; }
    }
}