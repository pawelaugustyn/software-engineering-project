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
        //bedzie List<ProjectModel> zamiast void
        public static void GetAllProjects()
        {
            //var projects = new List<ProjectModel>();
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
                        //projects.Add(new ProjectModel
                        //{
                        //    pole = (rzutowanie)reader[indeks],
                        //});
                    }
                }
            }

            //return projects;
        }


    }
}

