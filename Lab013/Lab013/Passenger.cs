using System;
using System.Collections.Generic;
using System.Text;

namespace Lab013
{
    public class Passenger
    {
        public int Id { get; set; }
        public string PassName { get; set; }
        public int Passport { get; set; }
        public Passenger() { }
        public Passenger(int id, string passName, int passport)
        {
            Id = id;
            PassName = passName;
            Passport = passport;
        }
    }
}
