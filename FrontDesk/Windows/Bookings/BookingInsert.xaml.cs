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
    /// Interaction logic for BookingInsert.xaml
    /// </summary>
    public partial class BookingInsert : Window
    {
        HotelDbContext hotelContext = new HotelDbContext();

        public BookingInsert()
        {
            InitializeComponent();
            Load();
            //customer.ItemsSource = hotelContext.AspNetUsers.
        }
        private void Load()
        {
            var cust = from c in hotelContext.AspNetUsers select c.UserName;
            customer.ItemsSource = cust.ToList();
            var rooms = from r in hotelContext.Rooms select r.RoomId;
            room.ItemsSource = rooms.ToList();
        }
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var cu = (from c in hotelContext.AspNetUsers
                     where c.UserName == customer.SelectedItem
                     select c.Id).Single();
            Booking booking = new Booking
            {
                CustomerId = cu,
                RoomId = int.Parse(room.SelectedItem.ToString()),
                CheckIn = (DateTime)checkInBox.SelectedDate,
                CheckOut = (DateTime)checkOutBox.SelectedDate
            };
            hotelContext.Bookings.Add(booking);
            hotelContext.SaveChanges();
            BookingIndex.datagrid.ItemsSource = hotelContext.Bookings.ToList();
            this.Close();
        }
    }
}
