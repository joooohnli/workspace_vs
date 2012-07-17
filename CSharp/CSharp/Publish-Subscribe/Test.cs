using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Publish_Subscribe
{
    class Test
    {
        public static void Main()
        {
            Heater heater = new Heater(80);
            Cooler cooler = new Cooler(60);

            Thermostat thermostat = new Thermostat();
            thermostat.onTemperatureChange += heater.OnTemperatueChanged;
            thermostat.onTemperatureChange += cooler.OnTemperatureChanged;

            thermostat.CurrentTemperature = 70;

            Console.WriteLine("press enter to quit");
            Console.ReadLine();

            StopWatch stopWatch = new StopWatch();
        }
    }
}
