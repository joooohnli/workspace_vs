using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Publish_Subscribe
{
    class Cooler
    {
        public Cooler(float temperature)
        {
            this.temperature = temperature;   
        }
        public void OnTemperatureChanged(object sender, TherEventArgs args)
        {
            //TODO
            Console.WriteLine("cooling");
            Console.WriteLine("sender:" + sender.ToString());
            Console.WriteLine("args:" + args.NewTemperature);
        }
        public float Temperature
        {
            get { return Temperature; }
            set { temperature = value; }
        }
        private float temperature;
    }
}
