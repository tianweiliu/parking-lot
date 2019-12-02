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
                catch (Exception)
                {
                    // ignored
                }
            }

            if (ticket != null)
                return ticket;
            
            throw new Exception("Parking lots are full!");
        }

        public Car GetCar(object ticket)
        {
            object car = null;
            foreach (var parkingLot in ManagedParkingLots)
            {
                try
                {
                    car = parkingLot.GetCar(ticket);
                    break;
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            if (car != null)
                return (Car) car;
            
            throw new Exception("Invalid ticket!");
        }
    }
}