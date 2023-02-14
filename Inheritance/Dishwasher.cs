using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Dishwasher : Appliance
    {
        public string feature { get; set; }
        public string soundRating { get; set; }

        public Dishwasher() 
        {

        }

        public Dishwasher(long itemNumber, string brand, int quantity, int wattage, string color, double price, string feature, string soundRating)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this.feature = feature;
            this.soundRating = soundRating;
        }

        //What to do regarding finish??? Assignment seems inconsistent??? Not in the text file???

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"\nFeature: {feature}\nSound Rating: {soundRating}";
        }

    }


}
