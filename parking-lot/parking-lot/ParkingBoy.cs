using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingBoy
    {
        public List<ParkingLot> ManagedParkingLots { get; }

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            ManagedParkingLots = parkingLots;
        }
    }
}