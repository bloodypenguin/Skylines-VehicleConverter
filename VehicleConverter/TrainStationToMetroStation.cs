using System;
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
            long id;
            if (!Util.TryGetWorkshopId(info, out id) || !Stations.GetConvertedIds(StationCategory.All).Contains(id))
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
            var stationAi = ai as TransportStationAI;
            if (stationAi != null)
            {
                var item = Stations.GetItem(id);
                if (stationAi.m_transportInfo == PrefabCollection<TransportInfo>.FindLoaded("Metro"))
                {
                    return true; //already a metro station
                }
                if (item == null)
                {
                    UnityEngine.Debug.LogWarning("Configuration for station " + id + " not found!");
                    return false;
                }
                if (!item.ToHub)
                {
                    info.m_class = (ItemClass) ScriptableObject.CreateInstance(nameof(ItemClass));
                    info.m_class.name = info.name;
                    info.m_class.m_subService = ItemClass.SubService.PublicTransportMetro;
                    info.m_class.m_service = ItemClass.Service.PublicTransport;
                    stationAi.m_transportLineInfo = PrefabCollection<NetInfo>.FindLoaded("Metro Line");
                    stationAi.m_transportInfo = PrefabCollection<TransportInfo>.FindLoaded("Metro");
                    stationAi.m_maxVehicleCount = 0;
                }
                else if (stationAi.m_secondaryTransportInfo != null)
                {
                    UnityEngine.Debug.LogWarning("Station " + id + " already has secondary transport info!");
                    return false;
                }
                stationAi.m_secondaryTransportInfo = PrefabCollection<TransportInfo>.FindLoaded("Metro");
                stationAi.m_maxVehicleCount2 = 0;
                var spawnPoints = Util.CommaSeparatedStringToIntArray(item.ParialConversionSpawnPoints);
                if (stationAi.m_spawnPoints != null)
                {
                    var spawn1 = new ArrayList();
                    var spawn2 = new ArrayList();
                    for (var i = 0; i < stationAi.m_spawnPoints.Length; i++)
                    {
                        if (spawnPoints.Contains(i))
                        {
                            spawn2.Add(stationAi.m_spawnPoints[i]);
                        }
                        else
                        {
                            spawn1.Add(stationAi.m_spawnPoints[i]);
                        }
                    }
                    stationAi.m_spawnPoints = (DepotAI.SpawnPoint[])spawn1.ToArray(typeof(DepotAI.SpawnPoint));
                    stationAi.m_spawnPoints2 = (DepotAI.SpawnPoint[])spawn2.ToArray(typeof(DepotAI.SpawnPoint));
                }

            }

            if (Stations.ToDecoration(id))
            {
                GameObject.Destroy(ai);
                var newAi = info.gameObject.AddComponent<DecorationBuildingAI>();
                info.m_buildingAI = newAi;
                newAi.m_info = info;
                newAi.m_allowOverlap = true;
                info.m_placementMode = BuildingInfo.PlacementMode.OnGround;
            }
            else
            {
                ai.m_createPassMilestone = metroEntrance.GetComponent<PlayerBuildingAI>().m_createPassMilestone;
            }
            _uiCategoryfield.SetValue(info, metroEntrance.category);
            info.m_UnlockMilestone = metroEntrance.m_UnlockMilestone;


            if (info.m_paths == null)
            {
                return true;
            }
            var nameConverter = Stations.GetCategory(id) == StationCategory.Old ? new Func<string, string>(s => "Steel " + s) : (s => s);
            var metroTrack = PrefabCollection<NetInfo>.FindLoaded(nameConverter.Invoke("Metro Track Ground")) ?? PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground");
            var metroTrackElevated = PrefabCollection<NetInfo>.FindLoaded(nameConverter.Invoke("Metro Track Elevated")) ?? PrefabCollection<NetInfo>.FindLoaded("Metro Track Elevated");
            var metroTrackSlope = PrefabCollection<NetInfo>.FindLoaded(nameConverter.Invoke("Metro Track Slope")) ?? PrefabCollection<NetInfo>.FindLoaded("Metro Track Slope");
            var metroTrackTunnel = PrefabCollection<NetInfo>.FindLoaded(nameConverter.Invoke("Metro Track")) ?? PrefabCollection<NetInfo>.FindLoaded("Metro Track");
            var metroStationTrack = PrefabCollection<NetInfo>.FindLoaded(nameConverter.Invoke("Metro Station Track Ground")) ?? PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Ground");
            var metroStationTracElevated = PrefabCollection<NetInfo>.FindLoaded(nameConverter.Invoke("Metro Station Track Elevated")) ?? PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Elevated");
            var metroStationTracSunken = PrefabCollection<NetInfo>.FindLoaded(nameConverter.Invoke("Metro Station Track Sunken")) ?? PrefabCollection<NetInfo>.FindLoaded("Metro Station Track Sunken");
            var item2 = Stations.GetItem(id);
            var hubPathIndices = Util.CommaSeparatedStringToIntArray(item2.ParialConversion);
            for (var i = 0; i < info.m_paths.Length; i++)
            {
                var path = info.m_paths[i];
                if (path?.m_netInfo?.name == null || path.m_netInfo.m_class?.m_subService !=ItemClass.SubService.PublicTransportTrain)
                {
                    continue;
                }
                if (item2.ToHub)
                {
                    if (!hubPathIndices.Contains(i))
                    {
                        continue;
                    }
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