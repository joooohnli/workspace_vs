using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Publish_Subscribe
{
    class Heater
    {
        private float temperature;
        public Heater(float temperature)
        {
            this.temperature = temperature;
        }
        public void OnTemperatueChanged(object sender, TherEventArgs args)
        {
            //TODO
            Console.WriteLine("heating");
        }
        public float Temperature
        {
            get {return Temperature; }
            set {temperature = value; }
        }
    }
}
