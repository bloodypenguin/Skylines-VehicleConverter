using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MetroStationConverter.Config
{
    [Serializable]
    public class StationItem
    {
        public StationItem()
        {
            Exclude = false;
            WorkshopId = -1;
            Description = string.Empty;
            ToDecoration = false;
            PartialConversion = "";
            PartialConversionSpawnPoints = "";
            ToHub = false;
        }

        public StationItem(long workshoId, string description, bool toDecoration = false)
        {
            Exclude = false;
            Description = description;
            WorkshopId = workshoId;
            ToDecoration = toDecoration;
            PartialConversion = "";
            PartialConversionSpawnPoints = "";
            ToHub = false;
        }

        [XmlAttribute("workshop-id")]
        public long WorkshopId { get; private set; }
        [XmlAttribute("description")]
        public string Description { get; private set; }
        [XmlAttribute("to-decoration"), DefaultValue(false)]
        public bool ToDecoration { get; private set; }
        [XmlAttribute("exclude"), DefaultValue(false)]
        public bool Exclude { get; private set; }
        [XmlAttribute("to-hub"), DefaultValue(false)]
        public bool ToHub { get; private set; }
        [XmlAttribute("hub-metro-paths-indices"), DefaultValue("")]
        public string PartialConversion { get; private set; }
        [XmlAttribute("hub-metro-spawn-points-indices"), DefaultValue("")]
        public string PartialConversionSpawnPoints { get; private set; }
    }
}