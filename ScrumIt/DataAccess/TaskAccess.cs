using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using ScrumIt.Models;
using ScrumIt.Forms;

namespace ScrumIt.DataAccess
{
    internal class TaskAccess
    {
        public static List<TaskModel> GetProjectTasksByProjectId(int projectid)
        {
            var tasks = new List<TaskModel>();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand(
                    "select tsk.* from tasks tsk join sprints spr using(sprint_id) where spr.project_id = @projectid order by spr.sprint_id;")
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
                            TaskId = (int) reader[0],
                            SprintId = (int) reader[1],
                            TaskType = (string) reader[2],
                            TaskName = (string) reader[3],
                            TaskDesc = (string) reader[4],
                            TaskPriority = (int) reader[5],
                            TaskEstimatedTime = (int) reader[6],
                            TaskStage = (int) reader[7],

                        });

                    }
                }
            }

            return tasks;
        }


        public static List<TaskModel> GetTasksFromCurrentSprint(int project_id)
        {
            var tasks = new List<TaskModel>();
            var current_sprint_id = SprintAccess.GetCurrentSprint(project_id).SprintId;

            using (var db_connection = new Connection())
            {
                var db_query_to_execute = new NpgsqlCommand("select * from tasks where sprint_id = @sprint_id;")
                {
                    Connection = db_connection.Conn
                };

                db_query_to_execute.Parameters.AddWithValue("sprint_id", current_sprint_id);

                using (var reader = db_query_to_execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskModel
                        {
                            TaskId = (int) reader[0],
                            SprintId = (int) reader[1],
                            TaskType = (string) reader[2],
                            TaskName = (string) reader[3],
                            TaskDesc = (string) reader[4],
                            TaskPriority = (int) reader[5],
                            TaskEstimatedTime = (int) reader[6],
                            TaskStage = (int) reader[7],
                        });
                    }
                }
            }

            return tasks;
        }
    }
}

