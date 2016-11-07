using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VehicleConverter.Config
{
    [Serializable]
    public class TrainItems
    {
        public TrainItems()
        {
            this.Items = new List<TrainItem>();
        }

        public TrainItems(List<TrainItem> items)
        {
            this.Items = items;
        }

        [XmlElement("items")]
        public List<TrainItem> Items { get; private set; }
    }
}
