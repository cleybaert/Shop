using System;
using System.Collections.Generic;
using System.Text;

namespace DaycareModel.Entities
{
    public class PickupEvent : LogEvent
    {
        public bool Pickup { get; set; }
        public Principal Principal { get; set; }
        public Child Child { get; set; }

        public override string ToString()
        {
            return $"Pickup at {TimeStamp.ToUniversalTime().ToLongTimeString()}";
        }
    }
}
