using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Lekarz
    {
        public int Id_Lekarza { get; set; }
        [DisplayName("Imię lekarza")]

        public string Imię_lekarza { get; set; }
        [DisplayName("Nazwisko pacjenta")]
        public string Nazwisko_lekarza { get; set; }

        public string PESEL_lekarza { get; set; }
        public virtual List<Karta_goraczkowa> Karty_goraczkowe { get; set; }
    }
}