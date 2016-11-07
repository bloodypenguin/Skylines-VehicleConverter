using System.Linq;
using System.Xml.Serialization;
using VehicleConverter.Config;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter
{
    public class Options : IModOptions
    {
        private const string MOM = "Require Metro Overhaul Mod (MOM)";
        private const string SNOWFALL = "Require Snowfall DLC";

        public Options()
        {
            ConvertTrainsToTrams = true;
            ConvertSubwayTrainsToMetros = true;
            ConvertSBahnsToMetros = false;
            ConvertPantographsToMetros = false;
            ConvertTrainStationsToMetroStations = false;
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

        [XmlElement("convert-train-stations-to-metro-stations")]
        [Checkbox("Convert tram-train stations to metro stations (conflicts with Building Themes if BT cloning enabled!)", null, null, MOM)]
        public bool ConvertTrainStationsToMetroStations { set; get; }

        [XmlIgnore]
        public string FileName => "TrainConverter-Options.xml";
    }
}