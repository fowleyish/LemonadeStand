using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace LemonadeStand
{
    static class UI
    {

        // Welcome method to display gameplay rules to the user
        public static void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to a new game of Lemonade Stand! \n");
            Console.WriteLine("How to play: \n" +
                "1. Each round, you will see the weather and your current inventory before heading to the store to stock up. \n" +
                "2. While at the store, you will purchase items to use for the day. \n" +
                "   NOTE that Ice Cubes melt at the end of each day, so be careful not to buy too many! \n" +
                "3. After buying products, you will set your recipe for the day. Be sure to set a reasonable asking price based on prior rounds. \n" +
                "4. Immediately following setting the recipe, the day will run and you will be presented with a report of how you did. \n" +
                "5. When the user completes 7 days, they will be presented with final profits and be asked if they would like to play again.") ;
            LineBreak(2);
            Console.Write("Press Enter to continue with Day 1");
            Console.ReadLine();
        }

        // Displays day value and weather details at the start of each day
        public static void WelcomeToANewDay(int day, int temp, string sky)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Day {0}!", day);
            Console.WriteLine("Today is {0} degrees and {1}.", temp, sky);
            LineBreak(1);
        }

        // Displays current inventory to the user
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
            LineBreak(3);
        }

        // Prompts user for purchase quantities of items in the Store()
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;
            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                LineBreak(1);
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.Write("Please enter a positive integer (or 0 to cancel): ");

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }
            return quantityOfItem;
        }

        // Produces an end-of-day report; invoked near the end of each day in Days<T>
        public static void EndDay(int potentialCustomers, int buyingCustomers, double startingMoney, double profits, double moneyAfterPurchases, int recipeQuality)
        {
            Console.Clear();
            Console.WriteLine("END OF DAY REPORT");
            Console.WriteLine("- Of {0} potential customers, you sold lemonade to {1} of them.", potentialCustomers, buyingCustomers);
            Console.WriteLine("- You started today with ${0} and made ${1} in purchases from the store.", startingMoney.ToString("0.##"), (startingMoney - moneyAfterPurchases).ToString("0.##"));
            Console.WriteLine("- You made ${0} in sales.", profits.ToString("0.##"));
            GetProfits(startingMoney, moneyAfterPurchases, profits);
            GetRecipeFeedback(recipeQuality);
            Console.WriteLine("- All your ice melted!");
            Console.Write("Press Enter to continue");
            Console.ReadLine();
        }

        // Displays profits for each day; outputs in end-of-day report
        public static void GetProfits(double starting, double leftover, double profits)
        {
            double outcome = starting - ( starting - leftover ) + profits;
            double x = outcome - starting;
            if (x < 0)
            {
                Console.WriteLine("- Unfortunately, you LOST ${0} today.", Math.Abs(x).ToString("0.##"));
            }
            else
            {
                Console.WriteLine("- Congrats! You earned ${0} today!", x.ToString("0.##"));
            }
        }

        // Accepts recipe quality to share feedback on its popularity among customers
        public static void GetRecipeFeedback(int quality)
        {
            switch (quality)
            {
                case 5:
                    Console.WriteLine("- Generally, people loved your recipe!");
                    break;
                case 4:
                    Console.WriteLine("- Generally, people enjoyed your recipe.");
                    break;
                case 3:
                    Console.WriteLine("- Generally, people were okay with your recipe.");
                    break;
                case 2:
                    Console.WriteLine("- Generally, people disliked your recipe.");
                    break;
                case 1:
                    Console.WriteLine("- Generally, people hated your recipe!");
                    break;
            }
        }

        // LineBreak() method for use throughout UI()
        public static void LineBreak(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine();
            }
        }

        // Final end-game status report; prompts user if they would like to play again
        public static void EndGame(double money)
        {
            Console.Clear();
            Console.WriteLine("And that's that! ");
            Console.WriteLine("You started with $20 and finished with ${0}!", money.ToString("0.##"));
            LineBreak(4);
            Console.WriteLine("Would you like to play again? Enter 1 for YES or anything else to close the application: ");
            string playAgain = Console.ReadLine();
            if (playAgain == "1")
            {
                new Game();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
                Environment.Exit(0);
            }
        }

    }

    
}
