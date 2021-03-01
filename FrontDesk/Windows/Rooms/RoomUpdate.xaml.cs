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
//using FrontDesk.Model;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class RoomUpdate : Window
    {
        //MvcBookingContext1Context _db = new MvcBookingContext1Context();
        HotelDbContext hotelContext = new HotelDbContext();
        int Id;
        public RoomUpdate(int roomId)
        {
            InitializeComponent();
            Id = roomId;
            Room updatedRoom = hotelContext.Rooms
                .Where(r => r.RoomId == Id).Single();
            numBeds.Text = updatedRoom.Beds.ToString();
            qualitybox.Text = updatedRoom.Quality;
            maxPrice.Text = updatedRoom.Price.ToString();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Room updatedRoom = hotelContext.Rooms
                .Where(r => r.RoomId == Id).Single();

            updatedRoom.Beds = int.Parse(numBeds.Text);
            updatedRoom.Quality = qualitybox.Text;
            updatedRoom.Price = Decimal.Parse(maxPrice.Text);


            hotelContext.SaveChanges();
            RoomIndex.datagrid.ItemsSource = hotelContext.Rooms.ToList();
            this.Close();


        }
    }
}
