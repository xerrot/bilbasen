using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks.Dataflow;

namespace bilbasen
{
    public interface ICar
    {
        string Brand { get; }
        string Model { get; }
        double Price { get; }
    }

    public abstract class Vehicle : ICar
    {
        private string _type;
        private string _brand;
        private string _model;
        private double _price;
        private int _year;
        private string _color;
        private int _numberOfDoors;
        private double _weight;
        private double _trunkVolume;
        private int _horsePower;
        public string Brand { get => _brand; }
        public string Model { get => _model; }
        public double Price { get => _price; }
        public int Year { get => _year; }
        public string Color { get => _color; }
        public int NumberOfDoors { get => _numberOfDoors; }
        public double Weight { get => _weight; }
        public double TrunkVolume { get => _trunkVolume; }
        public int HorsePower { get => _horsePower; }
        public string type { get => _type; }

        public abstract void DisplayInfo();

        public Vehicle(string type, string brand, string model, double price, int year, string color, int numberDoors, double weight, double trunkVolume, int HP)
        {
            _type = type;
            _brand = brand;
            _model = model;
            _price = price;
            _year = year;
            _color = color;
            _numberOfDoors = numberDoors;
            _weight = weight;
            _trunkVolume = trunkVolume;
            _horsePower = HP;

        }
    }

    public class FuelCar : Vehicle
    {
        private string _fuelType;
        private string _type;

        public string TypeOfVehicle { get => _type; }
        public string FuelType { get => _fuelType; }

        public FuelCar(string type, string brand, string model, double price, int year, string color, int numberDoors, double weight, double trunkVolume, int HP, string fuel_type)
            : base(type, brand, model, price, year, color, numberDoors, weight, trunkVolume, HP)
        {
            _fuelType = fuel_type;
            _type = type;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("----- Vehicle Information -----");
            Console.WriteLine($"Type          : {type}");
            Console.WriteLine($"Brand         : {Brand}");
            Console.WriteLine($"Model         : {Model}");
            Console.WriteLine($"Horse Powers  : {HorsePower} HP");
            Console.WriteLine($"Year          : {Year}");
            Console.WriteLine($"Color         : {Color}");
            Console.WriteLine($"Doors         : {NumberOfDoors}");
            Console.WriteLine($"Weight        : {Weight} kg");
            Console.WriteLine($"Trunk Volume  : {TrunkVolume} L");
            Console.WriteLine($"Fuel Type     : {FuelType} ");
            Console.WriteLine("-------------------------------\n");
        }
    }

    public class ElectricCar : Vehicle
    {
        private int _batteryCapacity { get; set; } //kWh
        private string _type;

        public string TypeOfVehicle { get => _type; }
        public int BatterCapacity { get => _batteryCapacity; }


        public ElectricCar(string type, string brand, string model, double price, int year, string color, int numberDoors, double weight, double trunkVolume, int HP, int battery_capacity)
            : base(type, brand, model, price, year, color, numberDoors, weight, trunkVolume, HP)
        {
            _batteryCapacity = battery_capacity;
            _type = type;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("----- Vehicle Information -----");
            Console.WriteLine($"Type          : {TypeOfVehicle}");
            Console.WriteLine($"Brand         : {Brand}");
            Console.WriteLine($"Model         : {Model}");
            Console.WriteLine($"Horse Powers  : {HorsePower} HP");
            Console.WriteLine($"Year          : {Year}");
            Console.WriteLine($"Color         : {Color}");
            Console.WriteLine($"Doors         : {NumberOfDoors}");
            Console.WriteLine($"Weight        : {Weight} kg");
            Console.WriteLine($"Trunk Volume  : {TrunkVolume} L");
            Console.WriteLine($"Battery Capacity: {BatterCapacity}");
            Console.WriteLine("-------------------------------\n");
        }
    }

    public class Motorcycle : Vehicle
    {
        private string _fuelType;
        private string _type;

        public string TypeOfVehicle { get => _type; }
        public string FuelType { get => _fuelType; }

