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
                            SprintId = reader[1] == DBNull.Value ? 0 : (int)reader[1],
                            TaskType = (string)reader[2],
                            TaskName = (string)reader[3],
                            TaskDesc = reader[4] != DBNull.Value ? (string)reader[4] : "",
                            TaskPriority = (int)reader[5],
                            TaskEstimatedTime = (int)reader[6],
                            TaskStage = (TaskModel.TaskStages)reader[7],
                            TaskColor = reader[8] != DBNull.Value ? (string)reader[8] : "#ffffff",
                            BacklogProjectId = reader[9] == DBNull.Value ? 0 : (int)reader[9]
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
                            SprintId = reader[1] == DBNull.Value ? 0 : (int)reader[1],
                            TaskType = (string)reader[2],
                            TaskName = (string)reader[3],
                            TaskDesc = reader[4] != DBNull.Value ? (string)reader[4] : "",
                            TaskPriority = (int)reader[5],
                            TaskEstimatedTime = (int)reader[6],
                            TaskStage = (TaskModel.TaskStages)reader[7],
                            TaskColor = reader[8] != DBNull.Value ? (string)reader[8] : "#ffffff",
                            BacklogProjectId = reader[9] == DBNull.Value ? 0 : (int)reader[9]
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
                var newstageInt = (int)newstage;
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
                var cmd = new NpgsqlCommand("select tsk.* from tasks tsk where tsk.sprint_id = @sprintid order by tsk.task_id;")
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
                            SprintId = reader[1] == DBNull.Value ? 0 : (int) reader[1],
                            TaskType = (string)reader[2],
                            TaskName = (string)reader[3],
                            TaskDesc = reader[4] != DBNull.Value ? (string)reader[4] : "",
                            TaskPriority = (int)reader[5],
                            TaskEstimatedTime = (int)reader[6],
                            TaskStage = (TaskModel.TaskStages)reader[7],
                            TaskColor = reader[8] != DBNull.Value ? (string)reader[8] : "#ffffff",
                            BacklogProjectId = reader[9] == DBNull.Value ? 0 : (int) reader[9]
                        });

                    }
                }
            }

            return tasks;
        }

        public static List<TaskModel> GetProjectBacklogTasks(int projectId)
        {
            var tasks = new List<TaskModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select tsk.* from tasks tsk where tsk.project_id = @projectid and tsk.sprint_id = 0 order by tsk.task_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        tasks.Add(new TaskModel
                        {
                            TaskId = (int)reader[0],
                            SprintId = reader[1] == DBNull.Value ? 0 : (int)reader[1],
                            TaskType = (string)reader[2],
                            TaskName = (string)reader[3],
                            TaskDesc = reader[4] != DBNull.Value ? (string)reader[4] : "",
                            TaskPriority = (int)reader[5],
                            TaskEstimatedTime = (int)reader[6],
                            TaskStage = (TaskModel.TaskStages)reader[7],
                            TaskColor = reader[8] != DBNull.Value ? (string)reader[8] : "#ffffff",
                            BacklogProjectId = reader[9] == DBNull.Value ? 0 : (int)reader[9]
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
                var cmd = new NpgsqlCommand("INSERT INTO tasks (task_id, sprint_id, task_name, task_desc, task_type, task_priority, task_estimated_time, task_stage, task_color, project_id)" +
                                            "VALUES (DEFAULT, @sprint_id, @task_name, @task_desc,@task_type, @task_priority, @task_estimated_time, @task_stage, @task_color, @project_id);")
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
                cmd.Parameters.AddWithValue("project_id", addedTask.BacklogProjectId);
                cmd.ExecuteNonQuery();

                cmd = new NpgsqlCommand("SELECT task_id FROM tasks ORDER BY task_id DESC LIMIT 1;")
                {
                    Connection = Connection.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addedTask.TaskId = (int)reader[0];
                        break;
                    }
                }

                if (usersAssignedToTask != null && usersAssignedToTask.Count != 0)
                    AssignUsersToTask(addedTask, usersAssignedToTask);
            }

            return true;
        }

        public static void AssignUsersToTask(TaskModel taskToAssignTo, List<UserModel> usersToAssign)
        {
            using (new Connection())
            {
                // TODO
                // Delete only these who you want to get rid of
                var cmd = new NpgsqlCommand("DELETE FROM tasks_assigned_users WHERE task_id = @task_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("task_id", taskToAssignTo.TaskId);
                cmd.ExecuteNonQuery();

                var usersToAdd = usersToAssign.Select(o => o.UserId).ToList().Distinct();
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
        }

        public static void AssignFromBacklogToSprint(int taskid, int sprintId)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE tasks SET sprint_id = @sprint_id, project_id = 0 WHERE task_id = @task_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", sprintId);
                cmd.Parameters.AddWithValue("task_id", taskid);
                try
                {
                    var res = cmd.ExecuteNonQuery();
                    if (res != 1)
                        throw new ArgumentException("Nie ma takiego zadania!");
                }
                catch (NpgsqlException)
                {
                    throw new ArgumentException("Sprint, do ktorego chcesz przypisac zadanie, nie istnieje!");
                }
            }
        }

        private static void DeassignUsersFromTask(int taskid)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("DELETE FROM tasks_assigned_users WHERE task_id = @task_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("task_id", taskid);
                cmd.ExecuteNonQuery();

            }
        }

        public static void RemoveTask(int taskid)
        {
            using (new Connection())
            {
                DeassignUsersFromTask(taskid);

                var cmd = new NpgsqlCommand("DELETE FROM tasks WHERE task_id = @task_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("task_id", taskid);
                cmd.ExecuteNonQuery();

            }
        }

        public static bool SetNewColour(TaskModel task, string colour)
        {
            ValidateTaskColor(colour);
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE tasks SET task_color = @task_color WHERE task_id = @task_id;")
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
            ValidateTaskAssignment(addedTask.BacklogProjectId, addedTask.SprintId);
        }

        private static void ValidateTaskName(string taskName)
        {
            if (string.IsNullOrEmpty(taskName))
                throw new ArgumentException("Nazwa zadania nie może być pusta!");
        }

        private static void ValidateTaskPriority(int taskPriority)
        {
            if (taskPriority < 1 || taskPriority > 100)
                throw new ArgumentException("Priorytet zadania musi zawierać się pomiędzy 1 a 100.");
        }

        private static void ValidateTaskEstimatedTime(int estimatedTime)
        {
            if (estimatedTime < 1 || estimatedTime > 100)
                throw new ArgumentException("Szacowany czas musi zawierać się pomiędzy 1 a 100.");
        }

        private static void ValidateTaskColor(string colour)
        {
            if (!new Regex(@"^#[a-fA-F0-9]{6}").IsMatch(colour))
                throw new ArgumentException("Nie podano prawidłowego oznaczenia RGB koloru.");
        }

        private static void ValidateTaskAssignment(int backlogProjectId, int sprintId)
        {
            if (backlogProjectId == 0 && sprintId == 0)
                throw new ArgumentException("Zadanie musi być przypisane do sprintu lub backlogu!");
        }
    }
}
