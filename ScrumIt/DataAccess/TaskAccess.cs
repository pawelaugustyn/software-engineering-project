using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Npgsql;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class TaskAccess
    {
        public static List<TaskModel> GetProjectTasksByProjectId(int projectid)
        {
            var tasks = new List<TaskModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select tsk.* from tasks tsk join sprints spr using(sprint_id) where spr.project_id = @projectid order by spr.sprint_id;")
                {
                    Connection = Connection.Conn
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
                            TaskColor = (string)reader[8]
                        });

                    }
                }
            }

            return tasks;
        }

        public static TaskModel GetTaskById(int taskid)
        {
            var task = new TaskModel();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand(
                    "select * from tasks where task_id = @taskid;")
                {
                    Connection = Connection.Conn
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
                            TaskColor = (string)reader[8]
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
            using (new Connection())
            {

                var cmd = new NpgsqlCommand("update tasks SET task_stage=@newstage where task_id = @taskid;")
                {
                    Connection = Connection.Conn
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
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select tsk.* from tasks tsk where tsk.sprint_id = @sprintid order by tsk.sprint_id;")
                {
                    Connection = Connection.Conn
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
                            TaskColor = (string)reader[8]

                        });

                    }
                }
            }

            return tasks;
        }

        public static bool CreateNewTask(TaskModel addedTask, List<UserModel> usersAssignedToTask = null)
        {
            // TODO
            // Check permissions for creating new task in that project
            ValidateNewTask(addedTask);
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("INSERT INTO tasks (task_id, sprint_id, task_name, task_desc, task_type, task_priority, task_estimated_time, task_stage, task_color)" +
                                            "VALUES (DEFAULT, @sprint_id, @task_name, @task_desc,@task_type, @task_priority, @task_estimated_time, @task_stage, @task_color);")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", addedTask.SprintId);
                cmd.Parameters.AddWithValue("task_name", addedTask.TaskName);
                cmd.Parameters.AddWithValue("task_desc", addedTask.TaskDesc);
                cmd.Parameters.AddWithValue("task_type", addedTask.TaskType);
                cmd.Parameters.AddWithValue("task_priority", addedTask.TaskPriority);
                cmd.Parameters.AddWithValue("task_estimated_time", addedTask.TaskEstimatedTime);
                cmd.Parameters.AddWithValue("task_stage", (int)addedTask.TaskStage);
                cmd.Parameters.AddWithValue("task_color", addedTask.TaskColor);
                cmd.ExecuteNonQuery();
                
                cmd = new NpgsqlCommand("SELECT task_id FROM tasks ORDER BY task_id DESC LIMIT 1;")
                {
                    Connection = Connection.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addedTask.TaskId = (int) reader[0];
                        break;
                    }
                }

                if (usersAssignedToTask != null)
                    AssignUsersToTask(addedTask, usersAssignedToTask);
            }

            return true;
        }

        public static bool AssignUsersToTask(TaskModel taskToAssignTo, List<UserModel> usersToAssign)
        {
            using (new Connection())
            {
                // TODO
                // Delete only these who you want to get rid of
                var cmd = new NpgsqlCommand("DELETE FROM tasks_assigned_users WHERE task_id = @taskid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("task_id", taskToAssignTo.TaskId);
                cmd.ExecuteNonQuery();

                var usersToAdd = usersToAssign.Select(o=>o.UserId).ToList().Distinct();
                cmd = new NpgsqlCommand("INSERT INTO tasks_assigned_users VALUES (@task_id, @uid, 0);")
                {
                    Connection = Connection.Conn
                };
                foreach (var userId in usersToAdd)
                {
                    cmd.Parameters.AddWithValue("task_id", taskToAssignTo.TaskId);
                    cmd.Parameters.AddWithValue("uid", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public static bool SetNewColour(TaskModel task, string colour)
        {
            ValidateTaskColor(colour);
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE tasks SET task_color = @task_color WHERE task_id = @taskid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("task_color", colour);
                cmd.Parameters.AddWithValue("task_id", task.TaskId);
                var res = cmd.ExecuteNonQuery();
                if (res != 1) return false;
                task.TaskColor = colour;

                return true;
            }
        }

        private static void ValidateNewTask(TaskModel addedTask)
        {
            ValidateTaskName(addedTask.TaskName);
            ValidateTaskPriority(addedTask.TaskPriority);
            ValidateTaskEstimatedTime(addedTask.TaskEstimatedTime);
            ValidateTaskColor(addedTask.TaskColor);
        }

        private static void ValidateTaskName(string taskName)
        {
            if (taskName.Length == 0)
                throw new ArgumentException("Task name cannot be empty!");
        }

        private static void ValidateTaskPriority(int taskPriority)
        {
            if (taskPriority < 0 || taskPriority > 100) 
                throw new ArgumentException("Task priority must be between 0 and 100.");
        }

        private static void ValidateTaskEstimatedTime(int estimatedTime)
        {
            if (estimatedTime < 0)
                throw new ArgumentException("Estimated time cannot be lower than zero!");
        }

        private static void ValidateTaskColor(string colour)
        {
            if (!new Regex(@"^#[a-fA-F0-9]{6}").IsMatch(colour))
                throw new ArgumentException("Provided string is not an RGB colour.");
        }
    }
}