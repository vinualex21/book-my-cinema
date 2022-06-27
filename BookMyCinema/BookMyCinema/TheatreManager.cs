using BookMyCinema.Models;

namespace BookMyCinema
{
    public class TheatreManager
    {
        public List<Seat> Seats;
        public TheatreManager(List<Seat> seats)
        {
            Seats = seats;
        }

        public List<Seat> BookSeats(int numberOfSeats)
        {
            if(numberOfSeats <= 0)
                throw new ArgumentException("Invalid input. Please try again.");
            if (numberOfSeats > 3)
                throw new ArgumentException("Maximum 3 seats allowed in one booking. Please try again.");

            var availableSeats = Seats.SkipWhile(seat => seat.Status == SeatStatus.Booked).ToList();
            if (availableSeats.Count() == 0)
                Console.WriteLine("Sorry! No seats available.");

            if(availableSeats.Count >= numberOfSeats)
            {
                availableSeats.Take(numberOfSeats).Select(seat => seat.Status = SeatStatus.Booked).ToList();
                return availableSeats.Take(numberOfSeats).ToList();
            }
            Console.WriteLine($"The requested number of seats are not available. Remaining available seats: {availableSeats.Count()}");
            return null;

        }

        public void DisplayBookedSeats(List<Seat> bookedSeats)
        {
            if (bookedSeats != null && bookedSeats.Any())
            {
                Console.Write($"{(bookedSeats.Count() > 1 ? "Seats" : "Seat")} booked: ");
                foreach (var seat in bookedSeats)
                    Console.Write($"{seat.Row}{seat.Number} ");
            }
        }
    }
}