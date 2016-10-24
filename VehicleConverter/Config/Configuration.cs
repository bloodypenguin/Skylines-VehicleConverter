using System;
using System.Collections.Generic;

namespace VehicleConverter.Config
{
    [Serializable]
    public class Configuration
    {
        public int Version { get; set; }
        public IEnumerable<TrainItem> Underground { get; set; }
        public IEnumerable<TrainItem> SBahn { get; set; }
        public IEnumerable<TrainItem> Trams { get; set; }
        public IEnumerable<TrainItem> Pantograph { get; set; }
    }
}