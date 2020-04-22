using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Customer
    {

        // Member variables
        public int plausibility; // random number 1-3 to determine whether the customer is in the mood for buying a cup already

        // Constructor
        public Customer()
        {
            plausibility = GetPlausibility();
        }

        // Member methods

        // Sets base plausibility of this customer buying a cup (max 3/10 for final calculation in Game())
        public int GetPlausibility()
        {
            Random r = new Random();
            return r.Next(1, 3);
        }

    }
}
