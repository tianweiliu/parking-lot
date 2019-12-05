using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_lot
{
    public class ParkingBoy : ParkingAgent
    {
        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            ManagedParkingLots = parkingLots;
        }

        public override object Park(Car car)
        {
            var theMostSpaceParkingLot = GetTheMostSpaceParkingLot();
            if (theMostSpaceParkingLot.GetAvailableSpace() == 0)
            {
                throw new Exception("Parking lots are full!");
            }

            return theMostSpaceParkingLot.Park(car);
        }

        public Car GetCar(object ticket)
        {
            object car;
            foreach (var parkingLot in ManagedParkingLots)
            {
                if (parkingLot.IsTicketValid(ticket))
                {
                    car = parkingLot.GetCar(ticket);
                    return car as Car;
                }
            }

            throw new Exception("Invalid ticket!");
        }

        private ParkingLot GetTheMostSpaceParkingLot()
        {
            return ManagedParkingLots.OrderByDescending(p => p.GetAvailableSpace()).First();
        }
    }
}