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

        public void AddToInventory(int items)
        {

        }

    }
}
