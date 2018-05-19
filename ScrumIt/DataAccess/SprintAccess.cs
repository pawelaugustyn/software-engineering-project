using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class SprintAccess
    {
        public static SprintModel GetSprintById(int sprintid)
        {
            SprintModel sprint = new SprintModel();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from sprints where sprint_id = @sprintid;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("sprintid", sprintid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sprint = new SprintModel((int)reader[0], (int)reader[1], (string)reader[2], (string)reader[3]);
                        break;
                    }
                }
            }

            return sprint;
        }

        public static SprintModel GetSprintByProjectIdAndDate(int projectid, DateTime time)
        {
            SprintModel sprint = new SprintModel();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from sprints where project_id = @projectid and sprint_start < @datestart and sprint_end > @dateend;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectid);
                string datetime = time.ToString("yyyy-MM-dd hh:mm:ss");
                cmd.Parameters.AddWithValue("datestart", datetime);
                cmd.Parameters.AddWithValue("dateend", datetime);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sprint = new SprintModel((int)reader[0], (int)reader[1], (string)reader[2], (string)reader[3]);
                        break;
                    }
                }
            }

            return sprint;
        }
    }
}
