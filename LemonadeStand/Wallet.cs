using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Wallet
    {

        // Member variables
        private double money;
        public double Money // Accessor to private money; includes get and set
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }

        // Constructor
        public Wallet()
        {
            // User starts with $20
            money = 20;
        }


        // Member methods

        // Invoked in Store() to pay for items purchased
        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }


    }
}
