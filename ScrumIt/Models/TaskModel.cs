using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrumIt.DataAccess;

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
        public int SpirintId { get; set; }
 
 
        public static TaskModel GetTaskById(int taskid)
        {
            return new TaskModel();
        }
 
        public static TaskModel GetTaskByName(string taskname)
        {
            return new TaskModel();
        }
 
        public static List<TaskModel> GetTasksByPriority(int priority)
        {
            return new List<TaskModel>();
        }
 
        public static List<TaskModel> GetTasksByStage(int stage)
        {
            return new List<TaskModel>();
        }

        public static List<TaskModel> GetTasksBySprintId(int sprintid)
        {
            return new List<TaskModel>();
        }
    }
}
