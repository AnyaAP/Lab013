using System;
using System.Collections.Generic;
using System.Text;

namespace Lab013
{
    public class Train
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Railcars { get; set; }
        public string TrainType { get; set; }
        public Train() { }
        public Train(int id, string number, int railcars, string trainType)
        {
            Id = id;
            Number = number;
            Railcars = railcars;
            TrainType = trainType;
        }
    }
}
