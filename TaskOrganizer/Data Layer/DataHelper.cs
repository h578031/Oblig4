using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOrganizer.Data_Layer;

namespace TaskOrganizer
{
    class DataHelper
    {



        public static RoomList GetRooms(string connectionString)
        {
            const string GetRoomsQuery = "SELECT * FROM ROOM";

            var rooms = new RoomList();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetRoomsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var room = new Room();
                                    room.Id = reader.GetInt32(0);
                                    room.Beds = reader.GetInt32(1);
                                    room.AvailableTo = reader.GetDateTime(2);
                                    room.Quality = reader.GetString(3);
                                    room.Price = reader.GetDecimal(4);
                                    room.Clean = reader.GetString(5);
                                    Console.WriteLine(room.Beds);
                                    rooms.Add(room);
                                }
                            }
                        }
                    }
                }
                return rooms;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
