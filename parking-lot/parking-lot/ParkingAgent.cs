using System.Collections.Generic;

namespace parking_lot
{
    public abstract class ParkingAgent
    {
        public List<ParkingLot> ManagedParkingLots { get; protected set; }
        public abstract object Park(Car car);
    }
}