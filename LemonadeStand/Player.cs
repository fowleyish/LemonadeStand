using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Player
    {

        // Member variables
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;


        // Constructor
        public Player(string name)
        {
            this.name = name;
            inventory = new Inventory();
            wallet = new Wallet();
        }
        
        // Member methods

        // Create a new recipe each day
        public void SetRecipe()
        {
            recipe = new Recipe();
        }

        // Try to make a pitcher...
        public void MakeNewPitcher()
        {
            // ...if there are enough ingredients...
            if (inventory.lemons.Count >= recipe.amountOfLemons &&
                inventory.sugarCubes.Count >= recipe.amountOfSugarCubes &&
                inventory.iceCubes.Count >= recipe.amountOfIceCubes)
            {
                for (int i = 0; i < recipe.amountOfLemons; i++)
                {
                    inventory.lemons.RemoveAt(0);
                }
                for (int i = 0; i < recipe.amountOfSugarCubes; i++)
                {
                    inventory.sugarCubes.RemoveAt(0);
                }
                for (int i = 0; i < recipe.amountOfIceCubes; i++)
                {
                    inventory.iceCubes.RemoveAt(0);
                }
                pitcher = new Pitcher(); // ...make a new pitcher after deducing the ingredients from my inventory
            }
            else
            { // ...otherwise, set pitcher to null, thus halting sales for the day in Game()
                pitcher = null;
            }
        }

        // Every time a cup is sold...
        public void SellCup()
        {
            // Check if I even have enough cups left in my pitcher...
            if ( pitcher.cupsLeftInPitcher > 0 )
            {
                pitcher.cupsLeftInPitcher--; // Pour one cup from my pitcher
                wallet.Money += recipe.pricePerCup; // Add money to my wallet
                inventory.cups.RemoveAt(0); // Get rid of a cup
            }
            // If I don't have enough cups left, make a new pitcher and sell a cup
            else
            {
                MakeNewPitcher();
                SellCup();
            }
        }

    }
}
