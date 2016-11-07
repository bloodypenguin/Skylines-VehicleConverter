using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using ColossalFramework.UI;
using ICities;
using UnityEngine;
using VehicleConverter.Config;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter
{
    public class Mod : IUserMod
    {
        public string Name => "Train Converter";
        public string Description => "Converts tram-trains and metro-trains to actual trams and trains, accordingly";

        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddOptionsGroup<Options>();
            try
            {
                OptionsWrapper<Config.Config>.Ensure();
            }
            catch (Exception e)
            {
                var display = new GameObject().AddComponent<ErrorMessageDisplay>();
                display.e = e;
            }
#if DEBUG
            UnityEngine.Debug.Log("Trains:");
            var trains = Trains.GetConvertedIds();
            Array.Sort(trains);
            UnityEngine.Debug.Log(trains.Aggregate("", (current, convertedId) => current + $"http://steamcommunity.com/sharedfiles/filedetails/?id={convertedId}\n"));
            UnityEngine.Debug.Log("Stations:");
            var stations = Stations.GetConvertedIds();
            Array.Sort(stations);
            UnityEngine.Debug.Log(stations.Aggregate("", (current, convertedId) => current + $"http://steamcommunity.com/sharedfiles/filedetails/?id={convertedId}\n"));
#endif
        }


        private class ErrorMessageDisplay : MonoBehaviour
        {
            public Exception e;

            public void Update()
            {
                var exceptionPanel = UIView.library?.ShowModal<ExceptionPanel>("ExceptionPanel");
                if (exceptionPanel == null)
                {
                    return;
                }
                exceptionPanel.SetMessage(
                "Malformed XML config",
                "There was an error reading Train Converter XML config:\n" + e.Message + "\n\nFalling back to default config...",
                true);
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
