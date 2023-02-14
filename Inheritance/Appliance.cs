using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Appliance //Super Class
    {
        //Attributes
        public long itemNumber { get; set; }
        public string brand { get; set; }
        public int quantity { get; set; }
        public double wattage { get; set; }
        public string color { get; set; }
        public double price { get; set; }


        //Constructors
        //Create Appliance object with default values
        public Appliance() 
        {

        }

        //Create Appliance object with provided attributes 
        public Appliance(long itemNumber, string brand, int quantity, int wattage, string color, double price)
        {
            this.itemNumber = itemNumber;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.color = color;
            this.price = price;
        }

        //Methods (lielly to be overridden within sub classes)
        //Get appliance number
        public string GetItemNumber() //How to check if itemNumber matches and if it is already checked out???
        {
            return "Appliance " + itemNumber + "has been checked out.";
        }

        //Checkout method included in the management class

        public override string ToString()
        {
            return "Item Number: " + itemNumber + " \nBrand:" + brand
                + "\nQuantity: " + quantity + "\nWattage: " + wattage
                + "\nColor: " + color + "\nPrice: " + price;
        }
    }
}
