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
            Underground = new TrainItems(Trains.GetItems(TrainCategory.Underground).OrderBy(i => i.WorkshopId).ToList());
            SBahn = new TrainItems(Trains.GetItems(TrainCategory.SBahn).OrderBy(i => i.WorkshopId).ToList());
            Trams = new TrainItems(Trains.GetItems(TrainCategory.Tram).OrderBy(i => i.WorkshopId).ToList());
            Pantograph = new TrainItems(Trains.GetItems(TrainCategory.Pantograph).OrderBy(i => i.WorkshopId).ToList());

            TramStations = new StationItems(Stations.GetItems(StationCategory.Tram).OrderBy(i => i.WorkshopId).ToList());
            OldStations = new StationItems(Stations.GetItems(StationCategory.Old).OrderBy(i => i.WorkshopId).ToList());
            ModernStations = new StationItems(Stations.GetItems(StationCategory.Modern).OrderBy(i => i.WorkshopId).ToList());
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
