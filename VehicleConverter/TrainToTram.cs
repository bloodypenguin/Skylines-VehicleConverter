using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using VehicleConverter.Config;
using Object = UnityEngine.Object;

namespace VehicleConverter
{
    public class TrainToTram
    {
        public static bool Convert(VehicleInfo info)
        {
            long id;
            if (!Util.TryGetWorkshoId(info, out id) || !Trains.GetConvertedIds(Category.Tram).Contains(id))
            {
                return false;
            }
            var tram = Cache.TramVehicle;
            if (tram == null)
            {
                return false;
            }
            UnityEngine.Debug.Log("Converting " + info.name);
            info.m_class = (ItemClass)ScriptableObject.CreateInstance(nameof(ItemClass));
            info.m_class.name = info.name;
            info.m_class.m_subService = ItemClass.SubService.PublicTransportTram;
            info.m_class.m_service = ItemClass.Service.PublicTransport;

            info.m_vehicleType = VehicleInfo.VehicleType.Tram;
            var oldAi = info.GetComponent<TrainAI>();
            Object.DestroyImmediate(oldAi);
            var ai = info.gameObject.AddComponent<TramAI>();
            ai.m_transportInfo = Cache.TramTransport;
            ai.m_info = info;
            info.m_vehicleAI = ai;

            ai.m_passengerCapacity = ((TramAI)tram.m_vehicleAI).m_passengerCapacity;
            ai.m_ticketPrice = ((TramAI)tram.m_vehicleAI).m_ticketPrice;
            ai.m_arriveEffect = ((TramAI)tram.m_vehicleAI).m_arriveEffect;
            info.m_acceleration = tram.m_acceleration;
            info.m_braking = tram.m_braking;
            info.m_leanMultiplier = tram.m_leanMultiplier;
            info.m_dampers = tram.m_dampers;
            info.m_springs = tram.m_springs;
            info.m_maxSpeed = tram.m_maxSpeed;
            info.m_nodMultiplier = tram.m_nodMultiplier;

            var effect = tram.m_effects.Where(e => e.m_effect.name == "Tram Movement").First();
            info.m_effects = info.m_effects.Where(e => e.m_effect.name == "Train Movement").Select(e => effect).ToArray();

            Trains.CustomConversions(info, id, Category.Tram);

            return true;
        }
    }
}