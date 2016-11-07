using VehicleConverter.Config;

namespace VehicleConverter
{
    public static class TrainConversions
    {
        public static void CustomConversions(VehicleInfo info, long id, TrainCategory trainCategory)
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

                if (!Trains.ReplaceLastCar(id, trainCategory))
                {
                    return;
                }
                if (info.m_trailers != null && info.m_trailers.Length > 0)
                {
                    info.m_trailers[info.m_trailers.Length - 1] = new VehicleInfo.VehicleTrailer()
                    {
                        m_info = info,
                        m_probability = 100,
                        m_invertProbability = 100
                    };
                }
            }
        }
    }
}