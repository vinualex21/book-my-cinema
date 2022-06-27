using BookMyCinema;
using NUnit.Framework;
using FluentAssertions;
using BookMyCinema.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BookMyCinemaTests
{
    public class TheatreManagerTest
    {
        private TheatreManager theatreManager;
        [SetUp]
        public void Setup()
        {
            theatreManager = new TheatreManager(new List<Seat>());
        }

        [Test]
        public void BookOneSeat_GivenAtLeastOneAvailableSeat_ShouldReturnOneSeatDetails()
        {
            theatreManager = new TheatreManager(InitializeSeats(3,5));
            var bookedSeat = theatreManager.BookSeats(1);
            
            bookedSeat.Should().NotBeNull();
            bookedSeat.Count.Should().Be(1);
        }

        [Test]
        public void BookThreeSeats_GivenOneAvailableSeat_ShouldReturnNull()
        {
            var seats = Enumerable.Range(1, 5).Select(x => new Seat('A',x,SeatStatus.Booked)).ToList();
            seats.AddRange(Enumerable.Range(1, 5).Select(x => new Seat('B', x, SeatStatus.Booked)));
            seats.AddRange(Enumerable.Range(1, 4).Select(x => new Seat('C', x, SeatStatus.Booked)));
            seats.Add(new Seat('C', 5, SeatStatus.Available));

            theatreManager = new TheatreManager(new List<Seat>());
            var bookedSeat = theatreManager.BookSeats(1);

            bookedSeat.Should().BeNull();
        }

        [Test]
        public void BookFourSeats_ShouldThrowException()
        {
            theatreManager = new TheatreManager(new List<Seat>());

            theatreManager.Invoking(y => y.BookSeats(4))
                    .Should().Throw<ArgumentException>()
                    .WithMessage("Maximum 3 seats allowed in one booking. Please try again.");

        }

        [Test]
        public void BookSeats_GivenInvalidInput_ShouldThrowException()
        {
            theatreManager = new TheatreManager(new List<Seat>());

            theatreManager.Invoking(y => y.BookSeats(-2))
                    .Should().Throw<ArgumentException>()
                    .WithMessage("Invalid input. Please try again.");

        }

        private List<Seat> InitializeSeats(int numberOfRows, int seatsPerRow)
        {
            var Seats = new List<Seat>();

            char rowName = 'A';
            Seat seat;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 1; j <= seatsPerRow; j++)
                {
                    seat = new Seat(rowName, j);
                    Seats.Add(seat);
                }
                rowName++;
            }
            return Seats;
        }
    }
}