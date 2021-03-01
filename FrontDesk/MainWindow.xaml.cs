//using FrontDesk.Model;
using FrontDesk.Models;
using FrontDesk.Windows.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelDbContext hotelContext = new HotelDbContext();
        public static DataGrid datagrid;

        public MainWindow()
        {
            InitializeComponent();
/*            SolidColorBrush b = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#173f5f"));
            SolidColorBrush br = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#20639b"));
            SolidColorBrush bru = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3caea3"));
            SolidColorBrush gridCol = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f6d55c"));
            roomBtn.Background = b;
            roomBtn.FontSize = 50;
            bookingBtn.Background = br;
            bookingBtn.FontSize = 50;
            taskBtn.Background = bru;
            taskBtn.FontSize = 50;
            myGrid.Background = gridCol;*/

            //Load();
        }

        private void roomBtn_Click(object sender, RoutedEventArgs e)
        {
            RoomIndex roomIndex = new RoomIndex();
            roomIndex.ShowDialog();
        }

        private void bookingBtn_Click(object sender, RoutedEventArgs e)
        {
            BookingIndex bookingIndex = new BookingIndex();
            bookingIndex.ShowDialog();
        }

        private void taskBtn_Click(object sender, RoutedEventArgs e)
        {
            TaskIndex taskIndex = new TaskIndex();
            taskIndex.ShowDialog();
        }
    }
}
