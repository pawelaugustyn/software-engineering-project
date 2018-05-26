﻿using System.Collections.Generic;
using ScrumIt.DataAccess;

namespace ScrumIt.Models
{
    class TaskModel
    {
        public int TaskId { get; set; } = 0;
        public int SprintId { get; set; }
        public string TaskType{ get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public int TaskPriority { get; set; }
        public int TaskEstimatedTime { get; set; }
        public TaskStages TaskStage { get; set; }
        public string TaskColor { get; set; }

        public enum TaskStages
        {
            ToDo = 1,
            Doing = 2,
            Completed = 3
        }

        public static TaskModel GetTaskById(int taskid)
        {
            return TaskAccess.GetTaskById(taskid);
        }
 
        public static TaskModel GetTaskByName(string taskname)
        {
            return new TaskModel();
            //return TaskAccess.GetTaskByName(taskname);
        }
 
        public static List<TaskModel> GetTasksByPriority(int priority)
        {
            return new List<TaskModel>();
            //return TaskAccess.GetTasksByPriority(priority);
        }
 
        public static List<TaskModel> GetTasksByStage(int stage)
        {
            return new List<TaskModel>();
            //return TaskAccess.GetTasksByStage(stage);
        }

        public static List<TaskModel> GetTasksBySprintId(int sprintid)
        {
            //return new List<TaskModel>();
            return TaskAccess.GetProjectTasksBySprintId(sprintid);
        }

        public static bool CreateNewTask(TaskModel taskToAdd, List<UserModel> usersAssignedToTask)
        {
            return TaskAccess.CreateNewTask(taskToAdd, usersAssignedToTask);
        }

        public static bool SetNewColour(TaskModel task, string colour)
        {
            return TaskAccess.SetNewColour(task, colour);
        }
    }
}
