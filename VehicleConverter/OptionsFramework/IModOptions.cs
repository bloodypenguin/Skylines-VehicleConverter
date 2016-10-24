using System.Xml.Serialization;

namespace VehicleConverter.OptionsFramework
{
    public interface IModOptions
    {
        [XmlIgnore]
        string FileName
        {
            get;
        }
    }
}