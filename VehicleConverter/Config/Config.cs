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
            Underground = new TrainItems(Trains.GetItems(Category.Underground).ToList());
            SBahn = new TrainItems(Trains.GetItems(Category.SBahn).ToList());
            Trams = new TrainItems(Trains.GetItems(Category.Tram).ToList());
            Pantograph = new TrainItems(Trains.GetItems(Category.Pantograph).ToList());
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

        [XmlIgnore]
        public string FileName => "CSL-TrainConverter-Config.xml";
    }
}
