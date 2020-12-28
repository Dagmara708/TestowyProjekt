using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Subexample
    {
        public int Id { get; set; }
        public int ExampleId { get; set; }
        public string Name { get; set; }

        public virtual Example Example { get; set; }
    }
}