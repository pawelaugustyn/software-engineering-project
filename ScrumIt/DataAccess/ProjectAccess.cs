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
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from projects;")
                {
                    Connection = Connection.Conn
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
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select proj.* from projects proj join projects_has_users proj_users using(project_id) where proj_users.uid = @userid order by proj.project_id;")
                {
                    Connection = Connection.Conn
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
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from projects where project_id = @projectid;")
                {
                    Connection = Connection.Conn
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

        public static ProjectModel GetProjectByName(string projectname)
        {
            var project = new ProjectModel();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from projects where project_name = @projectname;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectname", projectname);
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

        public static bool CreateNewProject(ProjectModel addedProject)
        {
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Not permitted for that operation.");
            ValidateNewProject(addedProject);

            using (new Connection())
            {
                var cmd = new NpgsqlCommand("INSERT INTO projects VALUES (DEFAULT, @pname, @pcolor);")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("pname", addedProject.ProjectName);
                cmd.Parameters.AddWithValue("pcolor", addedProject.ProjectColor);
                cmd.ExecuteNonQuery();

                cmd = new NpgsqlCommand("SELECT project_id FROM projects ORDER BY project_id DESC LIMIT 1;")
                {
                    Connection = Connection.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addedProject.ProjectId = (int)reader[0];
                        break;
                    }
                }

                cmd = new NpgsqlCommand("INSERT INTO projects_has_users VALUES(@uid, @projid);")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("uid", AppStateProvider.Instance.CurrentUser.UserId);
                cmd.Parameters.AddWithValue("projid", addedProject.ProjectId);
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static bool DeleteProject(ProjectModel deletedProject)
        {
            //usuwanie kaskadowe?
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Not permitted for that operation.");

            //
            // wywolac metody dla projects_has_users, tasks i sprints lub poczekac na zmiany w bazie
            //
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("DELETE FROM projects WHERE project_id=@projectid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", deletedProject.ProjectId);
                var result = cmd.ExecuteNonQuery();
                if (result != 1) return false;
                

            }
            return true;
        }

        public static bool UpdateProject(ProjectModel updatedProject)
        {
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Not permitted for that operation.");

            ValidateUpdatedProject(updatedProject);
            var nameIsDifferent = false;
            using (new Connection())
            {
                //sprawdzamy czy zmienila sie nazwa projektu , jesli tak, to spradzamy czy nowa nazwa nie jest taka sama jak nazwa innego isteniejacego juz projektu
                var cmd = new NpgsqlCommand("SELECT project_name FROM projects WHERE project_id = @projectid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", updatedProject.ProjectId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (updatedProject.ProjectName != (string)reader[0])
                            nameIsDifferent = true;
                    }
                }
            }

            if (nameIsDifferent)
                ValidateProjectNameIsAvailable(updatedProject.ProjectName);
            // aktualizowanie w bazie
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE projects SET project_name = @name, project_color = @color WHERE project_id = @id ;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("name", updatedProject.ProjectName);
                cmd.Parameters.AddWithValue("color", updatedProject.ProjectColor);
                cmd.Parameters.AddWithValue("id", updatedProject.ProjectId);
                var result = cmd.ExecuteNonQuery();
                if (result != 1) return false;
            }

            return true;
        }

        public static bool AddNewUserToProject(int userId, int projectId)
        {
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Not permitted for that operation.");

            using (new Connection())
            {
                var cmd = new NpgsqlCommand("SELECT uid FROM projects_has_users WHERE project_id=@projectid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if ( userId == (int)reader[0])
                            throw new ArgumentException("This user is already assigned to project");
                    }
                }

                cmd = new NpgsqlCommand("INSERT INTO projects_has_users VALUES(@userid, @projectid);")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("userid", userId);
                cmd.Parameters.AddWithValue("projectid", projectId);
                var result = cmd.ExecuteNonQuery();
                if (result != 1) return false;
            }

            return true;
        }

        private static void ValidateNewProject(ProjectModel proj)
        {
            ValidateProjectNameOnCreation(proj.ProjectName);
            ValidateProjectColour(proj.ProjectColor);
        }

        private static void ValidateUpdatedProject(ProjectModel proj)
        {
            ValidateProjectNameContainsOnlyAllowableCharacters(proj.ProjectName);
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
            if (!new Regex(@"^[a-zA-Z0-9()-. ]+$").IsMatch(name))
                throw new ArgumentException("Project name contains not allowed characters.");
        }

        private static void ValidateProjectColour(string colour)
        {
            if (!new Regex(@"^#[a-fA-F0-9]{6}").IsMatch(colour))
                throw new ArgumentException("Provided string is not an RGB colour.");
        }
    }
}

