//using FrontDesk.Model;
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
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class RoomInsert : Window
    {
        //MvcBookingContext1Context _db = new MvcBookingContext1Context();
        HotelDbContext hotelContext = new HotelDbContext();
        public RoomInsert()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Room room = new Room()
            {
                Beds = int.Parse(numBeds.Text),
                Quality = qualitybox.Text,
                Price = Decimal.Parse(maxPrice.Text),
            };
            hotelContext.Rooms.Add(room);
            hotelContext.SaveChanges();
            RoomIndex.datagrid.ItemsSource = hotelContext.Rooms.ToList();
            this.Close();
        }
    }
}
