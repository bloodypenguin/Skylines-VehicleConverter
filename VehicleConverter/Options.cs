using System.Xml.Serialization;
using VehicleConverter.OptionsFramework.Attibutes;

namespace VehicleConverter
{
    [Options("TrainConverter-Options")]
    public class Options
    {
        private const string MOM = "Trains to metro - Require Metro Overhaul Mod (MOM)";
        private const string SNOWFALL = "Trains to trams - Require Snowfall DLC";
        private const string STATIONS = "Train Stations to metro stations - Require Metro Overhaul Mod (MOM)";

        public Options()
        {
            ConvertTrainsToTrams = true;
            ConvertSubwayTrainsToMetros = true;
            ConvertSBahnsToMetros = false;
            ConvertPantographsToMetros = false;
            ConvertModernStationsToMetroStations = true;
            ConvertOldStationsToMetroStations = true;
            ConvertTramStationsToMetroStations = false;
        }

        [XmlElement("convert-subway-trains-to-metros")]
        [Checkbox("Convert subway trains to metros", null, null, MOM)]
        public bool ConvertSubwayTrainsToMetros { set; get; }

        [XmlElement("convert-s-bahn-trains-to-metros")]
        [Checkbox("Convert S-Bahn/Overground trains to metros", null, null, MOM)]
        public bool ConvertSBahnsToMetros { set; get; }


        [XmlElement("convert-pantograph-trains-to-metros")]
        [Checkbox("Convert pantograph trains to metros", null, null, MOM)]
        public bool ConvertPantographsToMetros { set; get; }

        [XmlElement("convert-tram-trains-to-trams")]
        [Checkbox("Convert tram-trains to Snowfall trams", null, null, SNOWFALL)]
        public bool ConvertTrainsToTrams { set; get; }

        [XmlElement("convert-modern-train-stations-to-metro-stations")]
        [Checkbox("Convert some Modern Style stations to metro stations", null, null, STATIONS)]
        public bool ConvertModernStationsToMetroStations { set; get; }
        [XmlElement("convert-old-train-stations-to-metro-stations")]
        [Checkbox("Convert some Old Style stations to metro stations (Steel style used if enabled)", null, null, STATIONS)]
        public bool ConvertOldStationsToMetroStations { set; get; }
        [XmlElement("convert-tram-train-stations-to-metro-stations")]
        [Checkbox("Convert some 'tram' stations to metro stations", null, null, STATIONS)]
        public bool ConvertTramStationsToMetroStations { set; get; }
    }
}