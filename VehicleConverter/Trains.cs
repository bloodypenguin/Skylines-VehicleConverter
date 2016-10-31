using System;
using System.Collections.Generic;
using System.Linq;
using ColossalFramework;
using ColossalFramework.Steamworks;
using ColossalFramework.UI;
using VehicleConverter.OptionsFramework;

namespace VehicleConverter
{
    public static class Trains
    {
        private static readonly Dictionary<Category, long[]> Ids = new Dictionary<Category, long[]>
        {
            {
                Category.Underground, new long[]
                {
                    640837010, //X'Trapolis Metro Melbourne
                    500938881, //Vienna Underground T Stock
                    502118263, //Vienna Underground E6/c6 Stock (short)
                    501495034, //Vienna Underground E6/c6 Stock
                    633692704, //Budd Universal Transport Vehicle (reverse?)
                    635271742, //Boeing-Vertol 2400 "L" 2x2
                    635272086, //Boeing-Vertol 2400 "L" 2x3
                    635272317, //Boeing-Vertol 2400 "L" 2x4
                    709706599, //SkyConnect Airport Shuttle Train
                    485714617, //Skytrain Mk1 Trainset (Vancouver, Canada)
                    520121187, //London Underground 1995 Stock
                    520329377, //1995 Stock (Line Colour)
                    524764895, //London Underground S Stock
                    524788629, //S Stock (Line Colour)
                    623036646, //Metro de Madrid Serie 3000
                    621116591, //Alstom Metropolis '08 (Metrô São Paulo) [HD]
                    565179974, //Randstadrail RegioCitadis [Train]
                    585209941, //S1 Tram/Metro (double) [Train]
                    561008120, //S1 Tram/Metro (alt. livery) [Train]
                    561007663, //S1 Tram/Metro [Train]
                    584699037, //Stockholm Subway train
                    500814074, //Vienna Underground U11 Stock
                    512101792, //Berlin Underground HK Stock
                    477450130, //NYC_R22_Cities Skylines Edition
                    477438549, //NYC_R22_RedBird
                    477459492, //NYC_R22_White Shuttle
                    477455103, //NYC_R22_Brooklyn Shuttle
                    523971486, //NYC_R22_GreenLine
                    460844654, //R62 New York subway train (AD Updated)
                    559072671, //TTC Toronto Rocket (TR) Subway Train
                    634917815, //TTC Gloucester Subway Train (Toronto)
                    710069662, //TTC T1 Subway
                    657046217, //Berlin Subway Type A3L
                    452247050, //EL Train
                    576798145, //DT3
                    572811805, //DT3E
                    718075234, //DT4
                    459046989, //Hong Kong MTR M Stock Passenger Trainset
                    719354151, //C14 - Stockholm metro train - with stripe
                    719354802, //C14 - Stockholm metro train - without stripe
                }
            },
            {
                Category.SBahn, new long[]
                {
                    659505001, //Berlin S-Bahn Type 481
                    455504253, //S-Bahn Berlin train engine
                    //Thaok S-Bahns
                    537268020, //Hamburg S-Bahn Class ET 171 (471) 3 car
                    537268458, //Hamburg S-Bahn Class ET 171 (471) 6 car
                    545479099, //Hamburg S-Bahn Class ET 170 (470) 3 car
                    545479818, //Hamburg S-Bahn Class ET 170 (470) 6 car
                    545480349, //Hamburg S-Bahn Class ET 170 + 171 6 car
                    566937615, //Berlin S-Bahn ET/ES 165 "Passviertel" (2 car)
                    549536528, //Berlin S-Bahn ET/ES 165 "Stadtbahner" (2 car)
                    566937816, //Berlin S-Bahn ET/EB 165 (4 car)
                    566937997, //Berlin S-Bahn ET/EB 165 (6 car)
                    566938132, //Berlin S-Bahn ET/EB 165 (8 car)
                }
            },
            {
                Category.Tram, new long[]
                {
                    563142263, //TTC CLRV
                    567886231, //TTC ALRV
                    621843448, //TTC Bombardier Flexity Streetcar
                    616229532, //Bombardier FLEXITY Freedom
                    528583441, //NOT FOR SNOWFALL! Bombardier Transportation Flexity XXL Leipzig 5 Car Variant
                    529146433, //NOT FOR SNOWFALL! Bombardier Transportation Flexity XXL Leipzig 4 Car Variant
                    537216445, //NOT FOR SNOWFALL! Bombardier Transportation Flexity Classic Bremen 1way
                    546280566, //NOT FOR SNOWFALL! Bombardier Transportation Flexity Classic "Bremen" 2 way version
                    546133378, //NOT FOR SNOWFALL! Siemens Type-R Frankfurt
                    575146494, //RVR6 (Tram-Train),
                    575168349, //RVR6 x2 (Tram-Train),
                    582051598, //Tatra T5C5 (Train-Tram),
                    577930337, //Tatra T3 as train
                    577932805, //Tatra T3 2 CAR Train
                    577933896, //Tatra T3 3 Car Train,
                    578797963, //TATRA T6B5 as a TRAIN
                    578802024, //Tatra T6B5 3 Car Train
                    578809294, //TATRA T6B5 2 Car Train
                    613511373, //San Francisco Single-Ended Cable Car (Train)
                    644470261, //Combino Supra Light Rail
                    560073353, //Chirpy LRT
                }
            },
            //Korails?
            //JR?
            //ron_fu-ta?
        };

