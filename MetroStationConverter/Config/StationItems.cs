using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MetroStationConverter.Config
{
    [Serializable]
    public class StationItems
    {
        public StationItems()
        {
            this.Items = new List<StationItem>();
        }

        public StationItems(List<StationItem> items)
        {
            this.Items = items;
        }

        [XmlElement("items")]
        public List<StationItem> Items { get; private set; }
    }
}
