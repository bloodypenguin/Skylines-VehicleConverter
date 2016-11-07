using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEngine;
using VehicleConverter.Config;

namespace VehicleConverter
{
    public static class TrainStationToMetroStation
    {

        private static readonly FieldInfo _uiCategoryfield = typeof(PrefabInfo).GetField("m_UICategory", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool Convert(BuildingInfo info)
        {
            UnityEngine.Debug.Log("Processing " + info.name);
            long id;
            if (!Util.TryGetWorkshoId(info, out id) || !Stations.GetConvertedIds(StationCategory.All).Contains(id))
            {
                return false;
            }
            UnityEngine.Debug.Log("Converting " + info.name);
            var metroEntrance = PrefabCollection<BuildingInfo>.FindLoaded("Metro Entrance");
            var ai = info.GetComponent<PlayerBuildingAI>();
            if (ai == null)
            {
                return false;
            }
            var isAlreadyAMetroStation = false;
            var stationAi = ai as TransportStationAI;
            if (stationAi != null)
            {
                if (stationAi.m_transportInfo == PrefabCollection<TransportInfo>.FindLoaded("Metro"))
                {
                    isAlreadyAMetroStation = true;
                }
                info.m_class = (ItemClass)ScriptableObject.CreateInstance(nameof(ItemClass));
                info.m_class.name = info.name;
                info.m_class.m_subService = ItemClass.SubService.PublicTransportMetro;
                info.m_class.m_service = ItemClass.Service.PublicTransport;
                stationAi.m_transportLineInfo = PrefabCollection<NetInfo>.FindLoaded("Metro Line");
                stationAi.m_transportInfo = PrefabCollection<TransportInfo>.FindLoaded("Metro");
                stationAi.m_maxVehicleCount = 0;
            }
            ai.m_createPassMilestone = metroEntrance.GetComponent<PlayerBuildingAI>().m_createPassMilestone;
            info.m_UnlockMilestone = metroEntrance.m_UnlockMilestone;
            _uiCategoryfield.SetValue(info, metroEntrance.category);

            if (info.m_paths == null || isAlreadyAMetroStation)
            {
                return true;
            }
            var metroTrack = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground"); //TODO(earalov): allow to use style
            var metroTrackElevated = PrefabCollection<NetInfo>.FindLoaded("Metro Track Elevated");
            var metroTrackSlope = PrefabCollection<NetInfo>.FindLoaded("Metro Track Slope");
            var metroTrackTunnel = PrefabCollection<NetInfo>.FindLoaded("Metro Track");
            var metroStationTrack = PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Ground");
            var metroStationTracElevated = PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Elevated");
            var metroStationTracSunken = PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Sunken");
            foreach (var path in info.m_paths)
            {
                if (path?.m_netInfo == null)
                {
                    continue;
                }
                if (metroTrackTunnel != null)
                {
                    if (path.m_netInfo.name.Contains("Train Track Tunnel"))
                    {
                        path.m_netInfo = metroTrackTunnel;
                        continue;
                    }
                }
                if (metroTrackElevated != null)
                {
                    if (path.m_netInfo.name.Contains("Train Track Elevated"))
                    {
                        path.m_netInfo = metroTrackElevated;
                        continue;
                    }
                }
                if (metroTrackSlope != null)
                {
                    if (path.m_netInfo.name.Contains("Train Track Slope"))
                    {
                        path.m_netInfo = metroTrackSlope;
                        continue;
                    }
                }
                if (metroStationTracElevated != null)
                {
                    if (path.m_netInfo.name.Contains("Station Track Eleva"))
                    {
                        path.m_netInfo = metroStationTracElevated;
                        continue;
                    }
                }
                if (metroStationTracSunken != null)
                {
                    if (path.m_netInfo.name.Contains("Station Track Sunken"))
                    {
                        path.m_netInfo = metroStationTracSunken;
                        continue;
                    }
                }
                if (metroStationTrack != null)
                {
                    if (path.m_netInfo.name.Contains("Train Station Track"))
                    {
                        path.m_netInfo = metroStationTrack;
                        continue;
                    }
                }
                if (metroTrack != null)
                {
                    if (path.m_netInfo.name.Contains("Train Track"))
                    {
                        path.m_netInfo = metroTrack;
                        continue;
                    }
                }

                //TODO(earalov): add more More Tracks and ETST tracks ?
            }
            return true;
        }
    }
}