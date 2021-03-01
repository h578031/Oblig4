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
    public sealed partial class TaskDetail : Page
    {
        Tuple<Task, List<Task>> tup;
        public TaskDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tup = (Tuple<Task, List<Task>>)e.Parameter;
            this.InitializeComponent();

            taskTxt.Text = tup.Item1.TaskId.ToString();
            roomTxt.Text = tup.Item1.RoomId.ToString();
            empTxt.Text = tup.Item1.Employee;
            statTxt.Text = tup.Item1.Status;
            noteTxt.Text = tup.Item1.Note;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TaskIndex),tup.Item2);
        }
    }
}
