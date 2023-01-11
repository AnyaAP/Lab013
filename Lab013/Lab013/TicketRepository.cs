using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Lab013
{
    public class TicketRepository
    {
        static readonly string connectionString =
            "Server=LAPTOP-K1MUDVF5;Database=Railway012;Trusted_Connection=True;";
        public IEnumerable<Ticket> GetTickets()
        {
            List<Ticket> items = new List<Ticket>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Tickets", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        int passId = (int)reader.GetValue(1);
                        int trainId = (int)reader.GetValue(2);
                        int railcar = (int)reader.GetValue(3);
                        int seat = (int)reader.GetValue(4);
                        string startPlace = Convert.ToString(reader.GetValue(5));
                        string finalPlace = Convert.ToString(reader.GetValue(6));
                        DateTime startDate = Convert.ToDateTime(reader.GetValue(7));
                        DateTime finalDate = Convert.ToDateTime(reader.GetValue(8));
                        Ticket ticket = new Ticket(id,passId,trainId,railcar,seat,startPlace,finalPlace,startDate,finalDate);
                        items.Add(ticket);
                    }
                }
            }
            return items;
        }
        public Ticket GetTicket(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Tickets WHERE Id = " + Id + "", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        int passId = (int)reader.GetValue(1);
                        int trainId = (int)reader.GetValue(2);
                        int railcar = (int)reader.GetValue(3);
                        int seat = (int)reader.GetValue(4);
                        string startPlace = Convert.ToString(reader.GetValue(5));
                        string finalPlace = Convert.ToString(reader.GetValue(6));
                        DateTime startDate = Convert.ToDateTime(reader.GetValue(7));
                        DateTime finalDate = Convert.ToDateTime(reader.GetValue(8));
                        Ticket ticket = new Ticket(id, passId, trainId, railcar, seat, startPlace, finalPlace, startDate, finalDate);
                        return ticket;
                    }
                }
            }
            return null;
        }
        public int DeleteTicket(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE Tickets WHERE Id = " + id + "", connection);
                return command.ExecuteNonQuery();
            }
        }
        public int SaveTicket(Ticket ticket)
        {
            if (ticket.Id != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Tickets SET" +
                        "PassId=" + ticket.PassId + ", TrainId=" + ticket.TrainId + ", " +
                        "Railcar=" + ticket.Railcar + ", Seat=" + ticket.Seat + ", " +
                        "StartPlace='" + ticket.StartPlace + "', FinalPlace='" + ticket.FinalPlace + "', " +
                        "StartDate='" + ticket.StartDate + "', FinalDate='" + ticket.FinalDate + "' " +
                        "WHERE Id = " + ticket.Id + "", connection);
                    return command.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO " +
                        "Tickets (Id, PassId, TrainId, Railcar, Seat, StartPlace, FinalPlace, StartDate, FinalDate)" +
                        "VALUES (" + ticket.Id + ", " + ticket.PassId + ", " + ticket.TrainId + ", "
                        + ticket.Railcar + ", " + ticket.Seat + ", '" + ticket.StartPlace + "', '"
                        + ticket.FinalPlace + "', '" + ticket.StartDate + "', '" + ticket.FinalDate + "' )"
                        , connection);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
