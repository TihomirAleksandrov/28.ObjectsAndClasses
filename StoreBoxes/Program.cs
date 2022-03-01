using System;
using System.Linq;
using System.Collections.Generic;

namespace StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] input = command.Split(' ').ToArray();

                int serialNumber = int.Parse(input[0]);
                string itemName = input[1];
                int itemQuantity = int.Parse(input[2]);
                double itemPrice = double.Parse(input[3]);

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Quantity = itemQuantity,

                    Item = new Item()
                    {
                        Name = itemName,
                        Price = itemPrice,
                    }
                };

                boxes.Add(box);

                command = Console.ReadLine();
            }

            List<Box> sortedBoxes = boxes.OrderByDescending(box => box.BoxPrice).ToList();

            foreach (Box box in sortedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public double Price { get; set; }
    }

    public class Box
    {
        public Box()
        {
            Item = new Item();
        }
        
        public int SerialNumber { get; set; }

        public Item Item { get; set; }

        public int Quantity { get; set; }

        public double BoxPrice
        {
            get
            {
                return this.Quantity * this.Item.Price;
            }
        }

        
    }
}
