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

namespace FrontDesk.Windows.Tasks
{
    /// <summary>
    /// Interaction logic for TaskIndex.xaml
    /// </summary>
    
    public partial class TaskIndex : Window
    {
        HotelDbContext hotelContext = new HotelDbContext();
        public static DataGrid datagrid;
        public TaskIndex()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            myDataGrid.ItemsSource = hotelContext.Tasks.ToList();
            datagrid = myDataGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            TaskInsert insert = new TaskInsert();
            insert.ShowDialog();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Task).TaskId;
            TaskUpdate update = new TaskUpdate(Id);
            update.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int Id = (myDataGrid.SelectedItem as Task).TaskId;
            var deleteTask = hotelContext.Tasks.Where(t => t.TaskId == Id).Single();
            hotelContext.Tasks.Remove(deleteTask);
            hotelContext.SaveChanges();
            myDataGrid.ItemsSource = hotelContext.Tasks.ToList();
        }
    }
}
