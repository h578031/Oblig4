using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace TaskOrganizer
{
    public class Room : INotifyPropertyChanged
    {
     
        public Room()
        {
        }
        public Room(string json)
        {
            JsonObject jsonObject = JsonObject.Parse(json);

            Id = int.Parse(jsonObject["id"].ToString());
            Beds = int.Parse(jsonObject["beds"].ToString());
            AvailableTo = DateTime.Parse(jsonObject["availableTo"].GetString());            
            Quality = jsonObject["quality"].ToString();
            Price = Decimal.Parse(jsonObject["price"].ToString());
            Clean = jsonObject["clean"].ToString();


        }
        public int Id { get; set; }
        public int Beds { get; set; }
        public DateTime AvailableTo { get; set; }
        public string Quality { get; set; }
        public decimal Price { get; set; }
        public string Clean { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }

    }

}
