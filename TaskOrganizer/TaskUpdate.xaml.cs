using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using TaskOrganizer.Data_Layer;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TaskOrganizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaskUpdate : Page
    {
        Tuple<Task, List<Task>> tup;

        public TaskUpdate()
        {
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tup = (Tuple<Task,List<Task>>)e.Parameter;
            this.InitializeComponent();

            string[] stat = { "New", "In progress", "Finished" };
            statusBox.ItemsSource = stat;
            statusBox.SelectedIndex = statusBox.Items.IndexOf(tup.Item1.Status.ToString());
            noteBox.Text = tup.Item1.Note;


            //base.OnNavigatedTo(e);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tup.Item1.Status = statusBox.SelectedItem.ToString();
            tup.Item1.Note = noteBox.Text;
            postAPI(tup.Item1);
        }
        public async void postAPI(Task task)
        {
            try
            {
                Uri sUrl = new Uri(@"http://localhost:50157/api/tasks/post");
                System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
                //construct json
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(task);
                var content = new StringContent(json,Encoding.UTF8 ,"application/json");
                System.Net.Http.HttpRequestMessage request = new System.Net.Http.HttpRequestMessage
                {
                    Method = System.Net.Http.HttpMethod.Post,
                    RequestUri = sUrl,
                    Content = content
                };
                System.Net.Http.HttpResponseMessage response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var httpResponseBody = await response.Content.ReadAsStringAsync();

                Task ta = new Task(httpResponseBody);
                Task d = tup.Item2.Where(x => x.TaskId == ta.TaskId).Single();
                d.Status = ta.Status;
                d.Note = ta.Note;

                this.Frame.Navigate(typeof(TaskIndex), tup.Item2);
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine("\nException Message : " + e.InnerException.Message);
                
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TaskIndex), tup.Item2);
        }
    }
}
