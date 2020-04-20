using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Customer
    {

        // Member variables
        public int plausibility;

        // Constructor
        public Customer()
        {
            plausibility = GetPlausibility();
        }

        // Member methods

        public int GetPlausibility()
        {
            Random r = new Random();
            return r.Next(1, 3);
        }

    }
}
