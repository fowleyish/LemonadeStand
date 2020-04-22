using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    static class UI
    {

        public static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to a new game of Lemonade Stand! \n");
            Console.WriteLine("How to play: \n" +
                "1. Rules \n" +
                "2. Rules \n" +
                "3. Rules \n" +
                "4. Rules \n" +
                "5. Rules");
            LineBreak(2);
            Console.Write("Press Enter to continue with Day 1");
            Console.ReadLine();
        }

        public static void WelcomeToANewDay(int day, int temp, string sky)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Day {0}!", day);
            Console.WriteLine("Today is {0} degrees and {1}.", temp, sky);
            LineBreak(1);
        }

        public static void DisplayInventory(int lemons, int sugar, int ice, int cups, double money)
        {
            Console.WriteLine("INVENTORY");
            Console.WriteLine("=========");
            LineBreak(1);
            Console.WriteLine("Lemons: {0}", lemons);
            Console.WriteLine("Sugar cubes: {0}", sugar);
            Console.WriteLine("Ice cubes: {0}", ice);
            Console.WriteLine("Cups: {0}", cups);
            Console.WriteLine("Available funds: ${0}", money.ToString("0.##"));
        }

        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;
            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("STORE");
                Console.WriteLine("=====");
                LineBreak(1);
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.Write("Please enter a positive integer (or 0 to cancel):");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
                Console.Clear();
            }
            return quantityOfItem;
        }

        public static void EndDay(int potentialCustomers, int buyingCustomers, int profits, int recipeQuality)
        {

        }

        public static void LineBreak(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("");
            }
        }

    }

    
}
