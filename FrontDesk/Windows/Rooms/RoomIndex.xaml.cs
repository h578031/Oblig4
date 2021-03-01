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

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for RoomIndex.xaml
    /// </summary>
    public partial class RoomIndex : Window
    {

        HotelDbContext hotelContext = new HotelDbContext();
        public static DataGrid datagrid;

        public RoomIndex()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = hotelContext.Rooms.ToList();
            datagrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            RoomInsert insert = new RoomInsert();
            insert.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Room).RoomId;
            RoomUpdate update = new RoomUpdate(Id);
            update.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Room).RoomId;
            var deleteRoom = hotelContext.Rooms.Where(r => r.RoomId == Id).Single();
            hotelContext.Rooms.Remove(deleteRoom);
            hotelContext.SaveChanges();
            myDataGrid.ItemsSource = hotelContext.Rooms.ToList();
        }
    }
}
