using System;
using System.Collections.Generic;
using System.Linq;
using ColossalFramework.UI;
using MetroStationConverter.OptionsFramework;

namespace MetroStationConverter.Config
{
    public static class Stations
    {
        private static readonly Dictionary<StationCategory, StationItem[]> _ids = new Dictionary<StationCategory, StationItem[]>
        {
            {
                StationCategory.Modern, new[]
                {
                    new StationItem(723742558, "Joak's 4-Track Train Station"),
                    new StationItem(720837956, "EDSA MRT3 Philippines"),
                    new StationItem(433435357, "Modern Train Station"),
                    new StationItem(701048320, "train station Thorildsplan"),
                    new StationItem(658612506, "2-Track Elevated Station With Pedestrian deck"),
                    new StationItem(564051384, "2-Track Elevated Station"),
                    new StationItem(532551655, "4-TracksElevatedStation Plain"),
                    new StationItem(532551461, "4-Tracks Elevated Station"),
                    new StationItem(529560650, "Urban Elevated Station NoAD"),
                    new StationItem(527697251, "Urban Elevated Station"),
                    new StationItem(524975362, "Medium Elevated Station"),
                    new StationItem(522406139, "Industrial Elevated Station"),
                    new StationItem(1825385769, "Sotunder Sunken Station"),
                    new StationItem(532099566, "Elevated Double Track Train Station"),
                    new StationItem(665292636, "Skytrain station"),
                    new StationItem(670379488, "Single Concrete Station with central platform"),
                    new StationItem(670381051, "Double Concrete Station with central platforms"),
                    new StationItem(679440978, "Quad's Carapace"),
                    new StationItem(495225348, "Train station one"),
                    new StationItem(512366720, "Train station one double,"),
                    new StationItem(683142113, "Train station one single entry"),
                    new StationItem(698183615, "Big Train Station"),
                    new StationItem(727755831, "Joak's Train Station (2 tracks)"),
                    new StationItem(791997548, "Grand Central"),
                    new StationItem(791996640, "Grand Central - Station Module 1"),
                    new StationItem(782666773, "zhong shan park station"),
                    new StationItem(756870924, "Taichung MRT Station"),
                    new StationItem(618580477, "City Station"),
                    new StationItem(563062277, "Glass Terminus Station"),
                    new StationItem(743648162, "Small Train Station"), 
                    new StationItem(639013753, "Ground Railway-as-Metro Station"), 
                    new StationItem(617136391, "Avenue Road Station (Underground Rail Station)"),
                    new StationItem(725099730, "Overground_Classic"),
                    new StationItem(809604587, "Elevated Train Station Nußdorfer Str."), 
                    new StationItem(1117084893, "Irwindale Station"),
                    new StationItem(1320951498, "Jefferson/USC Station"),
                    new StationItem(1295676106, "Tomashavn Train Station (4-track)"),
                    new StationItem(1295675737, "Tomashavn Train Station (2-track)")
                }
            },
            {
                StationCategory.Old, new[]
                {
                    new StationItem(550104018, "NYC_Elevated Stacked Train Station"),
                    new StationItem(552914350, "NYC Elevated Station Over Road 2"),
                    new StationItem(519519752, "Elevated Train Stop (Read Description pls)"),
                    new StationItem(665774022, "Single Brick Station with central platform"),
                    new StationItem(665788204, "Double Brick Station with central platforms"),
                    new StationItem(753080711, "Taipei MRT Station"),
                }
            },
            {
                StationCategory.Tram, new[]
                {
                    new StationItem(587989905, "[XIRI] Advanced Tram Station"),
                    new StationItem(541850201, "Tram Station"),
                    new StationItem(542504491, "Tram Station 2"),
                    new StationItem(542877830, "[TRAM] Antwerp Large Station 02"),
                    new StationItem(542877989, "[TRAM] Antwerp Large Station 01"),
                    new StationItem(571249327, "FancyTrack B", true),
                    new StationItem(571248983, "FancyTrack A", true),
                    new StationItem(542877628, "[TRAM] Antwerp Large track 01"),
                    new StationItem(542877135, "[TRAM] Antwerp Large track 04"),
                    new StationItem(542877338, "[TRAM] Antwerp Large track 03"),
                    new StationItem(542877508, "[TRAM] Antwerp Large track 02"),
                    new StationItem(544693280, "[XIRI] LTN Station [In-Avenue Station]"),
                    new StationItem(702425484, "Joak's Tram (Train) Station"),
                    new StationItem(762691618, "Old Town Elevated Platform"),
                    new StationItem(766344682, "Basic Elevated Rail Platform"),
                    new StationItem(781768600, "[Train] KLRT Standard Station"),

                }
            },
        };

        private static bool _configIsOverriden;

        public static IEnumerable<StationItem> GetItems(StationCategory StationCategory = StationCategory.All)
        {
            var list = new List<StationItem>();
            _ids.Where(kvp => (kvp.Key & StationCategory) != 0).Select(kvp => kvp.Value).ForEach(a => list.AddRange(a));
            return list;
        }

        private static Dictionary<StationCategory, StationItem[]> Ids  {
            get
            {
                if (_configIsOverriden)
                {
                    return _ids;
                }
                _ids[StationCategory.Modern] = OptionsWrapper<Config>.Options.ModernStations.Items.ToArray();
                _ids[StationCategory.Old] = OptionsWrapper<Config>.Options.OldStations.Items.ToArray();
                _ids[StationCategory.Tram] = OptionsWrapper<Config>.Options.TramStations.Items.ToArray();
                _configIsOverriden = true;
                return _ids;
            }
        }

        public static StationItem GetItem(long id)
        {
            var modern = Ids[StationCategory.Modern].FirstOrDefault(i => i.WorkshopId == id);
            if (modern != null)
            {
                return modern;
            }
            var old = Ids[StationCategory.Old].FirstOrDefault(i => i.WorkshopId == id);
            return old ?? Ids[StationCategory.Tram].FirstOrDefault(i => i.WorkshopId == id);
        }

        public static long[] GetConvertedIds(StationCategory StationCategory = StationCategory.All)
        {
            var list = new List<long>();
            Ids.Where(kvp => IsCategoryEnabled(kvp.Key) && (kvp.Key & StationCategory) != 0).Select(kvp => kvp.Value).ForEach(l => l.ForEach(t =>
            {
                if (!t.Exclude)
                {
                    list.Add(t.WorkshopId);
                }
            }));
            return list.ToArray();
        }

        private static bool IsCategoryEnabled(StationCategory StationCategory)
        {
            switch (StationCategory)
            {
                case StationCategory.Modern:
                    return OptionsWrapper<Options>.Options.ConvertModernStationsToMetroStations;
                case StationCategory.Old:
                    return OptionsWrapper<Options>.Options.ConvertOldStationsToMetroStations;
                case StationCategory.Tram:
                    return OptionsWrapper<Options>.Options.ConvertTramStationsToMetroStations;
                default:
                    throw new ArgumentOutOfRangeException(nameof(StationCategory), StationCategory, null);
            }
        }

        public static StationCategory GetCategory(long id)
        {
            return Ids.Keys.FirstOrDefault(cat => Ids[cat].Select(i => i.WorkshopId).Contains(id));
        }
    }
}