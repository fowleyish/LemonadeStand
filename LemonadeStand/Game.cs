using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Game
    {

        // Member variables
        private Player player;
        private List<Day> days;
        private int currentDay;
        private Store store;

        // Constructor
        public Game()
        {
            player = new Player(GetName());
            days = new List<Day>()
            {
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day()
            };
            currentDay = 1;
            store = new Store();
        }

        // Member methods

        public string GetName()
        {
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            return name;
        }

        public void StartGame()
        {
            UI.Welcome();
            while ( currentDay < 8 )
            {
                UI.WelcomeToANewDay(currentDay);
                UI.DisplayInventory(player.inventory.lemons.Count, player.inventory.sugarCubes.Count, player.inventory.iceCubes.Count, player.inventory.cups.Count, player.wallet.Money);
                store.SellItems(player);
                player.SetRecipe();
                StartDay();
                //ShowSales();
                //CalculateSatisfaction();
                //CalculateProfits();
                //UI.EndDay();
                currentDay++;
            }
        }

        public void StartDay()
        {
            List<Customer> potentialCustomers = days[currentDay].customers;
            double recipeQuality = player.recipe.recipeQuality;
            player.MakeNewPitcher();
            // Loop through each customer
            foreach (var customer in potentialCustomers)
            {
                if (customer.plausibility + recipeQuality >= 5)
                {
                    player.SellCup();
                }
                // check if there are any pitchers left.....
                // add in somewhere a factor for whether the price is reasonable (on recipe class)
            }
        }
    }
}
