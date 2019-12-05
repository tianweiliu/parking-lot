using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingBot : ParkingAgent
    {
        public ParkingBot(List<ParkingLot> parkingLots)
        {
            ManagedParkingLots = parkingLots;
        }
        
        public override object Park(Car car)
        {
            object ticket;
            foreach (var parkingLot in ManagedParkingLots)
            {
                if (parkingLot.GetAvailableSpace() > 0)
                {
                    ticket = parkingLot.Park(car);
                    return ticket;
                }
            }

            throw new Exception("Parking lots are full!");
        }
    }
}