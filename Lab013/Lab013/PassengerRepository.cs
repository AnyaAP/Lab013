using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lab013
{
    public class PassengerRepository
    {
        static readonly string connectionString =
            "Server=LAPTOP-K1MUDVF5;Database=Railway012;Trusted_Connection=True;";
        public IEnumerable<Passenger> GetPassengers()
        {
            List<Passenger> items = new List<Passenger>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Passengers", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string passName = Convert.ToString(reader.GetValue(1));
                        int passport = (int)reader.GetValue(2);
                        Passenger passenger = new Passenger(id, passName, passport);
                        items.Add(passenger);
                    }
                }
            }
            return items;
        }
        public Passenger GetPassenger(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Passengers WHERE Id = " + Id + "", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string passName = Convert.ToString(reader.GetValue(1));
                        int passport = (int)reader.GetValue(2);
                        Passenger passenger = new Passenger(id, passName, passport);
                        return passenger;
                    }
                }
            }
            return null;
        }
        public int DeletePassenger(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE Passengers WHERE Id = " + id + "", connection);
                return command.ExecuteNonQuery();
            }
        }
        public int SavePassenger(Passenger passenger)
        {
            if (passenger.Id != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE passengers SET" +
                        "PassName='" + passenger.PassName + "', passport=" + passenger.Passport + " " +
                        "WHERE Id = " + passenger.Id + "", connection);
                    return command.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO " +
                        "Passengers (Id, PassName, Passport)" +
                        "VALUES (" + passenger.Id + ", '" + passenger.PassName + "', " + passenger.Passport + ")"
                        , connection);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
