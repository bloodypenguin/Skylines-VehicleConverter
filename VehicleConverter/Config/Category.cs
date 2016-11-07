using System;

namespace VehicleConverter.Config
{
    [Flags]
    public enum Category
    {
        None = 0,
        Underground = 1,
        SBahn = 2,
        Tram = 4,
        Pantograph = 8,
        Trains = Underground | SBahn | Pantograph,
        All = Trains | Tram
    }
}
