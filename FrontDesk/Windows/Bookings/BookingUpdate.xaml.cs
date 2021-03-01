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
    /// Interaction logic for BookingUpdate.xaml
    /// </summary>
    public partial class BookingUpdate : Window
    {
        HotelDbContext hotelContext = new HotelDbContext();
        int Id;
        Booking booking;
        public BookingUpdate(int bookingId)
        {
            InitializeComponent();
            Id = bookingId;
            booking = hotelContext.Bookings
                .Where(b => b.BookingId == Id).Single();
            var custName = (from c in hotelContext.AspNetUsers
                        where c.Id == booking.CustomerId
                        select c.UserName).Single();
            //Sets the options of customer and room comboboxes
            var cust = from c in hotelContext.AspNetUsers select c.UserName;
            customer.ItemsSource = cust.ToList();
            var rooms = from r in hotelContext.Rooms select r.RoomId;
            room.ItemsSource = rooms.ToList();
            //Sets combobox value to current
            customer.SelectedIndex = customer.Items.IndexOf(custName);
            room.SelectedIndex = room.Items.IndexOf(booking.RoomId);
            checkInBox.SelectedDate = booking.CheckIn;
            checkOutBox.SelectedDate = booking.CheckOut;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            var custId = (from c in hotelContext.AspNetUsers
                          where c.UserName == customer.SelectedItem
                          select c.Id).Single();
            booking.CustomerId = custId;
            booking.RoomId = int.Parse(room.SelectedItem.ToString());
            booking.CheckIn = (DateTime)checkInBox.SelectedDate;
            booking.CheckOut = (DateTime)checkOutBox.SelectedDate;

            hotelContext.SaveChanges();
            BookingIndex.datagrid.ItemsSource = hotelContext.Bookings.ToList();
            this.Close();
        }


                
    }
}
