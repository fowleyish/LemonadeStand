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

        public void SetRecipe()
        {
            recipe = new Recipe();
        }

        public void MakeNewPitcher()
        {
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
                pitcher = new Pitcher();
            }
            else
            {
                pitcher = null;
            }
        }

        public void SellCup()
        {
            if ( pitcher.cupsLeftInPitcher > 0 )
            {
                pitcher.cupsLeftInPitcher--;
                wallet.Money += recipe.pricePerCup;
                inventory.cups.RemoveAt(0);
            }
            else
            {
                MakeNewPitcher();
            }
        }

    }
}
