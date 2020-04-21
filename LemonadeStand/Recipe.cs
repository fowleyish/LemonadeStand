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
        public int recipeQuality;
        public double reasonablePrice;

        // Constructor 
        public Recipe()
        {
            amountOfLemons = SetQuantityPerPitcher("LEMONS");
            amountOfSugarCubes = SetQuantityPerPitcher("SUGAR CUBES");
            amountOfIceCubes = SetQuantityPerPitcher("ICE CUBES");
            pricePerCup = SetPricePerCup();
            recipeQuality = GetRecipeQuality();
            reasonablePrice = CalculateReasonablePrice(recipeQuality);
        }

        // Member methods

        public int SetQuantityPerPitcher(string ingredient)
        {
            Console.Write("How many {0} per pitcher?: ", ingredient);
            int amount = int.Parse(Console.ReadLine());
            return amount;
        }

        public double SetPricePerCup()
        {
            Console.Write("How much will you charge per cup?: ");
            double price = double.Parse(Console.ReadLine());
            return price;
        }

        public int GetRecipeQuality()
        {
            double lemonsToSugar = amountOfLemons / amountOfSugarCubes;
            double fluidToIce = lemonsToSugar / amountOfIceCubes;
            int quality = 0;
            if (fluidToIce >= 1.6)
            {
                quality = 1;
            }
            else if (fluidToIce >= 0.6 && fluidToIce < 1.6)
            {
                quality = 2;
            }
            else if (fluidToIce <= 0.05 || (fluidToIce >= 0.35 && fluidToIce <= 0.6))
            {
                quality = 3;
            }
            else if (fluidToIce > 0.05 && fluidToIce < 0.2 || fluidToIce > 0.2 && fluidToIce < 0.35)
            {
                quality = 4;
            }
            else if (fluidToIce == 0.2)
            {
                quality = 5;
            }
            return quality;
        }

        public double CalculateReasonablePrice(int quality)
        {
            double reasonablePrice = quality / 10;
            return reasonablePrice;
        }

    }
}
