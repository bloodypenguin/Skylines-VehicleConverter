using System.Xml.Serialization;
using MetroStationConverter.OptionsFramework.Attibutes;

namespace MetroStationConverter
{
    [Options("MetroStationConverter-Options")]
    public class Options
    {
        private const string STATIONS = "Train Stations to metro stations";

        public Options()
        {
            ConvertModernStationsToMetroStations = true;
            ConvertOldStationsToMetroStations = true;
            ConvertTramStationsToMetroStations = true;
        }

        [XmlElement("convert-modern-train-stations-to-metro-stations")]
        [Checkbox("Convert some Modern Style stations to metro stations", null, null, STATIONS)]
        public bool ConvertModernStationsToMetroStations { set; get; }
        [XmlElement("convert-old-train-stations-to-metro-stations")]
        [Checkbox("Convert some Old Style stations to metro stations", null, null, STATIONS)]
        public bool ConvertOldStationsToMetroStations { set; get; }
        [XmlElement("convert-tram-train-stations-to-metro-stations")]
        [Checkbox("Convert some 'tram' (pre-Snowfall) stations to metro stations", null, null, STATIONS)]
        public bool ConvertTramStationsToMetroStations { set; get; }
    }
}