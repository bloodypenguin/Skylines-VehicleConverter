using System;
using System.Collections.Generic;
using System.Xml;
using ColossalFramework.UI;
using ICities;
using UnityEngine;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter
{
    public class Mod : IUserMod
    {
        public string Name => "Train Converter";
        public string Description => "Converts tram-trains and metro-trains to actual trams and trains, accordingly";

        public void OnSettingsUI(UIHelperBase helper)
        {
            var components = helper.AddOptionsGroup<Options>();
            foreach (var component in components)
            {
                var checkBox = component as UICheckBox;
                if (checkBox != null && checkBox.label.text.Contains("tram"))
                {
                    checkBox.eventVisibilityChanged += (c, v) =>
                    {
                        c.enabled = Util.DLC(SteamHelper.kWinterDLCAppID);
                    };
                }
            }
            try
            {
                OptionsWrapper<Config.Config>.Ensure();
            }
            catch (Exception e)
            {
                var display = new GameObject().AddComponent<ErrorMessageDisplay>();
                display.e = e;
            }

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
