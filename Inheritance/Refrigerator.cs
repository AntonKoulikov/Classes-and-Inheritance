using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Refrigerator : Appliance
    {
        public int NumberOfDoors { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Refrigerator()
        {

        }

        public Refrigerator(long itemNumber, string brand, int quantity, int wattage, string color, double price, int numberOfDoors, int height, int width)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.NumberOfDoors = numberOfDoors;
            this.Height = height;
            this.Width = width;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"\nNumber of Doors: {NumberOfDoors}\nHeight: {Height}\nWidth: {Width}";
        }
    }
}
