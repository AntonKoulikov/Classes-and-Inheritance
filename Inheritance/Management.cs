using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Management
    {
        //Method that parses the appliances.txt file into a single list. 
        List<Appliance> appliances = new List<Appliance>();

        public Management() //Calls required functions to make the program run
        {
            loadAppliancesListFromFile();
            Menu();
        }

        //Methods
        //Method that parses the appliances.txt file into a single list
        public void loadAppliancesListFromFile()
        {
            //Commented code used to test appliances.txt file path
            //string text = File.ReadAllText("C://Users//Anton//OneDrive - Southern Alberta Institute of Technology//Desktop//Object Oriented Programming 2//Assignments//Classes and Inheritance//Inheritance//appliances.txt");
            //Console.WriteLine(text);

            string[] lines = File.ReadAllLines("appliances.txt");

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                string applianceNumber = fields[0];
                char firstNumber = applianceNumber[0];
                switch (firstNumber)
                {
                    case '1':
                        //method/function Refrigerator                        
                        appliances.Add(new Refrigerator(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), Convert.ToInt32(fields[6]), Convert.ToInt32(fields[7]), Convert.ToInt32(fields[8])));
                        break;
                    case '2':
                        //method/function Vacuum
                        appliances.Add(new Vacuum(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), fields[6], Convert.ToInt32(fields[7])));

                        break;
                    case '3':
                        //method/function Microwave
                        appliances.Add(new Microwave(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), double.Parse(fields[6]), fields[7]));
                        break;
                    case '4':
                    case '5':
                        //method/function Dishwasher
                        appliances.Add(new Dishwasher(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), fields[6], fields[7]));
                        break;
                }
            }

        }

        //Method that operates the menu
        public void Menu()
        {
            bool con = true;
            while (con)
            {
                Console.WriteLine("Welcome to Modern Appliances! " +
                "\nHow may we assist you?" +
                "\n1 – Check out appliance" +
                "\n2 – Find appliances by brand" +
                "\n3 – Display appliances by type" +
                "\n4 – Produce random appliance list" +
                "\n5 – Save & exit");

                int input = Convert.ToInt32(Console.ReadLine());

                //if else with user input

                if (input == 1)
                {
                    Checkout(appliances);
                }
                else if (input == 2)
                {
                    SearchByBrand(appliances);
                }
                else if (input == 3)
                {
                    //DisplayAppliancesByType(appliances);
                }
                else if (input == 4)
                {
                    RandomApplianceList(appliances);
                }
                else if (input == 5)
                {
                    Console.WriteLine("Save and Exit");
                    break;
                }
                else { Console.WriteLine("Error, invalid user input, please try again."); }
            continue;
            }
        }

        //Method that allows a customer to purchase an appliance = Checkout (1)   
        public void Checkout(List<Appliance> appliances)
        {
            Console.WriteLine("Enter the item number of an appliance:");
            int input = Convert.ToInt32(Console.ReadLine());
            bool itemFound = false;

            foreach (Appliance item in appliances)
            {
                if (input == item.itemNumber)
                {
                    itemFound = true;
                    if (item.quantity >= 1)
                    {
                        item.quantity--;
                        Console.WriteLine($"Appliance {input} has been checked out");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Appliance {input} is not available to be checked out.");
                        break;
                    }
                }
            }

            if (!itemFound)
            {
                Console.WriteLine($"No appliances found with that item number.");
            }
        }

        //Method to display appliances by type (2) = SearchByBrand
        public static void SearchByBrand(List<Appliance> appliances)
        {
            Console.WriteLine("Enter brand to search for: ");
            string input = Console.ReadLine();
            foreach (Appliance appliance in appliances)
            {
                // Case insesnitive search by using ToLower() on everything
                if (input.ToLower() == appliance.brand.ToLower())
                {
                    Console.WriteLine(appliance.ToString());
                }
            }
        }

        //Method that allows a customer to purchase an appliance = DisplayAppliancesByType() (Getting there)
        /*
        public void DisplayAppliancesByType(List<Appliance> appliances)
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");
            Console.WriteLine("\nEnter type of appliance:");
            int input = Convert.ToInt32(Console.ReadLine());

            string[] lines = File.ReadAllLines("appliances.txt");

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                string applianceNumber = fields[0];
                char firstNumber = applianceNumber[0];

                if (input == 1)
                {
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Matching refrigerators: ");;
                    if (input == appliance.firstNumber)
                    {
                        //item.FormatFile();
                        Console.WriteLine(appliance.ToString());
                        //item.ToString();
                    }

                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high):");
                }
                else if (input == 3)
                {
                    Console.WriteLine("RoomWhere the microwave will be installed: K (kitchen) or W (work site):");
                }
                else if (input == 4)
                {
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                }

                else
                {
                    Console.WriteLine("Invalid Number Please input 1-4");
                }

            }
        }
        */

        //Method that prompts a user to enter a number, and the program then displays that number of random appliances = RandomApplianceList()
        public void RandomApplianceList(List<Appliance> appliances)
        {
            Console.WriteLine("Enter number of appliances:");
            int amount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < amount; i++)
            {
                var random = new Random();
                long newItemNumber = random.Next(100000000, 599999999);

                string[] brands = { "Bosch", "Tefal", "Hoover", "Black & Decker", "Miele", "Philips", "Kenwood", "Russell Hobbs", "Dyson", "Vax" };
                int brandIndex = random.Next(brands.Length);
                string newBrand = brands[brandIndex];

                int newQuantity = random.Next(1, 100);

                double newWattage = random.Next(1, 450) * 10;

                string[] colors = { "grey", "black", "white", "bronze", "silver" };
                int colorIndex = random.Next(colors.Length);
                string newColor = colors[colorIndex];

                double newPrice = random.Next(99, 2990);

                long checkingNewItemNumber = newItemNumber;
                while (checkingNewItemNumber >= 10)
                {
                    checkingNewItemNumber = (checkingNewItemNumber - (checkingNewItemNumber % 10)) / 10;

                }

                if (checkingNewItemNumber == 1)
                {
                    string[] doors = { "2", "3", "4" };
                    int doorIndex = random.Next(doors.Length);
                    string newDoors = doors[doorIndex];

                    int newHeight = random.Next(10, 50);
                    int newWidth = random.Next(10, 50);

                    Refrigerator newRefrigerator = new Refrigerator(Convert.ToInt32(newItemNumber), newBrand, Convert.ToInt32(newQuantity), Convert.ToInt32(newWattage), newColor, Convert.ToInt32(newPrice), Convert.ToInt32(newDoors), Convert.ToInt32(newHeight), Convert.ToInt32(newWidth));

                    Console.WriteLine(newRefrigerator.ToString());

                    appliances.Add(newRefrigerator);
                }
                if (checkingNewItemNumber == 2)
                {
                    string[] grades = { "Residential", "Commercial" };
                    int gradeIndex = random.Next(grades.Length);
                    string newGrade = grades[gradeIndex];

                    string[] voltages = { "18", "24" };
                    int voltageIndex = random.Next(voltages.Length);
                    string newVoltage = voltages[voltageIndex];

                    Vacuum newVacuum = new Vacuum(newItemNumber, newBrand, newQuantity, Convert.ToInt32(newWattage), newColor, newPrice, newGrade, Convert.ToInt32(newVoltage));

                    Console.WriteLine(newVacuum.ToString());

                    appliances.Add(newVacuum);
                }
                if (checkingNewItemNumber == 3)
                {
                    double newCapacity = random.Next(10, 20) / 10;

                    string[] roomTypes = { "K", "W" };
                    int roomTypeIndex = random.Next(roomTypes.Length);
                    string newRoomType = roomTypes[roomTypeIndex];

                    Microwave newMicrowave = new Microwave(Convert.ToInt32(newItemNumber), newBrand, Convert.ToInt32(newQuantity), Convert.ToInt32(newWattage), newColor, Convert.ToInt32(newPrice), Convert.ToInt32(newCapacity), newRoomType);

                    Console.WriteLine(newMicrowave.ToString());

                    appliances.Add(newMicrowave);
                }
                if (checkingNewItemNumber == 4 || checkingNewItemNumber == 5)
                {
                    string[] features = { "Clean with Steam", "Finger Print Resistant", "Third Rack" };
                    int featureIndex = random.Next(features.Length);
                    string newFeature = features[featureIndex];

                    string[] sounds = { "Qt", "Qr", "Qu", "M" };
                    int soundIndex = random.Next(sounds.Length);
                    string newSound = sounds[soundIndex];

                    Dishwasher newDishwasher = new Dishwasher(Convert.ToInt32(newItemNumber), newBrand, Convert.ToInt32(newQuantity), Convert.ToInt32(newWattage), newColor, Convert.ToInt32(newPrice), newFeature, newSound);

                    Console.WriteLine(newDishwasher.ToString());

                    appliances.Add(newDishwasher);
                }

            }
        }
    }
}