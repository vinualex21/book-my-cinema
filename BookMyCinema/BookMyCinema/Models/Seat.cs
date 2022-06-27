using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyCinema.Models
{
    public class Seat
    {
        public char Row { get; set; }
        public int Number { get; set; }
        public SeatStatus Status { get; set; }

        public Seat(char row, int number, SeatStatus status = SeatStatus.Available)
        {
            Row = row;
            Number = number;
            Status = status;
        }
    }
}
