using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class TaskAccess
    {
        //bedzie List<TaskModel> zamaist void ale jeszcze ni mo
        public static void GetProjectTasksByProjectId(int projectid)
        {
            //var tasks = new List<TaskModel>();
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
                        /*tasks.Add(new TaskModel
                        {
                            pole = (rzutowanie)reader[indeks],
                        });
                        */
                    }
                }
            }

            //return tasks;
        }
    }
}
