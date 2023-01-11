using System;
using System.Collections.Generic;
using System.Text;

namespace Lab013
{
    public class Ticket
    {
        public int Id { get; set; }
        public int PassId { get; set; }
        public int TrainId { get; set; }
        public int Railcar { get; set; }
        public int Seat { get; set; }
        public string StartPlace { get; set; }
        public string FinalPlace { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public Ticket() { }
        public Ticket(int id, int passId, int trainId, int railcar, int seat, string startPlace, string finalPlace, DateTime startDate, DateTime finalDate)
        {
            Id = id;
            PassId = passId;
            TrainId = trainId;
            Railcar = railcar;
            Seat = seat;
            StartPlace = startPlace;
            FinalPlace = finalPlace;
            StartDate = startDate;
            FinalDate = finalDate;
        }
    }
}
