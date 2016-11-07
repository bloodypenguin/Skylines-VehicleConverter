using System.Linq;
using System.Xml.Serialization;
using VehicleConverter.Config;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter
{
    public class Options : IModOptions
    {
        public Options()
        {
            ConvertTrainsToTrams = true;
            ConvertSubwayTrainsToMetros = true;
            ConvertSBahnsToMetros = true;
            ConvertTrainStationsToMetroStations = false;
        }

        [XmlElement("convert-tram-trains-to-trams")]
        [Checkbox("Convert tram-trains to Snowfall trams (Req. Snowfall DLC)")]
        public bool ConvertTrainsToTrams { set; get; }
        [XmlElement("convert-s-bahn-trains-to-metros")]
        [Checkbox("Convert S-Bahn trains to metros (Req. Metro Overhaul mod)")]
        public bool ConvertSBahnsToMetros { set; get; }
        [XmlElement("convert-subway-trains-to-metros")]
        [Checkbox("Convert subway trains to metros (Req. Metro Overhaul mod)")]
        public bool ConvertSubwayTrainsToMetros { set; get; }

        [XmlElement("convert-pantograph-trains-to-metros")]
        [Checkbox("Convert pantograph trains to metros (Req. Metro Overhaul mod)")]
        public bool ConvertPantographsToMetros { set; get; }

        [XmlElement("convert-train-stations-to-metro-stations")]
        [Checkbox("Convert some train stations to metro stations (Req. Metro Overhaul mod, conflicts with Building Themes cloning feature)")]
        public bool ConvertTrainStationsToMetroStations { set; get; }

        [XmlIgnore]
        public string FileName => "TrainConverter-Options.xml";
    }
}