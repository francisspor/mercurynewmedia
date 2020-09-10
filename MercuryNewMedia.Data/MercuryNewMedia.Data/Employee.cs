using System;
using System.Collections.Generic;

namespace MercuryNewMedia.Data
{
    public class Employee
    {
        public string Name { get; set; }

        public string Department { get; set; }

        public List<string> Toppings { get; set; } = new List<string>();
    }
}
