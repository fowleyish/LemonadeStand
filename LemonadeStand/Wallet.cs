using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Wallet
    {

        // Member variables
        private double money;
        public double Money
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
            money = 20;
        }


        // Member methods

        public void PayMoneyForItems(double transactionAmount)
        {
            money -= transactionAmount;
        }


    }
}
