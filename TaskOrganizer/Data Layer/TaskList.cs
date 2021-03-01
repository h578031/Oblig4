using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOrganizer.Data_Layer
{
    public class TaskList : ObservableCollection<Task>
    {
        public TaskList()
        {
        }
        public Task GetTaskById(int id)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].TaskId == id)
                {
                    return Items[i];
                }
            }
            return null;
        }
    }
}
