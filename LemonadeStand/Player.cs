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
            recipe = new Recipe();
            pitcher = new Pitcher();
        }
        
        // Member methods



    }
}
