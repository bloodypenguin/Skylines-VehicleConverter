using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ColossalFramework;
using ColossalFramework.PlatformServices;
using ColossalFramework.Plugins;
using ColossalFramework.UI;
using ICities;
using UnityEngine;

namespace VehicleConverter
{
    public static class Util
    {
        public static bool DLC(uint id)
        {
            if ((int) id == 1)
                return new SavedBool(Settings.pdxLoginUsed, Settings.userGameState, false).value;
            return PlatformService.IsDlcInstalled(id);
        }


        public static bool TryGetWorkshopId(PrefabInfo info, out long workshopId)
        {
            workshopId = -1;
            if (info?.name == null)
            {
                return false;
            }
            if (!info.name.Contains(".")) //only for custom prefabs
            {
                return false;
            }
            var idStr = info.name.Split('.')[0];
            return long.TryParse(idStr, out workshopId);
        }
        
        public static bool IsModActive(string modName)
        {
            var plugins = PluginManager.instance.GetPluginsInfo();
            return (from plugin in plugins.Where(p => p.isEnabled)
                select plugin.GetInstances<IUserMod>()
                into instances
                where instances.Any()
                select instances[0].Name
                into name
                where name == modName
                select name).Any();
        }
    }
}