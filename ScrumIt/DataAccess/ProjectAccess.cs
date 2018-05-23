using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Npgsql;
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
                        });

                    }
                }
            }

            return projects;
        }

        public static ProjectModel GetProjectById(int projectid)
        {
            var project = new ProjectModel();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from projects where project_id = @projectid;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        project = new ProjectModel
                        {
                            ProjectId = (int)reader[0],
                            ProjectName = (string)reader[1],
                            ProjectColor = (string)reader[2]
                        };
                        break;
                    }
                }
            }

            return project;
        }

        public static bool CreateNewProject(string projectName, string projectColour)
        {
            ValidateNewProject(new ProjectModel() {ProjectName = projectName, ProjectColor = projectColour});

            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("INSERT INTO projects VALUES (DEFAULT, @pname, @pcolor);")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("pname", projectName);
                cmd.Parameters.AddWithValue("pcolor", projectColour);
                cmd.ExecuteNonQuery();

                cmd = new NpgsqlCommand("SELECT project_id FROM projects ORDER BY project_id DESC LIMIT 1;")
                {
                    Connection = conn.Conn
                };
                var projid = 0;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        projid = (int)reader[0];
                        break;
                    }
                }

                cmd = new NpgsqlCommand("INSERT INTO projects_has_users VALUES(@uid, @projid);")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("uid", AppStateProvider.Instance.CurrentUser.UserId);
                cmd.Parameters.AddWithValue("projid", projid);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        private static void ValidateNewProject(ProjectModel proj)
        {
            ValidateProjectNameOnCreation(proj.ProjectName);
            ValidateProjectColour(proj.ProjectColor);
        }

        private static void ValidateProjectNameOnCreation(string name)
        {
            ValidateProjectNameContainsOnlyAllowableCharacters(name);
            ValidateProjectNameIsAvailable(name);
        }

        private static void ValidateProjectNameIsAvailable(string name)
        {
            if (ProjectModel.GetProjectByName(name).ProjectName == name)
                throw new ArgumentException("Project with that name already exists.");
        }

        private static void ValidateProjectNameContainsOnlyAllowableCharacters(string name)
        {
            if (!new Regex(@"^[a-zA-Z0-9-. ]+$").IsMatch(name))
                throw new ArgumentException("Project name contains not allowed characters.");
        }

        private static void ValidateProjectColour(string colour)
        {
            if (!new Regex(@"^#[a-fA-F0-9]{6}").IsMatch(colour))
                throw new ArgumentException("Provided string is not an RGB colour.");
        }

    }
}

