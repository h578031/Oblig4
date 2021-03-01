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
    /// Interaction logic for TaskUpdate.xaml
    /// </summary>
    public partial class TaskUpdate : Window
    {
        HotelDbContext hotelContext = new HotelDbContext();
        int Id;
        Task task;
        public TaskUpdate(int taskId)
        {
            Id = taskId;
            InitializeComponent();
            task = hotelContext.Tasks
                .Where(x => x.TaskId == Id).Single();
            employeeBox.SelectedItem = task.Employee;
            statusBox.SelectedItem = task.Status;
            noteBox.Text = task.Note;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            task.Employee = employeeBox.SelectedItem.ToString();
            task.Status = statusBox.SelectedItem.ToString();
            task.Note = noteBox.Text;
            hotelContext.SaveChanges();
            TaskIndex.datagrid.ItemsSource = hotelContext.Tasks.ToList();
            this.Close();
        }
    }
}
