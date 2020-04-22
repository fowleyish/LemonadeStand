using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Inventory
    {

        // Member variables
        public List<Lemon> lemons;
        public List<IceCube> iceCubes;
        public List<Cup> cups;
        public List<SugarCube> sugarCubes;

        // Constructor
        public Inventory()
        {
            lemons = new List<Lemon>();
            iceCubes = new List<IceCube>();
            cups = new List<Cup>();
            sugarCubes = new List<SugarCube>();
        }

        // Member methods

        // Method referenced from Store(); accepts type of item and quantity and adds quantity of item to the corresponding list
        public void AddToInventory(string item, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                switch (item)
                {
                    case "lemons":
                        Lemon lemon = new Lemon();
                        lemons.Add(lemon);
                        break;
                    case "sugar cubes":
                        SugarCube sugarCube = new SugarCube();
                        sugarCubes.Add(sugarCube);
                        break;
                    case "ice cubes":
                        IceCube iceCube = new IceCube();
                        iceCubes.Add(iceCube);
                        break;
                    case "cups":
                        Cup cup = new Cup();
                        cups.Add(cup);
                        break;
                }
            }
        }

    }
}
