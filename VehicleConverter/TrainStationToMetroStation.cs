using System.Collections;
using System.Reflection;
using System.Security.AccessControl;
using UnityEngine;

namespace VehicleConverter
{
    public static class TrainStationToMetroStation
    {
        private static readonly long[] Ids = {

        587989905, //[XIRI] Advanced Tram Station (Remove TRAM prop)
        541850201, //Tram Station
        542504491, //Tram Station 2
        542877830, //Antwerp Large Station 02
        542877989, //[TRAM] Antwerp Large Station 01
        571249327, //FancyTrack B
        571248983, //FancyTrack A
        542877628, //[TRAM] Antwerp Large track 01
        542877135, //[TRAM] Antwerp Large track 04
        542877338, //[TRAM] Antwerp Large track 03
        542877508, //[TRAM] Antwerp Large track 02
        544693280, //[XIRI] LTN Station [In-Avenue Station]

        723742558, //Joak's 4-Track Train Station
        720837956, //EDSA MRT3 Philippines
        433435357, //Modern Train Station
        701048320, //train station Thorildsplan
        618580477, //City Station
        658612506, //2-Track Elevated Station With Pedestrian deck
        564051384, //2-Track Elevated Station
        532551655, //4-TracksElevatedStation Plain
        532551461, //4-Tracks Elevated Station
        529560650, //Urban Elevated Station NoAD
        527697251, //Urban Elevated Station
        524975362, //Medium Elevated Station
        522406139, //Industrial Elevated Station
        532099566, //Elevated Double Track Train Station
        665292636, //Skytrain station


        550104018, //NYC_Elevated Stacked Train Station
        552914350, //NYC Elevated Station Over Road 2

        //Old German
        519519752, //Elevated Train Stop (Read Description pls)
        665774022, //Single Brick Station with central platform
        665788204, //Double Brick Station with central platforms
        670379488, //Single Concrete Station with central platform
        670381051, //Double Concrete Station with central platforms

        538157066, //Sunken Train Station (Concrete)
        536893383, //Sunken Train Station (Brick)
        };

        private static readonly FieldInfo _uiCategoryfield = typeof(PrefabInfo).GetField("m_UICategory", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool Convert(BuildingInfo info)
        {
            UnityEngine.Debug.Log("Processing " + info.name);
            long id;
            if (!Util.TryGetWorkshoId(info, out id))
            {
                return false;
            }
            if (!((IList) Ids).Contains(id))
            {
                UnityEngine.Debug.Log("Not in list " + info.name);
                return false;
            }
            UnityEngine.Debug.Log("Converting " + info.name);
            var metroEntrance = PrefabCollection<BuildingInfo>.FindLoaded("Metro Entrance");
            var ai = info.GetComponent<TransportStationAI>();
            if (ai != null)
            {
                info.m_class = (ItemClass)ScriptableObject.CreateInstance(nameof(ItemClass));
                info.m_class.name = info.name;
                info.m_class.m_subService = ItemClass.SubService.PublicTransportMetro;
                info.m_class.m_service = ItemClass.Service.PublicTransport;
                ai.m_transportLineInfo = PrefabCollection<NetInfo>.FindLoaded("Metro Line");
                ai.m_transportInfo = PrefabCollection<TransportInfo>.FindLoaded("Metro");
                ai.m_maxVehicleCount = 0;
                ai.m_createPassMilestone = metroEntrance.GetComponent<TransportStationAI>().m_createPassMilestone;
                info.m_UnlockMilestone = metroEntrance.m_UnlockMilestone;
            }
            _uiCategoryfield.SetValue(info, metroEntrance.category);

            if (info.m_paths == null)
            {
                return true;
            }
            var metroTrack = PrefabCollection<NetInfo>.FindLoaded("Metro Track Ground");
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

                //TODO(earalov): add More Tracks and ETST tracks
            }
            return true;
        }
    }
}