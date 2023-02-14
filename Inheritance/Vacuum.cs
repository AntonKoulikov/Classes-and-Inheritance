using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Vacuum : Appliance
    {
        public string Grade { get; set; }
        public int Voltage { get; set; }

        public Vacuum(long itemNumber, string brand, int quantity, int wattage, string color, double price, string grade, int voltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.Grade = grade;
            this.Voltage = voltage;
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"\nGrade: {Grade}\nBattery Voltage: {Voltage}";
        }
    }
}
