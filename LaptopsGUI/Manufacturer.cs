using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopsGUI
{
    internal class Manufacturer
    {
        public int ManufacturerCode { get; set; }
        public string ManufacturerName { get; set; }

        public Manufacturer(int code, string name)
        {
            ManufacturerCode = code;
            ManufacturerName = name;
        }
    }
}
