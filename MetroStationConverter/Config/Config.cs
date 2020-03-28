using System.Linq;
using System.Xml.Serialization;
using MetroStationConverter.OptionsFramework.Attibutes;

namespace MetroStationConverter.Config
{
    [Options("MetroStationConverter-Config")]
    public class Config
    {
        public Config()
        {
            TramStations = new StationItems(Stations.GetItems(StationCategory.Tram).OrderBy(i => i.WorkshopId).ToList());
            OldStations = new StationItems(Stations.GetItems(StationCategory.Old).OrderBy(i => i.WorkshopId).ToList());
            ModernStations = new StationItems(Stations.GetItems(StationCategory.Modern).OrderBy(i => i.WorkshopId).ToList());
        }

        [XmlElement("version")]
        public int Version { get; set; }
        [XmlElement("underground-trains-to-metro")]
        public StationItems TramStations { get; private set; }
        [XmlElement("old-stations-to-metro-station")]
        public StationItems OldStations { get; private set; }
        [XmlElement("modern-stations-to-metro-station")]
        public StationItems ModernStations { get; private set; }
    }
}
