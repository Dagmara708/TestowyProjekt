using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Pomiar
    {
        public int Id_karty { get; set; }
        public int Id_pomiaru { get; set; }
        public int dzien_pobytu_doba { get; set; }
        public string pora_dnia_R_W { get; set; }
        public decimal temperatura { get; set; }
        public int tetno { get; set; }
        public string stolec { get; set; }
        public string dieta { get; set; }
        public string inne { get; set; }
        public string zalecenia_lekarskie { get; set; }

        public virtual Karta_goraczkowa Karty_goraczkowe { get; set; }
    }
}