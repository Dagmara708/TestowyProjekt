using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class FeverCard
    {
        [Key]
        public int Card_id { get; set; }
        public int Doctor_id { get; set; }
        public int Patient_id { get; set; }
        public int Patient_age { get; set; }

        public int Weight { get; set; }
        public string Hospital { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual List<Measure> Measures { get; set; }

    }
}