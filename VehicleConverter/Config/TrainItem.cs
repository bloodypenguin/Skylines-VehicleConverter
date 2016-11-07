using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace VehicleConverter.Config
{
    [Serializable]
    public class TrainItem
    {
        public TrainItem()
        {
            Exclude = false;
            WorkshopId = -1;
            ReplaceLastTrailerWithEngine = false;
            TakeTrailers = null;
            Description = string.Empty;
        }

        public TrainItem(long workshoId, string description, bool replaceLastTrailerWithEngine = false)
        {
            Exclude = false;
            Description = description;
            WorkshopId = workshoId;
            ReplaceLastTrailerWithEngine = replaceLastTrailerWithEngine;
            TakeTrailers = null;
        }

        [XmlAttribute("workshop-id")]
        public long WorkshopId { get; private set; }
        [XmlAttribute("description")]
        public string Description { get; private set; }
        [XmlAttribute("replace-last-with-trailer"), DefaultValue(false)]
        public bool ReplaceLastTrailerWithEngine { get; private set; }
        [XmlElement("take-trailers"), DefaultValue(null)]
        public List<int> TakeTrailers { get; private set; }
        [XmlAttribute("exclude"), DefaultValue(false)]
        public bool Exclude { get; private set; }
    }
}