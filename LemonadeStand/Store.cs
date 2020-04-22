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
            // Set prices per ingredient
            pricePerLemon = 0.07;
            pricePerSugarCube = 0.05;
            pricePerCup = 0.10;
            pricePerIceCube = 0.06;
            // Create a stock List<T>
            stock = new List<string>()
            {
                "lemons",
                "sugar cubes",
                "ice cubes",
                "cups"
            };
        }

        // Member methods

        // Sells items to Player() who pays money for items and adds purchased items to inventory
        public void SellItems(Player player)
        {
            DisplayPrices();
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
                    player.inventory.AddToInventory(item, amountToPurchase);
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

        // UI method to display prices on items
        private void DisplayPrices()
        {
            UI.LineBreak(1);
            Console.WriteLine("STORE PRICES");
            Console.WriteLine("============");
            UI.LineBreak(1);
            Console.WriteLine("Lemons: {0} per lemon", pricePerLemon.ToString("0.##"));
            Console.WriteLine("Sugar Cubes: {0} per cube", pricePerSugarCube.ToString("0.##"));
            Console.WriteLine("Ice Cubes: {0} per cube", pricePerIceCube.ToString("0.##"));
            Console.WriteLine("Cups: {0} per cup", pricePerCup.ToString("0.##"));
            UI.LineBreak(2);
        }

    }
}
