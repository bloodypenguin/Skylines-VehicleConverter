namespace MetroStationConverter
{
    public static class Cache
    {
        private static VehicleInfo _metroVehicle;
        private static TransportInfo _metroTransport;
        private static VehicleInfo _tramVehicle;
        private static TransportInfo _tramTransport;

        public static VehicleInfo MetroVehicle
        {
            get { return _metroVehicle ?? (_metroVehicle = PrefabCollection<VehicleInfo>.FindLoaded("Metro")); }
            private set { _metroVehicle = value; }
        }

        public static TransportInfo MetroTransport
        {
            get { return _metroTransport ?? (_metroTransport = PrefabCollection<TransportInfo>.FindLoaded("Metro")); }
            private set { _metroTransport = value; }
        }

        public static VehicleInfo TramVehicle
        {
            get { return _tramVehicle ?? (_tramVehicle = PrefabCollection<VehicleInfo>.FindLoaded("Tram")); }
            private set { _tramVehicle = value; }
        }

        public static TransportInfo TramTransport
        {
            get { return _tramTransport ?? (_tramTransport = PrefabCollection<TransportInfo>.FindLoaded("Tram")); }
            private set { _tramTransport = value; }
        }

        public static void Reset()
        {
            MetroVehicle = null;
            MetroTransport = null;
            TramTransport = null;
            TramVehicle = null;
        }
    }
}