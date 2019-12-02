using System;
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

        public object Park(Car car)
        {
            object ticket = null;
            foreach (var parkingLot in ManagedParkingLots)
            {
                try
                {
                    ticket = parkingLot.Park(car);
                    break;
                }
                catch (Exception e)
                {
                    // ignored
                }
            }

            return ticket;
        }
    }
}