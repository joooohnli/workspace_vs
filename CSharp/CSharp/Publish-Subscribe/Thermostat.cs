using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Publish_Subscribe
{
    class Thermostat
    {
        public delegate void OnTemperatureChangeHandler(object sender, TherEventArgs therArgs);

        public event OnTemperatureChangeHandler onTemperatureChange;

        public float CurrentTemperature
        {
            get
            {
                return currentTemperature;
            }
            set
            {
                if (value != currentTemperature)
                {
                    currentTemperature = value;
                    if (onTemperatureChange != null)
                    {
                        onTemperatureChange(this, new TherEventArgs(value));
                    }
                }
            }
        }
        private float currentTemperature;
    }
}
