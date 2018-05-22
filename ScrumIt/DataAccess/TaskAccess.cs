using System;
using System.Collections.Generic;
using Npgsql;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class TaskAccess
    {
        public static List<TaskModel> GetProjectTasksByProjectId(int projectid)
        {
            var tasks = new List<TaskModel>();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select tsk.* from tasks tsk join sprints spr using(sprint_id) where spr.project_id = @projectid order by spr.sprint_id;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        tasks.Add(new TaskModel
                        {
                            TaskId = (int)reader[0],
                            SprintId = (int)reader[1],
                            TaskType = (string)reader[2],
                            TaskName = (string)reader[3],
                            TaskDesc = (string)reader[4],
                            TaskPriority = (int)reader[5],
                            TaskEstimatedTime = (int)reader[6],
                            TaskStage = (TaskModel.TaskStages)reader[7],

                        });

                    }
                }
            }

            return tasks;
        }

        public static TaskModel GetTaskById(int taskid)
        {
            var task = new TaskModel();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand(
                    "select * from tasks where task_id = @taskid;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("taskid", taskid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        task = new TaskModel
                        {
                            TaskId = (int)reader[0],
                            SprintId = (int)reader[1],
                            TaskType = (string)reader[2],
                            TaskName = (string)reader[3],
                            TaskDesc = (string)reader[4],
                            TaskPriority = (int)reader[5],
                            TaskEstimatedTime = (int)reader[6],
                            TaskStage = (TaskModel.TaskStages)reader[7],

                        };
                        break;
                    }
                }
            }

            return task;
        }
        //zaktualizuj w bazie dane zadanie nadajac mu nowy stage (przeciagniecia miedzy kolumnami w sprincie)
        public static bool UpdateTaskStage(int taskid, TaskModel.TaskStages newstage)
        {
            //dzieki using nie musimy martwic sie o rzucanie wyjatkow i nie zamkniecie polaczenia - using to ogarnie za nas
            using (var conn = new Connection())
            {

                var cmd = new NpgsqlCommand("update tasks SET task_stage=@newstage where task_id = @taskid;")
                {
                    Connection = conn.Conn
                };
                var newstageInt = (int) newstage;
                cmd.Parameters.AddWithValue("newstage", newstageInt);
                cmd.Parameters.AddWithValue("taskid", taskid);
                //if one record was affected then it went as expected. If not, we didnt manage to find the task
                var howManyAffected = cmd.ExecuteNonQuery();
                if (howManyAffected == 1)
                    return true;
                throw new Exception("Task not found");                
            }
        }

        public static List<TaskModel> GetProjectTasksBySprintId(int sprintid)
        {
            var tasks = new List<TaskModel>();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select tsk.* from tasks tsk where tsk.sprint_id = @sprintid order by tsk.sprint_id;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("sprintid", sprintid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        tasks.Add(new TaskModel
                        {
                            TaskId = (int)reader[0],
                            SprintId = (int)reader[1],
                            TaskType = (string)reader[2],
                            TaskName = (string)reader[3],
                            TaskDesc = (string)reader[4],
                            TaskPriority = (int)reader[5],
                            TaskEstimatedTime = (int)reader[6],
                            TaskStage = (TaskModel.TaskStages)reader[7],

                        });

                    }
                }
            }

            return tasks;
        }

        public static bool CreateNewTask(ref TaskModel addedTask, List<UserModel> usersAssignedToTask)
        {
            ValidateNewTask(ref addedTask);
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("INSERT INTO tasks (task_id, sprint_id, task_name, task_desc, task_priority, task_estimated_time, task_stage)" +
                                            "VALUES (DEFAULT, @sprint_id, @task_name, @task_desc, @task_priority, @task_estimated_time, @task_stage);")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", addedTask.SprintId);
                cmd.Parameters.AddWithValue("task_name", addedTask.TaskName);
                cmd.Parameters.AddWithValue("task_desc", addedTask.TaskDesc);
                cmd.Parameters.AddWithValue("task_priority", addedTask.TaskPriority);
                cmd.Parameters.AddWithValue("task_estimated_time", addedTask.TaskEstimatedTime);
                cmd.Parameters.AddWithValue("task_stage", (int)addedTask.TaskStage);
                cmd.ExecuteNonQuery();
                
                cmd = new NpgsqlCommand("SELECT task_id FROM tasks ORDER BY task_id DESC LIMIT 1;")
                {
                    Connection = conn.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addedTask.TaskId = (int) reader[0];
                        break;
                    }
                }
                // metoda dopisujaca liste uzytkownikow do zadania
            }

            return true;
        }

        private static void ValidateNewTask(ref TaskModel addedTask)
        {
            ValidateTaskName(ref addedTask);
            ValidateTaskPriority(ref addedTask);
            ValidateTaskEstimatedTime(ref addedTask);
        }

        private static void ValidateTaskName(ref TaskModel addedTask)
        {
            if (addedTask.TaskName.Length == 0)
                throw new ArgumentException("Task name cannot be empty!");
        }

        private static void ValidateTaskPriority(ref TaskModel addedTask)
        {
            if (addedTask.TaskPriority < 0 || addedTask.TaskPriority > 100) 
                throw new ArgumentException("Task priority must be between 0 and 100.");
        }

        private static void ValidateTaskEstimatedTime(ref TaskModel addedTask)
        {
            if (addedTask.TaskEstimatedTime < 0)
                throw new ArgumentException("Estimated time cannot be lower than zero!");
        }
    }
}