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
    /// Interaction logic for BookingInsex.xaml
    /// </summary>
    public partial class BookingIndex : Window
    {
        HotelDbContext hotelContext = new HotelDbContext();
        public static DataGrid datagrid;
        public BookingIndex()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            myDataGrid.ItemsSource = hotelContext.Bookings.ToList();
            datagrid = myDataGrid;
        }
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            BookingInsert insert = new BookingInsert();
            insert.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Booking).BookingId;
            BookingUpdate update = new BookingUpdate(Id);
            update.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Booking).BookingId;
            var deleteBooking = hotelContext.Bookings.Where(b => b.BookingId == Id).Single();
            hotelContext.Bookings.Remove(deleteBooking);
            hotelContext.SaveChanges();
            myDataGrid.ItemsSource = hotelContext.Bookings.ToList();
        }
    }
}
