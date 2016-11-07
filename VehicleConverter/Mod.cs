using System;
using System.Collections.Generic;
using ColossalFramework.UI;
using ICities;
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
            OptionsWrapper<Config.Config>.Ensure();
        }
    }
}
