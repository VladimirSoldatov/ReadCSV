using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSV
{
    internal class SQLReader
    {
        public SQLReader()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "" +
                "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=aero;" +
                "Integrated Security=True;";
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string command = "" +
                "SELECT \r\n  " +
                "Format(Pass_in_trip.date, 'yyyy-MM-dd') as 'Дата вылета'\r\n" +
                ", Passenger.name as 'Имя клиента'\r\n" +
                ", Company.name as 'Название компании'\r\n" +
                ", Trip.plane as 'Модель самолета'\r\n, Trip.town_from  as 'Город вылета'\r\n" +
                ", Trip.town_to as 'Город прилета'\r\n, Pass_in_trip.place as 'Место пассажира'\r\n" +
                "FROM \r\n" +
                "Pass_in_trip\r\n" +
                "LEFT JOIN  Passenger ON Passenger.ID_psg = Pass_in_trip.ID_psg\r\n" +
                "LEFT JOIN Trip ON Trip.trip_no = Pass_in_trip.trip_no\r\n" +
                "LEFT JOIN Company ON Company.ID_comp = Trip.ID_comp";
            sqlCommand.CommandText = command;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<OneFly> myFlies = new List<OneFly>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] objects = new string[reader.FieldCount];
                    reader.GetValues(objects);
                    myFlies.Add(new OneFly(objects));

                }
            }
            GetData getData = new GetData(myFlies);
            getData.getfliesByDate("2005-10-01");

            sqlConnection.Close();
        }
    }
}
