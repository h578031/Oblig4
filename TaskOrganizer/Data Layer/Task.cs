using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace TaskOrganizer.Data_Layer
{
    public class Task : INotifyPropertyChanged
    {
        public int TaskId;
        public int RoomId;
        public string Employee;
        public string Note;
        public string Status;

        public Task()
        {
        }

        public Task(string json)
        {
            JsonObject jsonObject = JsonObject.Parse(json);
            Task task = (Task)JsonConvert.DeserializeObject<Task>(jsonObject.ToString());
            /*  TaskId = int.Parse(jsonObject["taskId"].ToString());
              RoomId = int.Parse(jsonObject["roomId"].ToString());
              Employee = jsonObject["employee"].ToString();
              Note = jsonObject["note"].ToString();
              Status = jsonObject["status"].ToString();*/
            TaskId = task.TaskId;
            RoomId = task.RoomId;
            Employee = task.Employee;
            Note = task.Note;
            Status = task.Status;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
