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

        // Constructor
        public Day()
        {
            weather = new Weather();
            customers = GetCustomers();
        }

        // Member methods
        public List<Customer> GetCustomers()
        {
            double currentTemp = weather.temperature;
            string currentSky = weather.sky;
            double minimumCustomers = 50;
            double currentSkyValue = 0;
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
            int potentialCustomers = Convert.ToInt32(minimumCustomers + (currentTemp / 4) + currentSkyValue);
            customers = new List<Customer>();
            for (int i = 0; i < potentialCustomers; i++)
            {
                customers.Add(new Customer());
            }
            return customers;
        }

    }
}
