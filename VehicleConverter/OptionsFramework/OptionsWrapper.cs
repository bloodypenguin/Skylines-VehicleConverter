using System;
using System.IO;
using System.Xml.Serialization;
using ColossalFramework.IO;
using UnityEngine;

namespace VehicleConverter.OptionsFramework
{
    public class OptionsWrapper<T> where T : IModOptions
    {
        private static T _instance;

        public static T Options
        {
            get
            {
                try
                {
                    Ensure();
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogError("Error reading options XML file");
                    UnityEngine.Debug.LogException(e);
                }
                return _instance;
            }
        }

        public static void Ensure()
        {
            if (_instance != null)
            {
                return;
            }
            _instance = (T)Activator.CreateInstance(typeof(T));
            LoadOptions();
        }

        private static void LoadOptions()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var fileName = Path.Combine(DataLocation.localApplicationData, _instance.FileName);
                if (!fileName.EndsWith(".xml"))
                {
                    fileName = fileName + ".xml";
                }
                using (var streamReader = new StreamReader(fileName))
                {
                    var options = (T)xmlSerializer.Deserialize(streamReader);
                    foreach (var propertyInfo in typeof(T).GetProperties())
                    {
                        if (!propertyInfo.CanWrite)
                        {
                            continue;
                        }
                        var value = propertyInfo.GetValue(options, null);
                        propertyInfo.SetValue(_instance, value, null);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                SaveOptions();// No options file yet
            }
        }

        internal static void SaveOptions()
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var fileName = Path.Combine(DataLocation.localApplicationData, _instance.FileName);
                if (!fileName.EndsWith(".xml"))
                {
                    fileName = fileName + ".xml";
                }
                using (var streamWriter = new StreamWriter(fileName))
                {
                    xmlSerializer.Serialize(streamWriter, _instance);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}