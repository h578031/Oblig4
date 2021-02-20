using FrontDesk.Model;
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
        MvcBookingContext1Context _db = new MvcBookingContext1Context();
        public static DataGrid datagrid;
        
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = _db.Rooms.ToList();
            datagrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            Insert insert = new Insert();
            insert.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Room).Id;
            Update update = new Update(Id);
            update.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Room).Id;
            var deleteRoom = _db.Rooms.Where(r => r.Id == Id).Single();
            _db.Rooms.Remove(deleteRoom);
            _db.SaveChanges();
            myDataGrid.ItemsSource = _db.Rooms.ToList();
        }
    }
}
