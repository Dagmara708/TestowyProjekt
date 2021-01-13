﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Measure
    {
        [Key]
        public int Measure_id { get; set; }
        public int Card_id { get; set; }       
        public int Day_of_stay { get; set; }
        public string Time_of_day { get; set; }
        public int Temperature { get; set; }
        public int Pulse { get; set; }
        public string Stool { get; set; }
        public string Diet { get; set; }
        public string Doctors_rec { get; set; }
        public string Others { get; set; }

        public virtual FeverCard FeverCards { get; set; }
    }
}