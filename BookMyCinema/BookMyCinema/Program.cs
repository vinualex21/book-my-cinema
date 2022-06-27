// See https://aka.ms/new-console-template for more information
using BookMyCinema;
using BookMyCinema.Models;


var Seats = new List<Seat>();
const int NUMBER_OF_ROWS = 3;
const int SEATS_PER_ROW = 5;

char rowName = 'A';
Seat seat;
for (int i = 0; i < NUMBER_OF_ROWS; i++)
{
    for (int j = 1; j <= SEATS_PER_ROW; j++)
    {
        seat = new Seat(rowName, j);
        Seats.Add(seat);
    }
    rowName++;
}


TheatreManager theatreManager = new TheatreManager(Seats);

char choice;
do
{
    Console.WriteLine("***** Cinnamon Cinemas *****");
    Console.WriteLine("B. Book seats.");
    Console.WriteLine("Q. Quit.");
    Console.Write("Option: ");
    choice = Console.ReadKey().KeyChar;

    switch (char.ToUpper(choice))
    {
        case 'B':
            Console.Write("\nEnter number of seats: ");
            var seatCount = Console.ReadLine();
            if (Int32.TryParse(seatCount, out int numberOfSeats))
            {
                try
                {
                    var bookedSeats = theatreManager.BookSeats(numberOfSeats);
                    theatreManager.DisplayBookedSeats(bookedSeats);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
            break;

        case 'Q': return;

        default: break;

    }
    Console.Clear();

} while (char.ToLower(choice) != 'q');




