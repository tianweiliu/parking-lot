using System.Collections.Generic;

namespace parking_lot
{
    public abstract class ParkingLotManager
    {
        public List<ParkingLot> ManagedParkingLots { get; protected set; }
    }
}