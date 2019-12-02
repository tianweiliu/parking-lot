using System;
using System.Collections.Generic;
using System.Globalization;
using parking_lot;
using Xunit;

namespace parking_lot_test
{
    public class parking_lot_facts
    {
        private readonly Car _car;
        private ParkingLot _parkingLot;
        private const int parkingLotSize = 20;

        public parking_lot_facts()
        {
            _car = new Car();
            _parkingLot = new ParkingLot();
        }

        [Fact]
        public void should_park_a_car_into_a_parking_lot_which_has_space_and_get_a_ticket()
        {
            var ticket = _parkingLot.Park(_car);

            Assert.NotNull(ticket);
        }

//        given 一个停车场和一个有效小票 when 我去停车场取车 then 我可以取到我停的那辆车
        [Fact]
        public void should_get_the_car_given_valid_ticket_to_take_the_car()
        {
            var ticket = _parkingLot.Park(_car);

            var myCar = _parkingLot.GetCar(ticket);

            Assert.Equal(_car, myCar);
        }

        [Fact]
        public void should_not_take_the_car_when_given_a_invalid_ticket()
        {
            var ticketInvalid = new object();


            Assert.Throws<Exception>(() => _parkingLot.GetCar(ticketInvalid));
        }

        [Fact]
        public void should_not_get_the_car_when_given_a_ticket_has_used()
        {
            var ticketUseWithSecond = _parkingLot.Park(_car);

            var car = _parkingLot.GetCar(ticketUseWithSecond);

            Assert.Equal(_car, car);

            Assert.Throws<Exception>(() => _parkingLot.GetCar(ticketUseWithSecond));
        }

        [Fact]
        public void should_not_park_car_when_parkinglot_is_full()
        {
            for (int i = 0; i < parkingLotSize; i++)
            {
                _parkingLot.Park(new Car());
            }

            Assert.Throws<Exception>(() => _parkingLot.Park(new Car()));
        }

        // 0.  given an ordered list when give it to parking boy then get a same ordered list back
        [Fact]
        void should_return_same_ordered_list_when_given_ordered_list()
        {
            var parkingLot1 = new ParkingLot();
            var parkingLot2 = new ParkingLot();
            var managedParkingLots = new List<ParkingLot>
            {
                parkingLot1,
                parkingLot2
            };
            var parkingBoy = new ParkingBoy(managedParkingLots);
            Assert.Equal(parkingLot2, parkingBoy.ManagedParkingLots[1]);
            Assert.Equal(parkingLot1, parkingBoy.ManagedParkingLots[0]);
        }

        // 1.  given a car to parking boy when car parking has empty space then get a ticket
        [Fact]
        void should_return_a_ticket_when_given_a_car_to_parking_boy()
        {
            var parkingBoy = new ParkingBoy(new List<ParkingLot>
            {
                new ParkingLot()
            });
            var ticket = parkingBoy.Park(new Car());
            Assert.NotNull(ticket);
        }

        // 2.  given a car to parking boy when car parking has empty space then park at the first space 
        [Fact]
        void should_park_car_at_first_empty_space()
        {
            var parkingLot1 = new ParkingLot();
            var parkingLot2 = new ParkingLot();
            var parkingBoy = new ParkingBoy(new List<ParkingLot>
            {
                parkingLot1,
                parkingLot2
            });
            for (var i = 0; i < parkingLotSize; i++)
            {
                parkingLot1.Park(new Car());
            }

            var car = new Car();
            var ticket = parkingBoy.Park(car);
            Assert.NotNull(ticket);
            Assert.Throws<Exception>(() => parkingLot1.GetCar(ticket));
            Assert.Equal(car, parkingLot2.GetCar(ticket));
        }
        // 3.  given a car to parking boy when a previously full parking lot now has empty space then park at the previous parking lot
        [Fact]
        void should_park_car_at_first_empty_space_if_previously_space_was_occupied_but_now_vacant()
        {
            var parkingLot1 = new ParkingLot();
            var parkingLot2 = new ParkingLot();
            var parkingBoy = new ParkingBoy(new List<ParkingLot>
            {
                parkingLot1,
                parkingLot2
            });
            object ticket;
            for (var i = 0; i < parkingLotSize - 1; i++)
            {
                parkingLot1.Park(new Car());
            }

            ticket = parkingLot1.Park(new Car());

            Assert.Throws<Exception>(() => parkingLot1.Park(new Car()));
            
            parkingLot1.GetCar(ticket);
            ticket = null;

            var car = new Car();
            ticket = parkingBoy.Park(car);
            Assert.NotNull(ticket);
            Assert.Throws<Exception>(() => parkingLot2.GetCar(ticket));
            Assert.Equal(car, parkingLot1.GetCar(ticket));
        }
        // 4.  given a car to parking boy when car parking has no empty space then get a message
        // 5.  given a car to parking boy when car parking has no empty space but not under his management paring lot has empty space then get a message
    }
}