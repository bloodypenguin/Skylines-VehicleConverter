using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using ColossalFramework.PlatformServices;
using MetroStationConverter.Config;
using UnityEngine;

namespace MetroStationConverter
{
    public static class TrainStationToMetroStation
    {
        private static readonly FieldInfo _uiCategoryfield =
            typeof(PrefabInfo).GetField("m_UICategory", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool Convert(BuildingInfo info)
        {
            long id;
            if (!Util.TryGetWorkshopId(info, out id) || !Stations.GetConvertedIds(StationCategory.All).Contains(id))
            {
                return false;
            }

            UnityEngine.Debug.Log("Metro Station Converter: Converting " + info.name);
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
                    UnityEngine.Debug.LogWarning("Metro Station Converter: " + id + ": already a metro station, no conversion applied.");
                    return true; //already a metro station
                }

                if (item == null)
                {
                    UnityEngine.Debug.LogWarning("Metro Station Converter: Configuration for station " + id + " not found!");
                    return false;
                }

                if (item.ToHub)
                {
                    if (stationAi.m_secondaryTransportInfo != null)
                    {
                        UnityEngine.Debug.LogWarning("Station " + id + " already has secondary transport info!");
                        return false;
                    }

                    stationAi.m_secondaryTransportInfo = PrefabCollection<TransportInfo>.FindLoaded("Metro");
                    var spawnPoints = Util.CommaSeparatedStringToIntArray(item.PartialConversionSpawnPoints);
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

                        stationAi.m_spawnPoints = (DepotAI.SpawnPoint[]) spawn1.ToArray(typeof(DepotAI.SpawnPoint));
                        stationAi.m_spawnPoints2 = (DepotAI.SpawnPoint[]) spawn2.ToArray(typeof(DepotAI.SpawnPoint));
                    }
                }
                else
                {
                    info.m_class = (ItemClass) ScriptableObject.CreateInstance(nameof(ItemClass));
                    info.m_class.name = info.name;
                    info.m_class.m_subService = ItemClass.SubService.PublicTransportMetro;
                    info.m_class.m_service = ItemClass.Service.PublicTransport;
                    stationAi.m_transportLineInfo = PrefabCollection<NetInfo>.FindLoaded("Metro Line");
                    stationAi.m_transportInfo = PrefabCollection<TransportInfo>.FindLoaded("Metro");
                }
            }

            var item2 = Stations.GetItem(id);
            if (item2.ToDecoration)
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

            var metroTrack = FindMetroTrack("Metro Track Ground 01");
            var metroTrackElevated = FindMetroTrack("Metro Track Elevated 01");
            var metroTrackSlope = FindMetroTrack("Metro Track Slope 01");
            var metroTrackTunnel = FindMetroTrack("Metro Track");

            var metroStationTrack = FindMetroTrack("Metro Station Track Ground 01");
            var metroStationTrackElevated = FindMetroTrack("Metro Station Track Elevated 01");
            var metroStationTrackTunnel = FindMetroTrack("Metro Station Track");

            var hubPathIndices = Util.CommaSeparatedStringToIntArray(item2.PartialConversion);
            for (var i = 0; i < info.m_paths.Length; i++)
            {
                var path = info.m_paths[i];
                if (path?.m_netInfo?.name == null ||
                    path.m_netInfo.m_class?.m_subService != ItemClass.SubService.PublicTransportTrain)
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

                if (path.m_netInfo.name.Contains("Train Track Tunnel"))
                {
                    path.m_netInfo = metroTrackTunnel;
                    continue;
                }

                if (path.m_netInfo.name.Contains("Train Track Elevated"))
                {
                    path.m_netInfo = metroTrackElevated;
                    continue;
                }

                if (path.m_netInfo.name.Contains("Train Track Slope"))
                {
                    path.m_netInfo = metroTrackSlope;
                    continue;
                }
                
                if (path.m_netInfo.name.Contains("Train Station Track Tunnel"))
                {
                    path.m_netInfo = metroStationTrackTunnel;
                    continue;
                }

                if (!path.m_netInfo.name.Contains("Metro") && path.m_netInfo.name.Contains("Station Track Eleva"))
                {
                    path.m_netInfo = metroStationTrackElevated;
                    continue;
                }

                if (path.m_netInfo.name.Contains("Train Station Track"))
                {
                    path.m_netInfo = metroStationTrack;
                    continue;
                }

                if (path.m_netInfo.name.Contains("Train Track"))
                {
                    path.m_netInfo = metroTrack;
                    continue;
                }
              
                //TODO(earalov): add more More Tracks and ETST tracks ?
            }

            return true;
        }

        private static NetInfo FindMetroTrack(string trackName)
        {
            var result = PrefabCollection<NetInfo>.FindLoaded(trackName);
            if (result == null)
            {
                throw new Exception($"Metro Station Converter didn't find asset {trackName}.");
            }
            return result;
        }
    }
}