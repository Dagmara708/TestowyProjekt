using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Karta_goraczkowa
    {
        public int Id_karty { get; set; }
        public int Id_Lekarza { get; set; }
        public int Id_pacjenta { get; set; }

        public int wiek_pacjenta{ get; set; }

        public int waga { get; set; }
        public int oddzial_szpital { get; set; }
        public virtual Example Example { get; set; }
        public virtual Lekarz Lekarze { get; set; }
        public virtual List<Pomiar> Pomiary{ get; set; }

    }
}