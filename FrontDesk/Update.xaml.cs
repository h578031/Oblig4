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
using FrontDesk.Model;
using System.Linq;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        MvcBookingContext1Context _db = new MvcBookingContext1Context();
        int Id;
        public Update(int roomId)
        {
            InitializeComponent();
            Id = roomId;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Room updatedRoom = _db.Rooms
                .Where(r => r.Id == Id).Single();

            updatedRoom.Beds = int.Parse(numBeds.Text);
            updatedRoom.AvailableTo = (DateTime)dateRoom.SelectedDate;
            updatedRoom.Quality = qualitybox.Text;
            updatedRoom.Price = Decimal.Parse(maxPrice.Text);

            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Rooms.ToList();
            this.Close();

         
        }
    }
}
