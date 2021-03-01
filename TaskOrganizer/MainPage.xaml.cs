using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TaskOrganizer.Data_Layer;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TaskOrganizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public TaskList Tasks { get; set; }
        public List<Data_Layer.Task> tList { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            readAPI();

            


        }


        public async void readAPI()
        {
            try
            {
                Uri sUrl = new Uri(@"http://localhost:50157/api/tasks/taskinfo");
                HttpClient httpClient = new HttpClient();
                string sResponse = await httpClient.GetStringAsync(sUrl);
                List<Data_Layer.Task> tasks = new List<Data_Layer.Task>();
                JsonArray jsonArray = JsonArray.Parse(sResponse);
                foreach (var jsonRow in jsonArray)
                {
                    Data_Layer.Task task = new Data_Layer.Task(jsonRow.ToString());
                    tasks.Add(task);
                }
                tList = tasks;
            }
            catch(HttpRequestException e)
            {
                Debug.WriteLine("\nException Message : " + e.InnerException.Message);
            }

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            List<Data_Layer.Task> list = tList;
            Button btn = (Button)sender;
            if(btn.Name.Equals("mBtn"))
            {
                List<Data_Layer.Task> employeeTasks = tList.Where(x => x.Employee.Contains("Maintainer")).ToList();
                this.Frame.Navigate(typeof(TaskIndex),employeeTasks);
            }
            else if (btn.Name.Equals("cBtn"))
            {
                List<Data_Layer.Task> employeeTasks = tList.Where(x => x.Employee.Contains("Cleaner")).ToList();
                this.Frame.Navigate(typeof(TaskIndex), employeeTasks);
            }
            else if (btn.Name.Equals("sBtn"))
            {
                List<Data_Layer.Task> employeeTasks = tList.Where(x => x.Employee.Contains("Service")).ToList();
                this.Frame.Navigate(typeof(TaskIndex), employeeTasks);
            }
            else
            {
                Debug.WriteLine("No button was registred");
            }
              
        }
    }
}