        public Motorcycle(string type, string brand, string model, double price, int year, string color, int numberDoors, double weight, double trunkVolume, int HP, string fuel_type)
            : base(type, brand, model, price, year, color, numberDoors, weight, trunkVolume, HP)
        {
            _type = type;
            _fuelType = fuel_type;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("----- Vehicle Information -----");
            Console.WriteLine($"Type          : {TypeOfVehicle}");
            Console.WriteLine($"Brand         : {Brand}");
            Console.WriteLine($"Model         : {Model}");
            Console.WriteLine($"Horse Powers  : {HorsePower} HP");
            Console.WriteLine($"Year          : {Year}");
            Console.WriteLine($"Color         : {Color}");
            Console.WriteLine($"Doors         : {NumberOfDoors}");
            Console.WriteLine($"Weight        : {Weight} kg");
            Console.WriteLine($"Trunk Volume  : {TrunkVolume} L");
            Console.WriteLine($"Type          : {FuelType} ");
            Console.WriteLine("-------------------------------\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(442);
            List<Vehicle> vehicles = new List<Vehicle>();
            string[] colors = { "Red", "Blue", "Black", "White", "Silver", "Green", "Yellow", "Gray" };

            string[] fuelCarModels = { "Corolla", "Civic", "A4", "Mustang" };
            string[] electricCarModels = { "Model 3", "Leaf", "ID.4", "i3" };
            string[] motorcycleModels = { "MT-07", "Ninja 400", "CBR500R", "Z650" };

            string[] fuelCarBrands = { "Toyota", "Honda", "Audi", "Ford" };
            string[] electricCarBrands = { "Tesla", "Nissan", "BMW", "Volkswagen" };
            string[] motorcycleBrands = { "Yamaha", "Kawasaki", "Honda", "Suzuki" };

            int[] horsePowers = { 100, 150, 200, 250, 300 };
            string[] fuelTypes = { "Petrol", "Diesel", "Gasoline" }; // for fuel cars
            int[] batteryCapacities = { 40, 60, 75, 85, 100 }; // for electric cars
            int[] years = { 1975, 1980, 1985, 1986, 1987, 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2005, 2010, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 };
            int[] doorCounts = { 2, 3, 4, 5 };
            double[] weights = { 1000, 1200, 1400, 1600, 1800, 2000 };
            double[] trunkVolumes = { 300, 400, 500, 600 };
            double[] prices = { 100000, 150000, 200000, 250000, 300000 };

            // add 50 fuel cars
            for (int i = 0; i < 50; i++)
            {
                vehicles.Add(new FuelCar(
                    "Fuel Car",
                    fuelCarBrands[rnd.Next(fuelCarBrands.Length)],          // brand, model, price, year, color, numberDoors, weight, trunkVolume, HP, fuelType
                    fuelCarModels[rnd.Next(fuelCarModels.Length)],
                    prices[rnd.Next(prices.Length)],
                    years[rnd.Next(years.Length)],
                    colors[rnd.Next(colors.Length)],
                    doorCounts[rnd.Next(doorCounts.Length)],
                    weights[rnd.Next(weights.Length)],
                    trunkVolumes[rnd.Next(trunkVolumes.Length)],
                    horsePowers[rnd.Next(horsePowers.Length)],
                    fuelTypes[rnd.Next(fuelTypes.Length)]
                ));
            }

            // add 25 electric cars
            for (int i = 0; i < 25; i++)
            {
                vehicles.Add(new ElectricCar(
                    "Electric",
                    electricCarBrands[rnd.Next(electricCarBrands.Length)],      //brand, model, price, year, color, numberDoors, weight, trunkVolume, HP, battery_capacity
                    electricCarModels[rnd.Next(electricCarModels.Length)],
                    prices[rnd.Next(prices.Length)],
                    years[rnd.Next(years.Length)],
                    colors[rnd.Next(colors.Length)],
                    doorCounts[rnd.Next(doorCounts.Length)],
                    weights[rnd.Next(weights.Length)],
                    trunkVolumes[rnd.Next(trunkVolumes.Length)],
                    horsePowers[rnd.Next(horsePowers.Length)],
                    batteryCapacities[rnd.Next(batteryCapacities.Length)]
                ));
            }

            // add 25 motorcycles
            for (int i = 0; i < 25; i++)
            {
                vehicles.Add(new Motorcycle(
                    "Motorcycle",
                    motorcycleBrands[rnd.Next(motorcycleBrands.Length)],      //brand, model, price, year, color, numberDoors, weight, trunkVolume, HP, fuel_type
                    motorcycleModels[rnd.Next(motorcycleModels.Length)],
                    prices[rnd.Next(prices.Length)],
                    years[rnd.Next(years.Length)],
                    colors[rnd.Next(colors.Length)],
                    0,
                    weights[rnd.Next(weights.Length)] / 5,
                    trunkVolumes[rnd.Next(trunkVolumes.Length)] / 5,
                    horsePowers[rnd.Next(horsePowers.Length)],
                    fuelTypes[rnd.Next(fuelTypes.Length)]
                ));
            }

            void PrintSameBrand()
            {
                foreach (var vehicle in vehicles.Where(v => v.Brand == vehicles[0].Brand)) { vehicle.DisplayInfo(); }
            }

            void PrintAllRed()
            {
                foreach (var vehicle in vehicles.Where(v => v.Color.ToLower() == "red")) { vehicle.DisplayInfo(); }
            }

            void PrintAllOver200HP()
            {
                foreach (var vehicle in vehicles.Where(v => v.HorsePower >= 200)) { vehicle.DisplayInfo(); }
            }

            void PrintNumberSameBrand()
            {
                string firstBrand = vehicles[0].Brand;
                int sameBrandCount = vehicles.Count(v => v.Brand == firstBrand);
                Console.WriteLine($"There are {sameBrandCount} vehicles of the brand {firstBrand}");
            }

            void PrintBetween1980And1999()
            {
                foreach (var vehicle in vehicles.Where(v => v.Year >= 1980 && v.Year <= 1999)) { vehicle.DisplayInfo(); }
            }

            void PrintAll()
            {
                foreach (var vehicle in vehicles) { vehicle.DisplayInfo(); }
            }


            string command;
            while (true)
            {
                Console.WriteLine("Welcome to Bilbasen! Please choose what you want to do:\n\n" +
               "1.See all vehicles that have the same brand as the first vehicle in the dataset.\n" +
               "2.See all vehicles that have more than 200 horse powers.\n" +
               "3.See all red cars.\n" +
               "4.See the number of vehicles that have the same brand as the first vehicle in the dataset.\n" +
               "5.See all vehicles that were manufactured between 1980 and 1999.\n" +
               "6.See all vehicles.\n" + 
               "7.Exit");

                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.Clear();
                        PrintSameBrand(); break;
                    case "2":
                        Console.Clear();
                        PrintAllOver200HP(); break;
                    case "3":
                        Console.Clear();
                        PrintAllRed(); break;
                    case "4":
                        Console.Clear();
                        PrintNumberSameBrand(); break;
                    case "5":
                        Console.Clear();
                        PrintBetween1980And1999(); break;
                    case "6":
                        Console.Clear();
                        PrintAll(); break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Have a nice day!");
                        Thread.Sleep(500);
                        Environment.Exit(0);
                        break;
                    default: Console.Clear(); Console.WriteLine("Please etner a valid number and try again!"); break;
                }
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
