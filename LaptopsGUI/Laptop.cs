using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopsGUI
{
    internal class Laptop
    {
        public Category Category { get; set; }
        public string CPU { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }
        public double Price { get; set; }
        public int RAM { get; set; }
        public string Screen { get; set; }
        public string Storage { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return $"{this.ID + 1} {Manufacturer.ManufacturerName} {this.Model}";
        }

        public Laptop(string sor, int id)
        {
            var x = sor.Split(";");

            Category = new Category(int.Parse(x[0]), x[1]);
            CPU = x[2];
            Manufacturer = new Manufacturer(int.Parse(x[3]), x[4]);
            Model = x[5];
            OS = x[6];
            Price = double.Parse(x[7]);
            RAM = int.Parse(x[8]);
            Screen = x[9];
            Storage = x[10];
            ID = id;
        }
    }
}
