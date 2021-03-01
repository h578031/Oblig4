using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TaskOrganizer.Data_Layer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TaskOrganizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskIndex : Page
    {
        public List<Data_Layer.Task> Tasks;
        public TaskIndex()
        {
            this.InitializeComponent();
            TaskList.ItemsSource = Tasks;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Tasks = (List<Data_Layer.Task>)e.Parameter;
            this.InitializeComponent();
            TaskList.ItemsSource = Tasks;
            //base.OnNavigatedTo(e);
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Task t = btn.DataContext as Task;
            Tuple<Task, List<Task>> tup = new Tuple<Task, List<Task>>(t, Tasks);
            this.Frame.Navigate(typeof(TaskUpdate), tup);
        }
        private void detailBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Task t = btn.DataContext as Task;
            Tuple<Task, List<Task>> tup = new Tuple<Task, List<Task>>(t, Tasks);
            this.Frame.Navigate(typeof(TaskDetail), tup);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
