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
                var cmd = new NpgsqlCommand("select tsk.task_id, tsk.sprint_id, tsk.task_name, tsk.task_desc, tsk.task_priority, tsk.task_estimated_time, tsk.task_stage, tsk.task_color, tsk.project_id from tasks tsk join projects pr using(project_id) where pr.project_id = @projectid order by pr.project_id;")
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
                            TaskName = (string)reader[2],
                            TaskDesc = reader[3] != DBNull.Value ? (string)reader[3] : "",
                            TaskPriority = (int)reader[4],
                            TaskEstimatedTime = (int)reader[5],
                            TaskStage = (TaskModel.TaskStages)reader[6],
                            TaskColor = reader[7] != DBNull.Value ? (string)reader[7] : "#ffffff",
                            BacklogProjectId = reader[8] == DBNull.Value ? 0 : (int)reader[8]
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
                    "select task_id, sprint_id, task_name, task_desc, task_priority, task_estimated_time, task_stage, task_color, project_id from tasks where task_id = @taskid;")
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
                            TaskName = (string)reader[2],
                            TaskDesc = reader[3] != DBNull.Value ? (string)reader[3] : "",
                            TaskPriority = (int)reader[4],
                            TaskEstimatedTime = (int)reader[5],
                            TaskStage = (TaskModel.TaskStages)reader[6],
                            TaskColor = reader[7] != DBNull.Value ? (string)reader[7] : "#ffffff",
                            BacklogProjectId = reader[8] == DBNull.Value ? 0 : (int)reader[8]
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
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
            using (new Connection())
            {

                var cmd = new NpgsqlCommand("update tasks SET task_stage=@newstage where task_id = @taskid and task_stage <> @newstage ;")
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
                else return false;
            }
        }

        public static List<TaskModel> GetProjectTasksBySprintId(int sprintid)
        {
            var tasks = new List<TaskModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select tsk.task_id, tsk.sprint_id, tsk.task_name, tsk.task_desc, tsk.task_priority, tsk.task_estimated_time, tsk.task_stage, tsk.task_color, tsk.project_id from tasks tsk where tsk.sprint_id = @sprintid order by tsk.task_id;")
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
                            SprintId = reader[1] == DBNull.Value ? 0 : (int)reader[1],
                            TaskName = (string)reader[2],
                            TaskDesc = reader[3] != DBNull.Value ? (string)reader[3] : "",
                            TaskPriority = (int)reader[4],
                            TaskEstimatedTime = (int)reader[5],
                            TaskStage = (TaskModel.TaskStages)reader[6],
                            TaskColor = reader[7] != DBNull.Value ? (string)reader[7] : "#ffffff",
                            BacklogProjectId = reader[8] == DBNull.Value ? 0 : (int)reader[8]
                        });

                    }
                }

                foreach (var task in tasks)
                {
                    task.UsersAssignedToTask = UserAccess.GetUsersByTaskId(task.TaskId);
                }
            }

            return tasks;
        }

        public static List<TaskModel> GetProjectBacklogTasks(int projectId)
        {
            var tasks = new List<TaskModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select tsk.task_id, tsk.sprint_id, tsk.task_name, tsk.task_desc, tsk.task_priority, tsk.task_estimated_time, tsk.task_stage, tsk.task_color, tsk.project_id from tasks tsk where tsk.project_id = @projectid and tsk.sprint_id is null order by tsk.task_id;")
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
                            TaskName = (string)reader[2],
                            TaskDesc = reader[3] != DBNull.Value ? (string)reader[3] : "",
                            TaskPriority = (int)reader[4],
                            TaskEstimatedTime = (int)reader[5],
                            TaskStage = (TaskModel.TaskStages)reader[6],
                            TaskColor = reader[7] != DBNull.Value ? (string)reader[7] : "#ffffff",
                            BacklogProjectId = reader[8] == DBNull.Value ? 0 : (int)reader[8]
                        });

                    }
                }
            }

            return tasks;
        }

        public static bool CreateNewTask(TaskModel addedTask, List<UserModel> usersAssignedToTask = null)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
            ValidateNewTask(addedTask);
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("INSERT INTO tasks (task_id, sprint_id, task_name, task_desc, task_priority, task_estimated_time, task_stage, task_color, project_id)" +
                                            "VALUES (DEFAULT, @sprint_id, @task_name, @task_desc, @task_priority, @task_estimated_time, @task_stage, @task_color, @project_id);")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", addedTask.SprintId != 0 ? (IConvertible)addedTask.SprintId : DBNull.Value);
                cmd.Parameters.AddWithValue("task_name", addedTask.TaskName);
                cmd.Parameters.AddWithValue("task_desc", addedTask.TaskDesc);
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

        public static bool AssignUsersToTask(TaskModel taskToAssignTo, List<UserModel> usersToAssign)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
            var usersToAdd = usersToAssign.Select(o => o.UserId).ToList().Distinct();

            return AssignUsersToTask(taskToAssignTo, usersToAdd);
        }

        public static bool AssignUsersToTask(TaskModel taskToAssignTo, IEnumerable<int> usersIdsToAssign)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
            using (new Connection())
            {
                DeassignUsersFromTask(taskToAssignTo.TaskId);

                foreach (var userId in usersIdsToAssign)
                {
                    var cmd = new NpgsqlCommand("INSERT INTO tasks_assigned_users VALUES (@task_id, @uid, 0);")
                    {
                        Connection = Connection.Conn
                    };

                    cmd.Parameters.AddWithValue("task_id", taskToAssignTo.TaskId);
                    cmd.Parameters.AddWithValue("uid", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public static bool AssignFromBacklogToSprint(int taskid, int sprintId)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE tasks SET sprint_id = @sprint_id WHERE task_id = @task_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("sprint_id", sprintId != 0 ? (IConvertible)sprintId : DBNull.Value);
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
                return true;
            }
        }

        private static void DeassignUsersFromTask(int taskid)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
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
        // new
        public static void DeassignUserFromProjectTasks(int projectid, List<UserModel> users)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
            using (new Connection())
            {
                foreach (var user in users)
                {
                    var cmd = new NpgsqlCommand("delete from tasks_assigned_users where uid = @userId and task_id in (select t.task_id from tasks t join sprints s using (sprint_id) where s.project_id = @projectId);")
                    {
                        Connection = Connection.Conn
                    };
                    cmd.Parameters.AddWithValue("projectId", projectid);
                    cmd.Parameters.AddWithValue("userId", user.UserId);
                    cmd.ExecuteNonQuery();
                   
                }
            }
        }
        //
        public static void RemoveTask(int taskid)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
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
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new ArgumentException("Brak uprawnien.");
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

        public static bool UpdateTask(TaskModel task)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new UnauthorizedAccessException("Brak uprawnien.");
            ValidateUpdatedTask(task);
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE tasks SET task_name=@name, task_desc=@desc, task_priority=@priority, task_estimated_time=@estimatedtime WHERE task_id=@id")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("id", task.TaskId);
                cmd.Parameters.AddWithValue("estimatedtime", task.TaskEstimatedTime);
                cmd.Parameters.AddWithValue("name", task.TaskName);
                cmd.Parameters.AddWithValue("priority", task.TaskPriority);
                cmd.Parameters.AddWithValue("desc", task.TaskDesc);

                var result = cmd.ExecuteNonQuery();
                if (result != 1) return false;
            }
            return true;
        }

        private static void ValidateNewTask(TaskModel addedTask)
        {
            ValidateTaskName(addedTask.TaskName);
            ValidateTaskPriority(addedTask.TaskPriority);
            ValidateTaskEstimatedTime(addedTask.TaskEstimatedTime);
            ValidateTaskColor(addedTask.TaskColor);
            ValidateTaskAssignment(addedTask.BacklogProjectId);
        }

        private static void ValidateUpdatedTask(TaskModel updatedTask)
        {
            ValidateTaskName(updatedTask.TaskName);
            ValidateTaskPriority(updatedTask.TaskPriority);
            ValidateTaskEstimatedTime(updatedTask.TaskEstimatedTime);
        }

        private static void ValidateTaskName(string taskName)
        {
            if (string.IsNullOrEmpty(taskName))
                throw new ArgumentException("Nazwa zadania nie może być pusta!");
        }

        private static void ValidateTaskPriority(int taskPriority)
        {
            if (taskPriority < 0 || taskPriority > 100)
                throw new ArgumentException("Priorytet zadania musi zawierać się pomiędzy 0 a 100.");
        }

        private static void ValidateTaskEstimatedTime(int estimatedTime)
        {
            if (estimatedTime < 0 || estimatedTime > 100)
                throw new ArgumentException("Szacowany czas musi zawierać się pomiędzy 0 a 100.");
        }

        private static void ValidateTaskColor(string colour)
        {
            if (!new Regex(@"^#[a-fA-F0-9]{6}").IsMatch(colour))
                throw new ArgumentException("Nie podano prawidłowego oznaczenia RGB koloru.");
        }

        private static void ValidateTaskAssignment(int backlogProjectId)
        {
            if (backlogProjectId == 0)
                throw new ArgumentException("Zadanie musi być przypisane bezposrednio do projektu!");
        }
    }
}
