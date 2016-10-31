using System.Xml.Serialization;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter
{
    public class Options : IModOptions
    {
        public Options()
        {
            convertTrainsToTrams = true;
            convertTrainsToMetros = true;
            convertSBahnsToMetros = true;
//            convertTrainStationsToMetroStations = false;
        }

        [Checkbox("Convert tram-trains to trams (Req. Snowfall DLC)")]
        public bool convertTrainsToTrams { set; get; }
        [Checkbox("Convert S-Bahns to metros (Req. Metro Overhaul mod)")]
        public bool convertSBahnsToMetros { set; get; }
        [Checkbox("Convert metro-trains to metros (Req. Metro Overhaul mod)")]
        public bool convertTrainsToMetros { set; get; }
//        [Checkbox("Convert metro-train stations to metro stations (Not implemented yet)")]
//        public bool convertTrainStationsToMetroStations { set; get; }

        [XmlIgnore]
        public string FileName => "CSL-VehicleConverter.xml";
    }
}