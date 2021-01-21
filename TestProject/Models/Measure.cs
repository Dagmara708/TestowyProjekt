using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Measure
    {
        [Key]
        public int Measure_id { get; set; }

        [DisplayName("Karta")]
        public int Card_id { get; set; }

        [DisplayName("Dzień pobytu")]
        public int Day_of_stay { get; set; }

        [DisplayName("Pora dnia")]
        public string Time_of_day { get; set; }

        [DisplayName("Temperatura")]
        public string Temperature { get; set; }

        [DisplayName("Tętno")]
        public int Pulse { get; set; }

        [DisplayName("Dieta")]
        public string Diet { get; set; }

        [DisplayName("Stolec")]
        public string Stool { get; set; }

        [DisplayName("Zalecenia lekarskie")]
        public string Doctors_rec { get; set; }

        [DisplayName("Inne")]
        public string Others { get; set; }

        public virtual FeverCard FeverCard { get; set; }
    }
}