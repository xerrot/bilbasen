using Microsoft.VisualBasic;
using System;
using System.Runtime.ConstrainedExecution;

namespace bilbasen
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int NumberOfDoors { get; set; }
        public int Weight { get; set; }
        public int TrunkVolume { get; set; }
        public Engine engine { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine("----- Car Information -----");
            Console.WriteLine($"Brand         : {Brand}");
            Console.WriteLine($"Model         : {Model}");
            Console.WriteLine($"Year          : {Year}");
            Console.WriteLine($"Color         : {Color}");
            Console.WriteLine($"Doors         : {NumberOfDoors}");
            Console.WriteLine($"Weight        : {Weight} kg");
            Console.WriteLine($"Trunk Volume  : {TrunkVolume} L");
            Console.WriteLine($"Engine        : {engine}");
            Console.WriteLine("----------------------------");
        }

        public Car(string brand, string model, int year, string color, int num_doors, int weight, int trunkVolume, Engine engine)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
            NumberOfDoors = num_doors;
            Weight = weight;
            TrunkVolume = trunkVolume;
            this.engine = engine;
        }

    }

    public class Engine
    {
        public string Type { get; set; }
        public int HorsePower { get; set; }
        public int NumberOfCylinders { get; set; }
        public int Torque { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}, HorsePower: {HorsePower} HP, Cylinders: {NumberOfCylinders}, torque: {Torque}";
        }

        public Engine(string type, int horsepower, int num_cylinders, int torque)
        {
            Type = type;
            HorsePower = horsepower;
            NumberOfCylinders = num_cylinders;
            Torque = torque;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var brands = new[] { "Toyota", "BMW", "Ford", "Audi", "Honda", "Tesla", "Volkswagen" };
            var models = new[] { "Corolla", "3 Series", "Focus", "A4", "Civic", "Model 3", "Golf" };
            var colors = new[] { "Red", "Black", "White", "Blue", "Grey", "Green", "Yellow" };
            var engineTypes = new[] { "Petrol", "Diesel", "Electric", "Hybrid" };

            Random random = new Random(447);
            List<Car> cars = new List<Car>();

            for (int i = 0; i < 100; i++)
            {
                var brand = brands[random.Next(brands.Length)];
                var model = models[random.Next(models.Length)];
                var color = colors[random.Next(colors.Length)];
                var engineType = engineTypes[random.Next(engineTypes.Length)];
                var year = random.Next(1995, 2025);
                var doors = random.Next(2, 6);
                var weight = random.Next(900, 2500);
                var trunk = random.Next(200, 700);
                var horsepower = random.Next(70, 600);
                var cylinders = engineType == "Electric" ? 0 : random.Next(3, 12);
                var torque = random.Next(100, 800);

                var engine = new Engine(engineType, horsepower, cylinders, torque);
                var car = new Car(brand, model, year, color, doors, weight, trunk, engine);

                cars.Add(car);

            }

            // display all cars of the same brand as the first car in dataset
            void DisplayCarsSameBrand()
            {
                foreach (var car in cars)
                {
                    if (car.Brand == cars[0].Brand)
                    {
                        car.DisplayInfo();
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            //display all cars that have more than 200 HP
            void DsipalyCars200HP()
            {
                foreach (var car in cars)
                {
                    if (car.engine.HorsePower >= 200)
                    {
                        car.DisplayInfo();
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            void DisplayRedCars()
            {
                foreach (var car in cars)
                {
                    if (car.Color.ToLower() == "red")
                    {
                        car.DisplayInfo();
                    }
                    else { continue; }
                }
            }

            int index = 0;
            void DisplayNumberOfCars()
            {
                foreach (var car in cars)
                {
                    if (car.Brand == cars[0].Brand)
                    {
                        index++;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine($"Amount of cars of brand {cars[0].Brand} is {index}");
            }

            void DisplayCarsBetween1980and1999()
            {
                foreach (var car in cars)
                {
                    if (car.Year > 1980 && car.Year < 1999)
                    {
                        car.DisplayInfo();
                    }
                    else { continue; }
                }
            }
        }
    }
}
