using FrontDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontDesk.Windows.Tasks
{
    /// <summary>
    /// Interaction logic for InsertTask.xaml
    /// </summary>
    public partial class TaskInsert : Window
    {
        HotelDbContext hotelContext = new HotelDbContext();
        public TaskInsert()
        {
            InitializeComponent();
            var rooms = hotelContext.Rooms.Select(x => x.RoomId).ToList();
            roomBox.ItemsSource = rooms;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task
            {
                RoomId = int.Parse(roomBox.SelectedItem.ToString()),
                Employee = employeeBox.Text,
                Status = statusBox.Text,
                Note = noteBox.Text
            };
            hotelContext.Tasks.Add(task);
            hotelContext.SaveChanges();
            TaskIndex.datagrid.ItemsSource = hotelContext.Tasks.ToList();
            this.Close();

        }
    }
}
