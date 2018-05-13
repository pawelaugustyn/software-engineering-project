using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumIt.Models
{
    class TaskModel
    {
        public int TaskId { get; set; } = 0;
        public string TaskType{ get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public int TaskPriority { get; set; }
        public int TaskEstimatedTime { get; set; }
        public int TaskStage { get; set; }
 
 
        public static TaskModel GetTaskById(int taskid)
        {
            return TaskAcces.GetTaskById(taskid);
        }
 
        public static TaskModel GetTaskByName(string taskname)
        {
            return TaskAcces.GetTaskByName(taskname);
        }
 
        public static List<TaskModel> GetTasksByPriority(int priority)
        {
            return TaskAccess.GetTasksByPriority(priority);
        }
 
        public static List<TaskModel> GetTasksByStage(int stage)
        {
            return TaskAccess.GetTasksByStage(stage);
        }
    }
}
