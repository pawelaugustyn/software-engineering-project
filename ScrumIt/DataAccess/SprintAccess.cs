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


        public static SprintModel GetCurrentSprint(int project_id)
        {
            SprintModel current_sprint = new SprintModel();

            using (var db_connection = new Connection())
            {
                var db_query_to_execute = new NpgsqlCommand("select * from sprints where project_id = @project_id and sprint_end > now() order by sprint_start desc limit 1;")
                {
                    Connection = db_connection.Conn
                };

                db_query_to_execute.Parameters.AddWithValue("project_id", project_id);

                using (var query_result = db_query_to_execute.ExecuteReader())
                {
                    while (query_result.Read())
                    {
                        current_sprint = new SprintModel((int)query_result[0], (int) query_result[1], (string)query_result[2], (string)query_result[3]);
                        break;
                    }
                }
            }

            return current_sprint;
        }

        public static List<SprintModel> GetAllSprintsInAProject(int project_id)
        {
            var sprints_in_project = new List<SprintModel>();

            using (var db_connection = new Connection())
            {
                var db_query_to_execute = new NpgsqlCommand("select * from sprints where project_id = @project_id order by sprint_start desc")
                {
                    Connection = db_connection.Conn
                };

                db_query_to_execute.Parameters.AddWithValue("project_id", project_id);

                using (var query_result = db_query_to_execute.ExecuteReader())
                {
                    while (query_result.Read())
                    {
                        sprints_in_project.Add(new SprintModel((int) query_result[0], (int) query_result[1],
                            (string) query_result[2], (string) query_result[3]));
                    }
                }
            }
            return sprints_in_project;
        }
    }
}