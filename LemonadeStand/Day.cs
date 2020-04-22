using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Day
    {

        // Member variables
        public Weather weather;
        public List<Customer> customers;
        public double moneyMade;
        public int buyingCustomers;

        // Constructor
        public Day()
        {
            weather = new Weather();
            customers = GetCustomers();
            moneyMade = 0; // each day starts at 0 profits
            buyingCustomers = 0; // each day starts at 0 customers
        }

        // Member methods

        // Calculates maximum potential customers from weather variables
        public List<Customer> GetCustomers()
        {
            double currentTemp = weather.temperature;
            string currentSky = weather.sky;
            double minimumCustomers = 50;
            double currentSkyValue = 0;
            // Assigns a numerical value to the sky condition
            switch (currentSky)
            {
                case "clear":
                    currentSkyValue = 25;
                    break;
                case "cloudy":
                    currentSkyValue = 20;
                    break;
                case "overcast":
                    currentSkyValue = 15;
                    break;
                case "raining":
                    currentSkyValue = 10;
                    break;
            }
            // Max potential customers = 50 minimum plus the current tempurature / 4 plus the value associated with the current weather condition
            int potentialCustomers = Convert.ToInt32(minimumCustomers + (currentTemp / 4) + currentSkyValue);
            customers = new List<Customer>();
            for (int i = 0; i < potentialCustomers; i++)
            { // 1 - 1 on potential customers to weather score
                customers.Add(new Customer());
            }
            return customers;
        }

    }
}
