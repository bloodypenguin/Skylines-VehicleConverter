using System.Linq;
using System.Xml.Serialization;
using VehicleConverter.Config;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter
{
    public class Options : IModOptions
    {
        private const string MOM = "Trains - Require Metro Overhaul Mod (MOM)";
        private const string SNOWFALL = "Trams - Require Snowfall DLC";
        private const string STATIONS = "Stations - Require Metro Overhaul Mod (MOM)";

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
        [Checkbox("Convert S-Bahn trains to metros", null, null, MOM)]
        public bool ConvertSBahnsToMetros { set; get; }


        [XmlElement("convert-pantograph-trains-to-metros")]
        [Checkbox("Convert pantograph trains to metros", null, null, MOM)]
        public bool ConvertPantographsToMetros { set; get; }

        [XmlElement("convert-tram-trains-to-trams")]
        [Checkbox("Convert tram-trains to Snowfall trams", null, null, SNOWFALL)]
        public bool ConvertTrainsToTrams { set; get; }

        [XmlElement("convert-modern-train-stations-to-metro-stations")]
        [Checkbox("Convert some Modern Style train stations to metro stations", null, null, STATIONS)]
        public bool ConvertModernStationsToMetroStations { set; get; }
        [XmlElement("convert-old-train-stations-to-metro-stations")]
        [Checkbox("Convert some Old Style train stations to metro stations", null, null, STATIONS)]
        public bool ConvertOldStationsToMetroStations { set; get; }
        [XmlElement("convert-tram-train-stations-to-metro-stations")]
        [Checkbox("Convert some 'tram' train stations to metro stations", null, null, STATIONS)]
        public bool ConvertTramStationsToMetroStations { set; get; }

        [XmlIgnore]
        public string FileName => "TrainConverter-Options.xml";
    }
}