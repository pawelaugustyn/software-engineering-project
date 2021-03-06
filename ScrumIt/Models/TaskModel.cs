﻿using System.Collections.Generic;
using ScrumIt.DataAccess;

namespace ScrumIt.Models
{
    class TaskModel
    {
        public int TaskId { get; set; } = 0;
        public int SprintId { get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public int TaskPriority { get; set; }
        public int TaskEstimatedTime { get; set; }
        public TaskStages TaskStage { get; set; }
        public string TaskColor { get; set; }
        public int BacklogProjectId { get; set; }
        public List<UserModel> UsersAssignedToTask { get; set; }

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

        public static List<TaskModel> GetTasksBySprintId(int sprintid)
        {
            //return new List<TaskModel>();
            return TaskAccess.GetProjectTasksBySprintId(sprintid);
        }

        public static List<TaskModel> GetProjectBacklogTasks(int projectid)
        {
            return TaskAccess.GetProjectBacklogTasks(projectid);
        }

        public static bool CreateNewTask(TaskModel taskToAdd, List<UserModel> usersAssignedToTask)
        {
            return TaskAccess.CreateNewTask(taskToAdd, usersAssignedToTask);
        }

        public static bool SetNewColour(TaskModel task, string colour)
        {
            return TaskAccess.SetNewColour(task, colour);
        }

        public static bool UpdateTaskStage(int taskid, TaskStages newstage)
        {
            return TaskAccess.UpdateTaskStage(taskid, newstage);
        }

        public static void AssignFromBacklogToSprint(int taskid, int sprintId)
        {
            TaskAccess.AssignFromBacklogToSprint(taskid, sprintId);
        }

        public static void RemoveTask(int taskid)
        {
            TaskAccess.RemoveTask(taskid);
        }

        public static void AssignUsersToTask(TaskModel taskToAssignTo, IEnumerable<int> usersIdsToAssign)
        {
            TaskAccess.AssignUsersToTask(taskToAssignTo, usersIdsToAssign);
        }

        public static bool UpdateTask(TaskModel task)
        {
            return TaskAccess.UpdateTask(task);
        }
    }
}