        public static IEnumerable<long> GetConvertedIds(Category category = Category.All)
        {
            IEnumerable<long> list = new List<long>();
            Ids.Where(kvp => IsCategoryEnabled(kvp.Key) && (kvp.Key & category) != 0).Select(kvp => kvp.Value).ForEach(l => list = list.Concat(l));
            return list;
        }

        private static bool IsCategoryEnabled(Category category)
        {
            switch (category)
            {
                case Category.Underground:
                    return OptionsWrapper<Options>.Options.convertTrainsToMetros && Util.IsModActive("Metro Overhaul");
                case Category.SBahn:
                    return OptionsWrapper<Options>.Options.convertSBahnsToMetros && Util.IsModActive("Metro Overhaul");
                case Category.Tram:
                    return OptionsWrapper<Options>.Options.convertTrainsToTrams && Util.DLC(SteamHelper.kWinterDLCAppID) ;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }


        public static void CustomConversions(VehicleInfo info, long id)
        {
            {
                if (info.m_trailers != null && info.m_trailers.Length > 0)
                {
                    switch (id)
                    {
                        default:
                            break;
                    }
                }

                if (Trains.ReplaceLastCar(id))
                {
                    if (info.m_trailers != null && info.m_trailers.Length > 0)
                    {
                        info.m_trailers[info.m_trailers.Length - 1] = new VehicleInfo.VehicleTrailer()
                        {
                            m_info = info, m_probability = 100, m_invertProbability = 100
                        };
                    }
                }
            }
        }

        private static bool ReplaceLastCar(long id)
        {
            return new long[]
            {
                537268020, //Hamburg S-Bahn Class ET 171 (471) 3 car
                537268458, //Hamburg S-Bahn Class ET 171 (471) 6 car
                545479099, //Hamburg S-Bahn Class ET 170 (470) 3 car
                545479818, //Hamburg S-Bahn Class ET 170 (470) 6 car
                545480349, //Hamburg S-Bahn Class ET 170 + 171 6 car
                635271742, //Boeing-Vertol 2400 "L" 2x2
                635272086, //Boeing-Vertol 2400 "L" 2x3
                635272317, //Boeing-Vertol 2400 "L" 2x4
                565179974, //Randstadrail RegioCitadis [Train] (reverse)
                644470261, //Combino Supra Light Rail
                546133378, //NOT FOR SNOWFALL! Siemens Type-R Frankfurt
                546280566, //NOT FOR SNOWFALL! Bombardier Transportation Flexity Classic "Bremen" 2 way version
            }.Contains(id);
        }

        [Flags]
        public enum Category
        {
            None = 0,
            Underground = 1,
            SBahn = 2,
            Tram = 4,
            Trains = Underground | SBahn,
            All = Trains | Tram
        }
    }
}