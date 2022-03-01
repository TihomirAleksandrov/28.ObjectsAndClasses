using System;
using System.Linq;
using System.Collections.Generic;

namespace VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] input = command.Split('/', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string type = input[0];
                string brand = input[1];
                string model = input[2];
                int hpOrWeight = int.Parse(input[3]);

                if (type == "Truck")
                {
                    Truck truck = new Truck
                    {
                        Brand = brand,
                        Model = model,
                        Weight = hpOrWeight
                    };

                    catalogue.Trucks.Add(truck);
                }
                else if (type == "Car")
                {
                    Car car = new Car
                    {
                        Brand = brand,
                        Model = model,
                        HorsePower = hpOrWeight
                    };

                    catalogue.Cars.Add(car);
                }

                command = Console.ReadLine();
            }

            catalogue.Trucks = catalogue.Trucks.OrderBy(x => x.Brand).ToList();
            catalogue.Cars = catalogue.Cars.OrderBy(x => x.Brand).ToList();

            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");

                foreach (Car car in catalogue.Cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }


            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (Truck truck in catalogue.Trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    public class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    public class Catalogue
    {
        public Catalogue()
        {
            this.Cars = new List<Car>();

            this.Trucks = new List<Truck>();
        }
        
        public List<Car> Cars { get; set; }

        public List<Truck> Trucks { get; set; }
    }
}
