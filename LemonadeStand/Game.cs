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
            player = new Player(GetName()); // Create new Player
            days = new List<Day>() // 7 days
            {
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day(),
                new Day()
            };
            currentDay = 1; // Start on Day 1
            store = new Store(); // Create new Store()
        }

        // Member methods

        //Get player's name
        public string GetName()
        {
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            return name;
        }

        // This method controls overall game flow, including round control and end game
        public void StartGame()
        {
            UI.Welcome();
            while ( currentDay < days.Count + 1 )
            {
                UI.WelcomeToANewDay(currentDay, days[currentDay - 1].weather.temperature, days[currentDay - 1].weather.sky);
                double startingMoney = player.wallet.Money;
                UI.DisplayInventory(player.inventory.lemons.Count, player.inventory.sugarCubes.Count, player.inventory.iceCubes.Count, player.inventory.cups.Count, player.wallet.Money);
                store.SellItems(player);
                double moneyAfterPurchases = player.wallet.Money;
                UI.DisplayInventory(player.inventory.lemons.Count, player.inventory.sugarCubes.Count, player.inventory.iceCubes.Count, player.inventory.cups.Count, player.wallet.Money);
                player.SetRecipe();
                SellLemonade();
                UI.EndDay(days[currentDay - 1].customers.Count, days[currentDay - 1].buyingCustomers, startingMoney, days[currentDay - 1].moneyMade, moneyAfterPurchases, player.recipe.recipeQuality);
                player.inventory.iceCubes.Clear(); // Clear out all ice at end of each round
                currentDay++; // Continue to the next day
            }
            UI.EndGame(player.wallet.Money);
        }

        // Controls sales that happen within a day
        public void SellLemonade()
        {
            List<Customer> potentialCustomers = days[currentDay - 1].customers;
            double recipeQuality = player.recipe.recipeQuality;
            double reasonablePrice = recipeQuality / 10;
            int priceScore;
            if (player.recipe.pricePerCup < reasonablePrice + 0.05)
            {
                priceScore = 2;
            }
            else
            {
                priceScore = 0;
            }
            player.MakeNewPitcher();
            // Loop through each customer
            foreach (var customer in potentialCustomers)
            {
                if (player.pitcher != null && player.inventory.cups.Count != 0)
                {
                    if (customer.plausibility + recipeQuality + priceScore >= 6) // 3 factors are scored: price, recipe quality, and customer plausibility. Max score is 10.
                    {
                        player.SellCup(); // if the score for this customer is -ge 6, they buy a cup...
                        days[currentDay - 1].moneyMade += player.recipe.pricePerCup; // ...money adds to profits for the day...
                        days[currentDay - 1].buyingCustomers++; // ...and customers that bought gets incremented
                    }
                    if (player.pitcher.cupsLeftInPitcher == 0) 
                    {
                        player.MakeNewPitcher(); // Try to make a new pitcher if the current pitcher is empty
                    }
                }
            }
        }
    }
}
