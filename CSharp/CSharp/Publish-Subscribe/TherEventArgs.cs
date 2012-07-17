using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Publish_Subscribe
{
    class TherEventArgs : System.EventArgs
    {
        public TherEventArgs(float newTemperature)
        {
            this.newTemperature = newTemperature;
        }
        public float NewTemperature
        {
            set { newTemperature = value; }
            get { return newTemperature; }
        }
        private float newTemperature;
    }
}
