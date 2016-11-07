using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter.Config
{
    public class Config : IModOptions
    {
        public Config()
        {
            Underground = new TrainItems(Trains.GetItems(TrainCategory.Underground).ToList());
            SBahn = new TrainItems(Trains.GetItems(TrainCategory.SBahn).ToList());
            Trams = new TrainItems(Trains.GetItems(TrainCategory.Tram).ToList());
            Pantograph = new TrainItems(Trains.GetItems(TrainCategory.Pantograph).ToList());

            TramStations = new StationItems(Stations.GetItems(StationCategory.Tram).ToList());
            OldStations = new StationItems(Stations.GetItems(StationCategory.Old).ToList());
            ModernStations = new StationItems(Stations.GetItems(StationCategory.Modern).ToList());
        }

        [XmlElement("version")]
        public int Version { get; set; }
        [XmlElement("underground-trains-to-metro")]
        public TrainItems Underground { get; private set; }
        [XmlElement("s-bahn-trains-to-metro")]
        public TrainItems SBahn { get; private set; }
        [XmlElement("pantograph-trains-to-metro")]
        public TrainItems Pantograph { get; private set; }
        [XmlElement("tram-trains-to-tram")]
        public TrainItems Trams { get; private set; }
        [XmlElement("tram-train-stations-to-metro-station")]
        public StationItems TramStations { get; private set; }
        [XmlElement("old-stations-to-metro-station")]
        public StationItems OldStations { get; private set; }
        [XmlElement("modern-stations-to-metro-station")]
        public StationItems ModernStations { get; private set; }

        [XmlIgnore]
        public string FileName => "CSL-TrainConverter-Config.xml";
    }
}
