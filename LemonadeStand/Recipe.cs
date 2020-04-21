using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Recipe
    {

        // Member variables
        public int amountOfLemons;
        public int amountOfSugarCubes;
        public int amountOfIceCubes;
        public double pricePerCup;

        // Constructor 
        public Recipe()
        {
            amountOfLemons = SetQuantityPerPitcher("LEMONS");
            amountOfSugarCubes = SetQuantityPerPitcher("SUGAR CUBES");
            amountOfIceCubes = SetQuantityPerPitcher("ICE CUBES");
            pricePerCup = SetPricePerCup();
        }

        // Member methods

        public int SetQuantityPerPitcher(string ingredient)
        {
            Console.Write("How many {0} per pitcher?: ", ingredient);
            int amount = int.Parse(Console.ReadLine());
            return amount;
        }

        public int SetPricePerCup()
        {
            Console.Write("How much will you charge per cup?: ");
            int price = int.Parse(Console.ReadLine());
            return price;
        }

    }
}
