using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Mail;
using Npgsql;
using ScrumIt.Models;
using SmtpFailedRecipientException = System.Net.Mail.SmtpFailedRecipientException;

namespace ScrumIt.DataAccess
{
    internal class ProjectAccess
    {
        public static List<ProjectModel> GetAllProjects()
        {
            var projects = new List<ProjectModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from projects order by project_id;")
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

        public static ProjectModel GetProjectById(int projectid, bool exclusive = false)
        {
            var project = new ProjectModel();
            using (var c = new Connection(exclusive))
            {
                var cmd = new NpgsqlCommand("select * from projects where project_id = @projectid;")
                {
                    Connection = exclusive ? c.ConnExcl : Connection.Conn
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
                throw new UnauthorizedAccessException("Brak uprawnien.");
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
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Brak uprawnien.");

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
                throw new UnauthorizedAccessException("Brak uprawnien.");

            ValidateUpdatedProject(updatedProject);
            //sprawdzamy czy zmienila sie nazwa projektu, jesli tak, to spradzamy czy nowa nazwa nie jest taka sama jak nazwa innego isteniejacego juz projektu
            ProjectModel project = GetProjectById(updatedProject.ProjectId);
            if (project.ProjectName != updatedProject.ProjectName)
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
                throw new UnauthorizedAccessException("Brak uprawnien.");

            using (new Connection())
            {
                try
                {
                    var cmd = new NpgsqlCommand("INSERT INTO projects_has_users VALUES(@userid, @projectid);")
                    {
                        Connection = Connection.Conn
                    };
                    cmd.Parameters.AddWithValue("userid", userId);
                    cmd.Parameters.AddWithValue("projectid", projectId);
                    var result = cmd.ExecuteNonQuery();
                    if (result != 1) return false;
                }
                catch (NpgsqlException)
                {
                    throw new NpgsqlException("Uzytkownik juz jest przypisany do tego zadania");
                }
            }

            return true;
        }

        public static bool AssignUsersToProject(ProjectModel projectToAssignTo, List<UserModel> usersToAssign)
        {
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Brak uprawnien.");

            using (new Connection())
            {
                // wszyscy użytkownicy danego projektu przed zmianą
                var allAssignUsers = UserAccess.GetUsersByProjectId(projectToAssignTo.ProjectId);
                // id uzytkowników do przypisania
                //Contains nie dzialal na UserModel, moze da sie to jakos przerobic zeby ladniej wygladalo
                var idUsersToAssign = new List<int>();
                foreach (var user in usersToAssign)
                    idUsersToAssign.Add(user.UserId);
                //usunięci użytkownicy
                var deletedUsers = new List<UserModel>();
                foreach (var user in allAssignUsers)
                {
                    if (!idUsersToAssign.Contains(user.UserId))
                        deletedUsers.Add(user);
                }

                // usuwamy połączenie między zadaniami z danego projektu a usuniętymi użytkownikami
                TaskAccess.DeassignUserFromProjectTasks(projectToAssignTo.ProjectId, deletedUsers);

                var cmd = new NpgsqlCommand("DELETE FROM projects_has_users WHERE project_id = @project_id;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("project_id", projectToAssignTo.ProjectId);
                cmd.ExecuteNonQuery();

                var usersToAdd = usersToAssign.Select(o => o.UserId).ToList().Distinct();

                foreach (var userId in usersToAdd)
                {
                    cmd = new NpgsqlCommand("INSERT INTO projects_has_users (uid, project_id) VALUES (@uid, @project_id);")
                    {
                        Connection = Connection.Conn
                    };

                    cmd.Parameters.AddWithValue("uid", userId);
                    cmd.Parameters.AddWithValue("project_id", projectToAssignTo.ProjectId);
                    cmd.ExecuteNonQuery();
                }
            }
            
            return true;
        }

        public static bool NotifyUsersAboutEndOfSprint(int days_till_end)
        {
            List<SprintModel> ending_sprints = SprintAccess.GetNotNotifiedEndingSprints(days_till_end, true);
            List<UserModel> users_assigned_to_ending_sprints = new List<UserModel>();
            var parent_project = new ProjectModel();
            foreach (var sprint in ending_sprints)
            {
                users_assigned_to_ending_sprints = UserAccess.GetUsersByProjectId(sprint.ParentProjectId, true);
                parent_project = GetProjectById(sprint.ParentProjectId, true);
                
                foreach (var user in users_assigned_to_ending_sprints)
                {
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("io.appka@gmail.com");
                        mail.To.Add(user.Email);
                        mail.Subject = "ScrumIt Powiadomienie o końcu sprintu!";
                        mail.Body =
                            "Dzień dobry, " + user.Firstname +
                            ",\n\nchcielibyśmy Ci przypomnieć, że sprint, którego jesteś uczestnikiem w projekcie " +
                            parent_project.ProjectName + " dobiega końca " +
                            sprint.EndDateTime.ToString("yyyy/MM/dd") + ". \n\nPozdrawiamy, \nZespół ScrumIt.";
                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("io.appka", "ioioio123");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Send(mail);
                    }
                    catch (Exception)
                    {
                        // ignore
                    }

                }
                SprintAccess.ChangeEmailSentStatus(sprint.SprintId, true);
            }

            return true;

        }

        private static void ValidateNewProject(ProjectModel proj)
        {
            ValidateProjectNameOnCreation(proj.ProjectName);
            ValidateProjectColour(proj.ProjectColor);
            ValidateProjectColourUniqueness(proj.ProjectColor);
        }

        private static void ValidateUpdatedProject(ProjectModel proj)
        {
            ValidateProjectNameContainsOnlyAllowableCharacters(proj.ProjectName);
            ValidateProjectNameIsAvailable(proj.ProjectName, proj.ProjectId);
            ValidateProjectColour(proj.ProjectColor);
            ValidateProjectColourUniqueness(proj.ProjectColor, proj.ProjectId);
        }

        private static void ValidateProjectNameOnCreation(string name)
        {
            ValidateProjectNameContainsOnlyAllowableCharacters(name);
            ValidateProjectNameIsAvailable(name);
        }

        private static void ValidateProjectNameIsAvailable(string name, int projectId = 0)
        {
            var check = ProjectModel.GetProjectByName(name);
            if (check.ProjectName == name)
                if (projectId != 0 && check.ProjectId != projectId)
                    throw new ArgumentException("Projekt z ta nazwa juz istnieje.");
        }

        private static void ValidateProjectNameContainsOnlyAllowableCharacters(string name)
        {
            if (!new Regex(@"^[a-zA-Z0-9()-. ]+$").IsMatch(name))
                throw new ArgumentException("Nazwa projektu zawiera niedozwolone znaki.");
        }

        private static void ValidateProjectColour(string colour)
        {
            if (!new Regex(@"^#[a-fA-F0-9]{6}").IsMatch(colour))
                throw new ArgumentException("Zly format koloru (prawidlowy: #FFFFFF).");
        }

        private static void ValidateProjectColourUniqueness(string colour, int projectId = 0)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("SELECT project_id FROM projects WHERE project_id <> @project_id AND project_color = @project_color;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("project_id", projectId);
                cmd.Parameters.AddWithValue("project_color", colour);

                var res = (int?)cmd.ExecuteScalar();
                if (res != null && res > 0)
                    throw new ArgumentException("Wybrany kolor jest już przypisany do innego projektu");
            }
        }
    }
}

