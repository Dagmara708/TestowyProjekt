﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Example
    {
        public int Id_pacjenta { get; set; }

        [DisplayName("Imię pacjenta")]
        public string Name { get; set; }
        [DisplayName("Nazwisko pacjenta")]
        public string Surname { get; set; }

        public string Pesel { get; set; }

        public virtual List<Karta_goraczkowa> Karty_goraczkowe { get; set; }
        

    }
}