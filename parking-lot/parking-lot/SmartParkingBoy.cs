using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_lot
{
    public class SmartParkingBoy : ParkingBoy
    {

        public object Park(Car car)
        {
            var theMostSpaceParkingLot = GetTheMostSpaceParkingLot();
            if (theMostSpaceParkingLot.GetAvailableSpace() == 0)
            {
                throw new Exception("Parking lots are full!");
            }

            return theMostSpaceParkingLot.Park(car);
        }


        private ParkingLot GetTheMostSpaceParkingLot()
        {
            return ManagedParkingLots.OrderByDescending(p => p.GetAvailableSpace()).First();
        }

        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }
    }
}