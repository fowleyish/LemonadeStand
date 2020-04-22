﻿using System;
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
                UI.WelcomeToANewDay(currentDay, days[currentDay - 1].weather.temperature, days[currentDay - 1].weather.sky);
                UI.DisplayInventory(player.inventory.lemons.Count, player.inventory.sugarCubes.Count, player.inventory.iceCubes.Count, player.inventory.cups.Count, player.wallet.Money);
                store.SellItems(player);
                UI.DisplayInventory(player.inventory.lemons.Count, player.inventory.sugarCubes.Count, player.inventory.iceCubes.Count, player.inventory.cups.Count, player.wallet.Money);
                player.SetRecipe();
                SellLemonade();
                UI.EndDay();
                currentDay++;
            }
        }

        public void SellLemonade()
        {
            List<Customer> potentialCustomers = days[currentDay].customers;
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
                    if (customer.plausibility + recipeQuality + priceScore >= 6)
                    {
                        player.SellCup();
                    }
                    if (player.pitcher.cupsLeftInPitcher == 0) 
                    {
                        player.MakeNewPitcher();
                    }
                }
            }
        }
    }
}
