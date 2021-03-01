using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TaskOrganizer.Data_Layer;

namespace TaskOrganizer
{
    class DataHelper
    {
        public static TaskList GetRooms(string connectionString)
        {
            const string GetTasksQuery = "SELECT * FROM TASK";

            var tasks = new TaskList();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetTasksQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var task = new Task();
                                    task.TaskId = reader.GetInt32(0);
                                    task.RoomId = reader.GetInt32(1);
                                    task.Employee = reader.GetString(2);
                                    task.Note = reader.GetString(3);
                                    task.Status = reader.GetString(4);
                                    tasks.Add(task);
                                }
                            }
                        }
                    }
                }
                return tasks;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
