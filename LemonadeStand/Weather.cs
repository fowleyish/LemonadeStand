﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LemonadeStand
{
    class Weather
    {
        // Member variables
        public string sky;
        public int temperature;
        public List<string> weatherConditions;

        // Constructor
        public Weather()
        {
            temperature = GetTemp();
            weatherConditions = new List<string>
            {
                "clear",
                "clear",
                "clear",
                "clear",
                "cloudy",
                "cloudy",
                "cloudy",
                "overcast",
                "overcast",
                "raining"
            };
            sky = GetCondition();
        }

        // Member methods

        // Get random temp
        public int GetTemp()
        {
            Random r = new Random();
            return r.Next(55, 100);
        }

        public string GetCondition()
        {
            Random r = new Random();
            return weatherConditions[r.Next(1, 10)];
        }
    }

    
}
