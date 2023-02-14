using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Microwave : Appliance
    {
        //Attributes
        public double capacity { get; set; }
        public string roomType {get; set; }
        //Best type of variable to use for roomType??? String seems ok???

        public Microwave()
        {

        }

        public Microwave(long itemNumber, string brand, int quantity, int wattage, string color, double price, double capacity, string roomType) 
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.capacity = capacity;
            this.roomType = roomType; 
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"\nCapacity: {capacity}\nRoom Type: {roomType}";
        }

    }
}
