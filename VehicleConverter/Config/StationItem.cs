using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace VehicleConverter.Config
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
            ParialConversion = "";
            ParialConversionSpawnPoints = "";
            ToHub = false;
            BarsType = BarsType.Regular;
        }

        public StationItem(long workshoId, string description, bool toDecoration = false)
        {
            Exclude = false;
            Description = description;
            WorkshopId = workshoId;
            ToDecoration = toDecoration;
            ParialConversion = "";
            ParialConversionSpawnPoints = "";
            ToHub = false;
            BarsType = BarsType.Regular;
        }

        [XmlAttribute("workshop-id")]
        public long WorkshopId { get; private set; }
        [XmlAttribute("description")]
        public string Description { get; private set; }
        [XmlAttribute("to-decoration"), DefaultValue(false)]
        public bool ToDecoration { get; private set; }
        [XmlAttribute("exclude"), DefaultValue(false)]
        public bool Exclude { get; private set; }
        [XmlAttribute("bars-type"), DefaultValue(BarsType.Regular)]
        public BarsType BarsType { get; private set; }
        [XmlAttribute("to-hub"), DefaultValue(false)]
        public bool ToHub { get; private set; }
        [XmlAttribute("hub-metro-paths-indices"), DefaultValue("")]
        public string ParialConversion { get; private set; }
        [XmlAttribute("hub-metro-spawn-points-indices"), DefaultValue("")]
        public string ParialConversionSpawnPoints { get; private set; }
    }
}