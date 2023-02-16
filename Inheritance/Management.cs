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

        public Management() //Calls required methods to make the program run
        {
            loadAppliancesListFromFile();
            Menu();
        }

        //Methods
        //Method that parses the appliances.txt file into a single list
        public void loadAppliancesListFromFile()
        {
            string[] lines = File.ReadAllLines("appliances.txt");

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                string applianceNumber = fields[0];
                char firstNumber = applianceNumber[0];
                switch (firstNumber)
                {
                    case '1':
                        //adding a Refrigerator object to list                      
                        appliances.Add(new Refrigerator(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), Convert.ToInt32(fields[6]), Convert.ToInt32(fields[7]), Convert.ToInt32(fields[8])));
                        break;
                    case '2':
                        //adding a Vacuum object to list 
                        appliances.Add(new Vacuum(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), fields[6], Convert.ToInt32(fields[7])));

                        break;
                    case '3':
                        //adding a Microwave object to list  
                        appliances.Add(new Microwave(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), double.Parse(fields[6]), fields[7]));
                        break;
                    case '4':
                    case '5':
                        //adding a Dishwasher object to list 
                        appliances.Add(new Dishwasher(long.Parse(fields[0]), fields[1], Convert.ToInt32(fields[2]), Convert.ToInt32(fields[3]),
                            fields[4], double.Parse(fields[5]), fields[6], fields[7]));
                        break;
                }
            }
        }

        //Method that operates the menu
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("Welcome to Modern Appliances!" +
                "\nHow may we assist you?" +
                "\n1 – Check out appliance" +
                "\n2 – Find appliances by brand" +
                "\n3 – Display appliances by type" +
                "\n4 – Produce random appliance list" +
                "\n5 – Save & exit");

                int input = Convert.ToInt32(Console.ReadLine());

                //if else statements using user input

                if (input == 1)
                {
                    Checkout(appliances);
                }
                else if (input == 2)
                {
                    DisplayAppliancesByBrand(appliances);
                }
                else if (input == 3)
                {
                    DisplayAppliancesByType(appliances);
                }
                else if (input == 4)
                {
                    RandomApplianceList(appliances);
                }
                else if (input == 5)
                {
                    Console.WriteLine("Save and Exit");
                    SaveFile(appliances);
                    break;
                }
                else { Console.WriteLine("Error, invalid user input, please enter 1-5."); }
            continue;
            }
        }

        //Method that allows a customer to purchase an appliance = Checkout  
        public void Checkout(List<Appliance> appliances)
        {
            Console.WriteLine("Enter the item number of an appliance:");
            int input = Convert.ToInt32(Console.ReadLine());
            
            bool itemFound = false;
            //for each loop to go through all appliance item numbers
            foreach (Appliance item in appliances)
            {
                if (input == item.itemNumber)
                {
                    itemFound = true;
                    if (item.quantity > 0)
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

        //Method to display appliances by brand = SearchByBrand
        public static void DisplayAppliancesByBrand(List<Appliance> appliances)
        {
            Console.WriteLine("Enter brand to search for:");
            string input = Console.ReadLine();
            foreach (Appliance appliance in appliances)
            {
                // Case insesnitive search by using ToLower() on brand input
                if (input.ToLower() == appliance.brand.ToLower())
                {
                    Console.WriteLine(appliance.ToString());
                }
            }
        }

        //Method that display appliances by type = DisplayAppliancesByType 
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
            
            while (true)
            {
                if (input == 1) //Displays Refrigerators based on their number of doors
                {
                    Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
                    int numberofdoors = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Matching refrigerators: ");;
                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Refrigerator)
                        {
                            Refrigerator refrigerator = (Refrigerator)appliance;
                            {
                                if (refrigerator.NumberOfDoors == numberofdoors)
                                {
                                    Console.WriteLine(refrigerator.ToString());
                                    
                                }
                            }
                        }   
                    }
                    break;
                    
                }
                else if (input == 2) //Displays Vacuums based on their voltage
                {
                    Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high):");
                    int battery = Convert.ToInt32(Console.ReadLine());
                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Vacuum)
                        {
                            Vacuum vac = (Vacuum)appliance;
                            {
                                if (vac.Voltage == battery)
                                {
                                    Console.WriteLine(vac.ToString());

                                }
                            }
                        }
                    }
                    break;
                }
                else if (input == 3) //Displays Mircrowaves based on their room type
                {
                    Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
                    string roomtype = Console.ReadLine();
                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Microwave)
                        {
                            Microwave mic = (Microwave)appliance;
                            {
                                if (mic.roomType == roomtype)
                                {
                                    Console.WriteLine(mic.ToString());

                                }
                            }
                        }
                    }
                    break;
                }
                else if (input == 4) //Displays Dishwashers based on their sound rating
                {
                    Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                    string soundrating = Console.ReadLine();
                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Dishwasher)
                        {
                            Dishwasher dic = (Dishwasher)appliance;
                            {
                                if (dic.soundRating == soundrating)
                                {
                                    Console.WriteLine(dic.ToString());

                                }
                            }
                        }
                    }
                    break;
                }

                else ////Displays invalid user input error message
                {
                    Console.WriteLine("Error, invalid user input, please enter 1-4.");
                    break;
                }

            }
        }
        

        //Method that prompts a user to enter a number, and the program then displays that number of random appliances = RandomApplianceList()
        public void RandomApplianceList(List<Appliance> appliances)
        {
            Console.WriteLine("Enter number of appliances:");
            int amount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < amount; i++)
            {
                //Getting a random item number
                var random = new Random();
                long newItemNumber = random.Next(100000000, 599999999);
                //Getting a random brand
                string[] brands = { "Bosch", "Tefal", "Hoover", "Black & Decker", "Miele", "Philips", "Kenwood", "Russell Hobbs", "Dyson", "Vax" };
                int brandIndex = random.Next(brands.Length);
                string newBrand = brands[brandIndex];
                //Getting a random item quantity
                int newQuantity = random.Next(1, 100);
                //Getting a random wattage
                double newWattage = random.Next(1, 450) * 10;
                //Getting a random color
                string[] colors = { "grey", "black", "white", "bronze", "silver" };
                int colorIndex = random.Next(colors.Length);
                string newColor = colors[colorIndex];
                //Getting a random price
                double newPrice = random.Next(99, 2990);

                long checkingNewItemNumber = newItemNumber;
                //Find the appliance type based on the random item number
                while (checkingNewItemNumber >= 10)
                {
                    checkingNewItemNumber = (checkingNewItemNumber - (checkingNewItemNumber % 10)) / 10;

                }
                //if Refrigerator
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
                //if Vacuum
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
                //if Microwave
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
                //if Dishwasher
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

        //Method to take the appliances stored in the list and save them to the appliances.txt file
        public void SaveFile(List<Appliance> appliances)
        {
            string appliancesFile = @"appliances.txt";
            using (StreamWriter save = File.AppendText(appliancesFile))
            {
                save.WriteLine("Appliances saved to list.");
            }
        }
    }
}