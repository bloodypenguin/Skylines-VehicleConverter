using System.Xml.Serialization;
using VehicleConverter.OptionsFramework.Attibutes;

namespace VehicleConverter
{
    [Options("TrainConverter-Options")]
    public class Options
    {
        private const string MOM = "Trains to metro";
        private const string SNOWFALL = "Trains to trams - Require Snowfall DLC";

        public Options()
        {
            ConvertTrainsToTrams = true;
            ConvertSubwayTrainsToMetros = true;
            ConvertSBahnsToMetros = true;
            ConvertPantographsToMetros = false;
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

    }
}