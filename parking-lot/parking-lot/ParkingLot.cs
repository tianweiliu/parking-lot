using System;
using System.Collections.Generic;

namespace parking_lot
{
    public class ParkingLot : ICarParking, ICarRetrieving
    {
        private readonly Dictionary<object, Car> _ticketToCars;
        private readonly int _totalSpaceCount;

        public ParkingLot(int totalSpaceCount)
        {
            _ticketToCars = new Dictionary<object, Car>();
            _totalSpaceCount = totalSpaceCount;
        }

        public object Park(Car car)
        {
            var ticket = new object();
            var count = _ticketToCars.Count;
            if (count < _totalSpaceCount)
            {
                _ticketToCars.Add(ticket, car);
                return ticket;
            }

            throw new Exception("ParkingLot is full");
        }

        public Car GetCar(object ticket)
        {
            if (_ticketToCars.ContainsKey(ticket))
            {
                var car = _ticketToCars[ticket];
                _ticketToCars.Remove(ticket);
                return car;
            }

            throw new Exception("Invalid ticket!");

        }

        public int GetAvailableSpace()
        {
            return _totalSpaceCount - _ticketToCars.Count;
        }

        public bool IsTicketValid(object ticket)
        {
            return _ticketToCars.ContainsKey(ticket);
        }
    }
}