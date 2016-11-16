using System;
using System.Collections.Generic;
using System.Linq;
using ColossalFramework.UI;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter.Config
{
    public static class Trains
    {
        private static readonly Dictionary<TrainCategory, TrainItem[]> _ids = new Dictionary<TrainCategory, TrainItem[]>
        {
            {
                TrainCategory.Underground, new[]
                {
                    new TrainItem(500938881, "Vienna Underground T Stock"),
                    new TrainItem(502118263, "Vienna Underground E6/c6 Stock (short)"),
                    new TrainItem(501495034, "Vienna Underground E6/c6 Stock"),
                    new TrainItem(633692704, "Budd Universal Transport Vehicle (reverse?)"),
                    new TrainItem(635271742, "Boeing-Vertol 2400 \"L\" 2x2", true),
                    new TrainItem(635272086, "Boeing-Vertol 2400 \"L\" 2x3", true),
                    new TrainItem(635272317, "Boeing-Vertol 2400 \"L\" 2x4", true),
                    new TrainItem(709706599, "SkyConnect Airport Shuttle Train"),
                    new TrainItem(485714617, "Skytrain Mk1 Trainset (Vancouver, Canada)"),
                    new TrainItem(520121187, "London Underground 1995 Stock"),
                    new TrainItem(520329377, "1995 Stock (Line Colour)"),
                    new TrainItem(524764895, "London Underground S Stock"),
                    new TrainItem(524788629, "S Stock (Line Colour)"),
                    new TrainItem(623036646, "Metro de Madrid Serie 3000"),
                    new TrainItem(621116591, "Alstom Metropolis '08 (Metrô São Paulo) [HD]"),
                    new TrainItem(565179974, "Randstadrail RegioCitadis [Train]", true),
                    new TrainItem(584699037, "Stockholm Subway train"),
                    new TrainItem(500814074, "Vienna Underground U11 Stock"),
                    new TrainItem(512101792, "Berlin Underground HK Stock"),
                    new TrainItem(477450130, "NYC_R22_Cities Skylines Edition"),
                    new TrainItem(477438549, "NYC_R22_RedBird"),
                    new TrainItem(477459492, "NYC_R22_White Shuttle"),
                    new TrainItem(477455103, "NYC_R22_Brooklyn Shuttle"),
                    new TrainItem(523971486, "NYC_R22_GreenLine"),
                    new TrainItem(460844654, "R62 New York subway train (AD Updated)"),
                    new TrainItem(559072671, "TTC Toronto Rocket (TR) Subway Train"),
                    new TrainItem(634917815, "TTC Gloucester Subway Train (Toronto)"),
                    new TrainItem(710069662, "TTC T1 Subway"),
                    new TrainItem(657046217, "Berlin Subway Type A3L"),
                    new TrainItem(452247050, "EL Train"),
                    new TrainItem(576798145, "DT3"),
                    new TrainItem(572811805, "DT3E"),
                    new TrainItem(718075234, "DT4"),
                    new TrainItem(459046989, "Hong Kong MTR M Stock Passenger Trainset"),
                    new TrainItem(719354151, "C14 - Stockholm metro train - with stripe"),
                    new TrainItem(719354802, "C14 - Stockholm metro train - without stripe"),
                    new TrainItem(783040852, "Taipei Metro Kwasaki C371 3Cars_Metro Version"),
                    new TrainItem(757806599, "Taipei Metro Kawasaki C371 5Cars _Train"),
                    new TrainItem(770004076, "Hamburg Metro | DT5 HOCHBAHN long fictitious (no mid engine)"),
                    new TrainItem(769873579, "Hamburg Metro | DT5 HOCHBAHN triple Unit"),
                    new TrainItem(768353544, "Hamburg Metro | DT5 HOCHBAHN double unit"),
                    new TrainItem(768353273, "Hamburg Metro | DT5 HOCHBAHN single unit"),
                    new TrainItem(766722658, "Moscow Metro Train #1"),
                    new TrainItem(730504141, "C14 - Stockholm metro train - with colorable stripe"),
                    new TrainItem(722264461, "S1 Metro"),
                }
            },
            {
                TrainCategory.SBahn, new[]
                {
                    new TrainItem(659505001, "Berlin S-Bahn Type 481"),
                    new TrainItem(455504253, "S-Bahn Berlin train engine"),
                    new TrainItem(775928677, "Hamburg Metro | ET490 S-Bahn Hamburg"),
                    //Thaok S-Bahns
                    new TrainItem(537268020, "Hamburg S-Bahn Class ET 171 (471) 3 car", true),
                    new TrainItem(537268458, "Hamburg S-Bahn Class ET 171 (471) 6 car", true),
                    new TrainItem(545479099, "Hamburg S-Bahn Class ET 170 (470) 3 car", true),
                    new TrainItem(545479818, "Hamburg S-Bahn Class ET 170 (470) 6 car", true),
                    new TrainItem(545480349, "Hamburg S-Bahn Class ET 170 + 171 6 car", true),
                    new TrainItem(566937615, "Berlin S-Bahn ET/ES 165 \"Passviertel\" (2 car)"),
                    new TrainItem(549536528, "Berlin S-Bahn ET/ES 165 \"Stadtbahner\" (2 car)"),
                    new TrainItem(566937816, "Berlin S-Bahn ET/EB 165 (4 car)"),
                    new TrainItem(566937997, "Berlin S-Bahn ET/EB 165 (6 car)"),
                    new TrainItem(566938132, "Berlin S-Bahn ET/EB 165 (8 car)"),
                    new TrainItem(785264960, "Hamburg S-Bahn Class 474/874 (6 car)"),
                    new TrainItem(785264521, "Hamburg S-Bahn Class 474/874 (3 car)"),
                    //London overground
                    new TrainItem(559175122, "British Rail Class 378 (Line Colour)"),
                    new TrainItem(527925460, "British Rail Class 378"),  

                }
            },
            {
                TrainCategory.Tram, new[]
                {
                    new TrainItem(585209941, "S1 Tram/Metro (double) [Train]"),
                    new TrainItem(561008120, "S1 Tram/Metro (alt. livery) [Train]"),
                    new TrainItem(561007663, "S1 Tram/Metro [Train]"),
                    new TrainItem(563142263, "TTC CLRV"),
                    new TrainItem(567886231, "TTC ALRV"),
                    new TrainItem(621843448, "TTC Bombardier Flexity Streetcar"),
                    new TrainItem(616229532, "Bombardier FLEXITY Freedom"),
                    new TrainItem(528583441, "NOT FOR SNOWFALL! Bombardier Transportation Flexity XXL Leipzig 5 Car Variant"),
                    new TrainItem(529146433, "NOT FOR SNOWFALL! Bombardier Transportation Flexity XXL Leipzig 4 Car Variant"),
                    new TrainItem(537216445, "NOT FOR SNOWFALL! Bombardier Transportation Flexity Classic Bremen 1way"),
                    new TrainItem(546280566, "NOT FOR SNOWFALL! Bombardier Transportation Flexity Classic \"Bremen\" 2 way version", true),
                    new TrainItem(546133378, "NOT FOR SNOWFALL! Siemens Type-R Frankfurt", true),
                    new TrainItem(575146494, "RVR6 (Tram-Train)"),
                    new TrainItem(575168349, "RVR6 x2 (Tram-Train)"),
                    new TrainItem(582051598, "Tatra T5C5 (Train-Tram)"),
                    new TrainItem(577930337, "Tatra T3 as train"),
                    new TrainItem(577932805, "Tatra T3 2 CAR Train"),
                    new TrainItem(577933896, "Tatra T3 3 Car Train"),
                    new TrainItem(578797963, "TATRA T6B5 as a TRAIN"),
                    new TrainItem(578802024, "Tatra T6B5 3 Car Train"),
                    new TrainItem(578809294, "TATRA T6B5 2 Car Train"),
                    new TrainItem(613511373, "San Francisco Single-Ended Cable Car (Train)"),
                    new TrainItem(644470261, "Combino Supra Light Rail", true),
                    new TrainItem(560073353, "Chirpy LRT"),
                    new TrainItem(771217275, "[Train] Kaohsiung Light Rail Urbos 3"),
                    new TrainItem(640837010, "X'Trapolis Metro Melbourne"),
                }
            },
            {
                TrainCategory.Pantograph, new[]
                {
                    new TrainItem(476291849, "JR East series E233-2000"),
                    new TrainItem(479313124, "JR East series E231-500"),
                    new TrainItem(542334716, "Chirpy S-Bahn train 4 car"),
                    new TrainItem(549489366, "JR East series E233-3000"),
                    new TrainItem(602373333, "JR East series 209"),
                    new TrainItem(665292383, "Chirpy Skytrain"),
                    new TrainItem(795326479, "JR West series 321"),
                    new TrainItem(740475598, "JR East E231-800 EMU"),
                    new TrainItem(454460340, "JR E231 Trainset (Japan)"),
                    new TrainItem(449385670, "JR-EAST Series E233 EMU"),
                    new TrainItem(757719489, "Tobu Railway 50000 Series EMU"),
                    new TrainItem(743648823, "Keikyu N1000 Series"),
                    new TrainItem(740475598, "JR East E231-800 EMU"),
                    new TrainItem(614153454, "ELVIS korail resistance type metro"),
                }
            },
        };

        private static bool _configIsOverriden;

        public static IEnumerable<TrainItem> GetItems(TrainCategory trainCategory = TrainCategory.All)
        {
            var list = new List<TrainItem>();
            _ids.Where(kvp => (kvp.Key & trainCategory) != 0).Select(kvp => kvp.Value).ForEach(a => list.AddRange(a));
            return list;
        }

        private static Dictionary<TrainCategory, TrainItem[]> Ids  {
            get
            {
                if (_configIsOverriden)
                {
                    return _ids;
                }
                _ids[TrainCategory.Underground] = OptionsWrapper<Config>.Options.Underground.Items.ToArray();
                _ids[TrainCategory.SBahn] = OptionsWrapper<Config>.Options.SBahn.Items.ToArray();
                _ids[TrainCategory.Tram] = OptionsWrapper<Config>.Options.Trams.Items.ToArray();
                _ids[TrainCategory.Pantograph] = OptionsWrapper<Config>.Options.Pantograph.Items.ToArray();
                _configIsOverriden = true;
                return _ids;
            }
        }

        public static long[] GetConvertedIds(TrainCategory trainCategory = TrainCategory.All)
        {
            var list = new List<long>();
            Ids.Where(kvp => IsCategoryEnabled(kvp.Key) && (kvp.Key & trainCategory) != 0).Select(kvp => kvp.Value).ForEach(l => l.ForEach(t =>
            {
                if (!t.Exclude)
                {
                    list.Add(t.WorkshopId);
                }
            }));
            return list.ToArray();
        }

        private static bool IsCategoryEnabled(TrainCategory trainCategory)
        {
            switch (trainCategory)
            {
                case TrainCategory.Underground:
                    return OptionsWrapper<Options>.Options.ConvertSubwayTrainsToMetros && Util.IsModActive("Metro Overhaul");
                case TrainCategory.SBahn:
                    return OptionsWrapper<Options>.Options.ConvertSBahnsToMetros && Util.IsModActive("Metro Overhaul");
                case TrainCategory.Pantograph:
                    return OptionsWrapper<Options>.Options.ConvertPantographsToMetros && Util.IsModActive("Metro Overhaul");
                case TrainCategory.Tram:
                    return OptionsWrapper<Options>.Options.ConvertTrainsToTrams && Util.DLC(SteamHelper.kWinterDLCAppID) ;
                default:
                    throw new ArgumentOutOfRangeException(nameof(trainCategory), trainCategory, null);
            }
        }

        public static bool ReplaceLastCar(long id, TrainCategory trainCategory)
        {
            var list = new List<long>();
            Ids.Where(kvp => (kvp.Key & trainCategory) != 0).Select(kvp => kvp.Value).ForEach(l => l.ForEach(t =>
            {
                if (t.ReplaceLastTrailerWithEngine)
                {
                    list.Add(t.WorkshopId);
                }
            }));
            return list.Contains(id);
        }


    }
}