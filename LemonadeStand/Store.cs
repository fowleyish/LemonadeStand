using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Store
    {

        // Member variables
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;
        private List<string> stock;

        // Constructor
        public Store()
        {
            pricePerLemon = 0.12;
            pricePerSugarCube = 0.10;
            pricePerCup = 0.15;
            pricePerIceCube = 0.6;
            stock = new List<string>()
            {
                "lemons",
                "sugar cubes",
                "ice cubes",
                "cups"
            };
        }

        // Member methods


        public void SellItems(Player player)
        {
            foreach (string item in stock)
            {
                int amountToPurchase = UI.GetNumberOfItems(item);
                double transactionAmount = 0;
                switch (item)
                {
                    case "lemons":
                        transactionAmount = CalculateTransactionAmount(amountToPurchase, pricePerLemon);
                        break;
                    case "sugar cubes":
                        transactionAmount = CalculateTransactionAmount(amountToPurchase, pricePerSugarCube);
                        break;
                    case "ice cubes":
                        transactionAmount = CalculateTransactionAmount(amountToPurchase, pricePerIceCube);
                        break;
                    case "cups":
                        transactionAmount = CalculateTransactionAmount(amountToPurchase, pricePerCup);
                        break;
                }
                if (player.wallet.Money >= transactionAmount)
                {
                    PerformTransaction(player.wallet, transactionAmount);
                    player.inventory.AddToInventory(item);
                }
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }

    }
}
