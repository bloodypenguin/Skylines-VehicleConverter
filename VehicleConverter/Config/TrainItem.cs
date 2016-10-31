using System;
using System.Collections.Generic;

namespace VehicleConverter.Config
{
    [Serializable]
    public class TrainItem
    {
        public long Convert { get; set; }
        public long WorkshopId { get; set; }
        public string Description { get; set; }
        public bool ReplaceLastTrailerWithEngine { get; set; }
        public IEnumerable<int> TakeTrailers { get; set; }
    }
}