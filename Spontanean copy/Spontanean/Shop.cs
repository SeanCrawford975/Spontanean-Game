using System;
using static System.Console;

namespace Spontanean
{
    public class Shop
    {
        public string Name;
        public string Description;
        public decimal Price;

        public Shop(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void Listing()
        {
            WriteLine(">>There's a " + Name + ". "+ Description+". It costs $" + Price + ".");
        }
    }
}