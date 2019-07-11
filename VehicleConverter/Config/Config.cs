using System.Linq;
using System.Xml.Serialization;
using VehicleConverter.OptionsFramework.Attibutes;

namespace VehicleConverter.Config
{
    [Options("TrainConverter-Config")]
    public class Config
    {
        public Config()
        {
            Underground = new TrainItems(Trains.GetItems(TrainCategory.Underground).OrderBy(i => i.WorkshopId).ToList());
            SBahn = new TrainItems(Trains.GetItems(TrainCategory.SBahn).OrderBy(i => i.WorkshopId).ToList());
            Trams = new TrainItems(Trains.GetItems(TrainCategory.Tram).OrderBy(i => i.WorkshopId).ToList());
            Pantograph = new TrainItems(Trains.GetItems(TrainCategory.Pantograph).OrderBy(i => i.WorkshopId).ToList());
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
    }
}
