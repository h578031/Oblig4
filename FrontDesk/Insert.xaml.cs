using FrontDesk.Model;
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
    public partial class Insert : Window
    {
        MvcBookingContext1Context _db = new MvcBookingContext1Context();
        public Insert()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            Room room = new Room()
            {
                Beds = int.Parse(numBeds.Text),
                AvailableTo = (DateTime)dateRoom.SelectedDate,
                Quality = qualitybox.Text,
                Price = Decimal.Parse(maxPrice.Text),
                Clean = cleanRoom.Name
            };
            _db.Rooms.Add(room);
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Rooms.ToList();
            this.Close();
        }
    }
}
