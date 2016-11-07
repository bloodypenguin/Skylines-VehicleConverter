using System.Linq;
using UnityEngine;
using VehicleConverter.Config;

namespace VehicleConverter
{
    public static class TrainToMetro
    {
        public static bool Convert(VehicleInfo info)
        {
            long id;
            if (!Util.TryGetWorkshopId(info, out id) || !Trains.GetConvertedIds(TrainCategory.Trains).Contains(id))
            {
                return false;
            }
            var metro = Cache.MetroVehicle;
            if (metro == null)
            {
                return false;
            }
            UnityEngine.Debug.Log("Converting " + info.name);
            info.m_class = (ItemClass)ScriptableObject.CreateInstance(nameof(ItemClass));
            info.m_class.name = info.name;
            info.m_class.m_subService = ItemClass.SubService.PublicTransportMetro;
            info.m_class.m_service = ItemClass.Service.PublicTransport;
            info.m_class.m_layer = ItemClass.Layer.MetroTunnels;

            info.m_vehicleType = VehicleInfo.VehicleType.Metro;
            var ai = info.GetComponent<TrainAI>();
            Object.DestroyImmediate(ai);
            ai = info.gameObject.AddComponent<MetroTrainAI>();
            ai.m_transportInfo = Cache.MetroTransport;
            ai.m_info = info;
            info.m_vehicleAI = ai;

            info.m_acceleration = metro.m_acceleration;
            info.m_braking = metro.m_braking;
            info.m_leanMultiplier = metro.m_leanMultiplier;
            info.m_dampers = metro.m_dampers;
            info.m_springs = metro.m_springs;
            info.m_maxSpeed = metro.m_maxSpeed;
            info.m_nodMultiplier = metro.m_nodMultiplier;

            TrainConversions.CustomConversions(info, id, TrainCategory.Trains);

            return true;
        }
    }
}