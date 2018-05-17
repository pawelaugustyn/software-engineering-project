using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class ProjectAccess
    {
        public static List<ProjectModel> GetAllProjects()
        {
            var projects = new List<ProjectModel>();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from projects;")
                {
                    Connection = conn.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projects.Add(new ProjectModel
                        {
                            ProjectId = (int)reader[0],
                            ProjectName = (string)reader[1],
                            ProjectColor = (string)reader[2]
                            //TeamId = (int)reader[3] //teams are now deleted / not in projects in DB
                        });
                    }
                }
            }

            return projects;
        }


        public static List<ProjectModel> GetProjectsByUserId(int userid)
        {
            var projects = new List<ProjectModel>();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select proj.* from projects proj join projects_has_users proj_users using(project_id) where proj_users.uid = @userid order by proj.project_id;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("userid", userid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        projects.Add(new ProjectModel
                        {
                            ProjectId = (int)reader[0],
                            ProjectName = (string)reader[1],
                            ProjectColor = (string)reader[2]
                            //TeamId = (int)reader[3] //teams are now deleted / not in projects in DB
                        });

                    }
                }
            }

            return projects;
        }



    }
}

