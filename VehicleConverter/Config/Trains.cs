using System;
using System.Collections.Generic;
using System.Linq;
using ColossalFramework.UI;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter.Config
{
    public static class Trains
    {
        private static readonly Dictionary<Category, TrainItem[]> _ids = new Dictionary<Category, TrainItem[]>
        {
            {
                Category.Underground, new[]
                {
                    new TrainItem(640837010, "X'Trapolis Metro Melbourne"),
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
                    new TrainItem(585209941, "S1 Tram/Metro (double) [Train]"),
                    new TrainItem(561008120, "S1 Tram/Metro (alt. livery) [Train]"),
                    new TrainItem(561007663, "S1 Tram/Metro [Train]"),
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
                }
            },
            {
                Category.SBahn, new[]
                {
                    new TrainItem(659505001, "Berlin S-Bahn Type 481"),
                    new TrainItem(455504253, "S-Bahn Berlin train engine"),
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
                }
            },
            {
                Category.Tram, new[]
                {
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
                }
            },
            //Korails?
            //JR?
            //ron_fu-ta?
        };

        private static bool _configIsOverriden;

        public static IEnumerable<TrainItem> GetItems(Category category = Category.All)
        {
            var list = new List<TrainItem>();
            _ids.Where(kvp => (kvp.Key & category) != 0).Select(kvp => kvp.Value).ForEach(a => list.AddRange(a));
            return list;
        }

        private static Dictionary<Category, TrainItem[]> Ids  {
            get
            {
                if (_configIsOverriden)
                {
                    return _ids;
                }
                _ids[Category.Underground] = OptionsWrapper<Config>.Options.Underground.Items.ToArray();
                _ids[Category.SBahn] = OptionsWrapper<Config>.Options.SBahn.Items.ToArray();
                _ids[Category.Tram] = OptionsWrapper<Config>.Options.Trams.Items.ToArray();
                _configIsOverriden = true;
                return _ids;
            }
        }

        public static IEnumerable<long> GetConvertedIds(Category category = Category.All)
        {
            var list = new List<long>();
            Ids.Where(kvp => IsCategoryEnabled(kvp.Key) && (kvp.Key & category) != 0).Select(kvp => kvp.Value).ForEach(l => l.ForEach(t => list.Add(t.WorkshopId)));
            return list;
        }

        private static bool IsCategoryEnabled(Category category)
        {
            switch (category)
            {
                case Category.Underground:
                    return OptionsWrapper<Options>.Options.ConvertSubwayTrainsToMetros && Util.IsModActive("Metro Overhaul");
                case Category.SBahn:
                    return OptionsWrapper<Options>.Options.ConvertSBahnsToMetros && Util.IsModActive("Metro Overhaul");
                case Category.Pantograph:
                    return OptionsWrapper<Options>.Options.ConvertPantographsToMetros && Util.IsModActive("Metro Overhaul");
                case Category.Tram:
                    return OptionsWrapper<Options>.Options.ConvertTrainsToTrams && Util.DLC(SteamHelper.kWinterDLCAppID) ;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }

        public static void CustomConversions(VehicleInfo info, long id, Category category)
        {
            {
                if (info.m_trailers != null && info.m_trailers.Length > 0) //TODO(earalov): implement take trailers feature
                {
                    switch (id)
                    {
                        default:
                            break;
                    }
                }

                if (!ReplaceLastCar(id, category))
                {
                    return;
                }
                if (info.m_trailers != null && info.m_trailers.Length > 0)
                {
                    info.m_trailers[info.m_trailers.Length - 1] = new VehicleInfo.VehicleTrailer()
                    {
                        m_info = info, m_probability = 100, m_invertProbability = 100
                    };
                }
            }
        }

        private static bool ReplaceLastCar(long id, Category category)
        {
            var list = new List<long>();
            Ids.Where(kvp => (kvp.Key & category) != 0).Select(kvp => kvp.Value).ForEach(l => l.ForEach(t => list.Add(t.WorkshopId)));
            return list.Contains(id);
        }


    }
}