using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Lab013
{
    public class TrainRepository
    {
        static string connectionString =
            "Server=LAPTOP-K1MUDVF5;Database=Railway012;Trusted_Connection=True;";
        public IEnumerable<Train> GetTrains()
        {
            List<Train> items = new List<Train>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Trains", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string number = Convert.ToString(reader.GetValue(1));
                        int railcars = (int)reader.GetValue(2);
                        string trainType = Convert.ToString(reader.GetValue(3));
                        Train train = new Train(id, number, railcars,trainType);
                        items.Add(train);
                    }
                }
            }
            return items;
        }
        public Train GetTrain(int Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Trains WHERE Id = " + Id + "", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader.GetValue(0);
                        string number = Convert.ToString(reader.GetValue(1));
                        int railcars = (int)reader.GetValue(2);
                        string trainType = Convert.ToString(reader.GetValue(3));
                        Train train = new Train(id, number, railcars, trainType);
                        return train;
                    }
                }
            }
            return null;
        }
        public int DeleteTrain(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE Trains WHERE Id = " + id + "", connection);
                return command.ExecuteNonQuery();
            }
        }
        public int SaveTrain(Train train)
        {
            if (train.Id != 0)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE Trains SET" +
                        "Number='" + train.Number + "', Railcars=" + train.Railcars + ", " +
                        "TrainType='" + train.TrainType + "' WHERE Id = " + train.Id + "", connection);
                    return command.ExecuteNonQuery();
                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO " +
                        "Trains (Id, Number, Railcars, TrainType)" +
                        "VALUES (" + train.Id + ", '" + train.Number + "', " + train.Railcars + ", '"
                        + train.TrainType + "')"
                        , connection);
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
