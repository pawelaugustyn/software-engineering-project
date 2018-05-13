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
                            ProjectColor = (string)reader[2],
                            //TeamId = (int)reader[3]
                        });
                    }
                }
            }

            return projects;
        }


    }
}

