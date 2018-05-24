using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class UserAccess
    {
        public static UserModel LoginAs(string username, string password)
        {
            var currentUser = new UserModel();
            // W ten sposob robimy polaczenie z baza danych
            // korzystajac z using zapewniamy, ze wychodzac z tego bloku
            // wywolamy metode Dispose z klasy Connection, czyli
            // zamkniemy poprawnie polaczenie
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where username=@username and pass=@pass limit 1;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("username", username.ToLower());
                cmd.Parameters.AddWithValue("pass", EncryptMd5(password));
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currentUser = new UserModel
                        {
                            UserId = (int)reader[0],
                            Username = (string)reader[1],
                            Firstname = (string)reader[3],
                            Lastname = (string)reader[4],
                            Role = (UserRoles)reader[5],
                            Email = (string)reader[6]
                        };
                        break;
                    }
                }
            }
            return currentUser;
        }

        public static UserModel GetUserById(int userid)
        {
            var user = new UserModel();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where uid=@uid limit 1;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("uid", userid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new UserModel
                        {
                            UserId = (int)reader[0],
                            Username = (string)reader[1],
                            Firstname = (string)reader[3],
                            Lastname = (string)reader[4],
                            Role = (UserRoles)reader[5],
                            Email = (string)reader[6]
                        };
                        break;
                    }
                }
            }

            return user;
        }

        public static List<UserModel> GetUsersByLastName(string lastname)
        {
            var users = new List<UserModel>();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where lower(lastname) like @lastname;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("lastname", lastname.ToLower() + '%');
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UserModel
                        {
                            UserId = (int)reader[0],
                            Username = (string)reader[1],
                            Firstname = (string)reader[3],
                            Lastname = (string)reader[4],
                            Role = (UserRoles)reader[5],
                            Email = (string)reader[6]
                        });
                    }
                }
            }

            return users;
        }

        public static UserModel GetUserByLogin(string login)
        {
            var user = new UserModel();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where lower(login) like @login limit 1;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("login", login.ToLower() + '%');
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new UserModel
                        {
                            UserId = (int)reader[0],
                            Username = (string)reader[1],
                            Firstname = (string)reader[3],
                            Lastname = (string)reader[4],
                            Role = (UserRoles)reader[5],
                            Email = (string)reader[6]
                        };
                        break;
                    }
                }
            }

            return user;
        }

        public static List<UserModel> GetUsersByProjectId(int projectid)
        {
            var users = new List<UserModel>();
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select b.* from projects_has_users a join users b using(uid) where a.project_id = @projectid order by b.uid;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("projectid", projectid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new UserModel
                        {
                            UserId = (int)reader[0],
                            Username = (string)reader[1],
                            Firstname = (string)reader[3],
                            Lastname = (string)reader[4],
                            Role = (UserRoles)reader[5],
                            Email = (string)reader[6]
                        });
                    }
                }
            }

            return users;
        }

        public static string SetUserToTask(int user_id, int task_id)
        {
            bool task_with_provided_id_exists = false;
            using (var db_connection = new Connection())
            {
                //To check, if a task with provided ID exists in the DB. Maybe unnecessary?
                var db_query_to_execute = new NpgsqlCommand("select * from tasks where task_id = @task_id")
                {
                    Connection = db_connection.Conn
                };

                db_query_to_execute.Parameters.AddWithValue("task_id", task_id);

                using (var query_result = db_query_to_execute.ExecuteReader())
                {
                    if (query_result.Read())
                    {
                        task_with_provided_id_exists = true;
                    }
                }

                if (task_with_provided_id_exists)
                {
                    //TODO: What should be the value of time_spent field in the database?? 0 by default?
                    db_query_to_execute.CommandText = "insert into tasks_assigned_users values(@task_id, @user_id, 0)";
                    db_query_to_execute.Parameters.AddWithValue("task_id", task_id);
                    db_query_to_execute.Parameters.AddWithValue("user_id", user_id);

                    using (var query_result = db_query_to_execute.ExecuteReader())
                    {
                        return "User successfully set to task.";
                    }
                }
                return "ERROR: Provided task does not exist in the database.";
            }
        }

        public static string RemoveUserFromTask(int user_id, int task_id)
        {
            using (var db_connection = new Connection())
            {
                var db_query_to_execute =
                    new NpgsqlCommand("delete from tasks_assigned_users where task_id=@task_id and uid=@user_id")
                    {
                        Connection = db_connection.Conn
                    };

                db_query_to_execute.Parameters.AddWithValue("task_id", task_id);
                db_query_to_execute.Parameters.AddWithValue("user_id", user_id);

                using (var query_result = db_query_to_execute.ExecuteReader())
                {
                    return "User deleted from task.";
                }
            }
        }

        public static string SetUserToProject(int user_id, int project_id)
        {
            bool project_with_provided_id_exists = false;
            using (var db_connection = new Connection())
            {
                //To check, if a project with provided ID exists in the DB. Maybe unnecessary?
                var db_query_to_execute = new NpgsqlCommand("select * from projects where project_id = @project_id")
                {
                    Connection = db_connection.Conn
                };

                db_query_to_execute.Parameters.AddWithValue("project_id", project_id);

                using (var query_result = db_query_to_execute.ExecuteReader())
                {
                    if (query_result.Read())
                    {
                        project_with_provided_id_exists = true;
                    }
                }

                if (project_with_provided_id_exists)
                {
                    db_query_to_execute.CommandText = "insert into projects_has_users values(@user_id, @project_id)";
                    db_query_to_execute.Parameters.AddWithValue("project_id", project_id);
                    db_query_to_execute.Parameters.AddWithValue("user_id", user_id);

                    using (var query_result = db_query_to_execute.ExecuteReader())
                    {
                        return "User successfully set to project.";
                    }
                }
                return "ERROR: Provided project does not exist in the database.";
            }
        }

        public static string RemoveUserFromProject(int user_id, int project_id)
        {
            using (var db_connection = new Connection())
            {
                var db_query_to_execute =
                    new NpgsqlCommand("delete from projects_has_users where project_id=@project_id and uid=@user_id")
                    {
                        Connection = db_connection.Conn
                    };

                db_query_to_execute.Parameters.AddWithValue("project_id", project_id);
                db_query_to_execute.Parameters.AddWithValue("user_id", user_id);

                using (var query_result = db_query_to_execute.ExecuteReader())
                {
                    return "User deleted from project.";
                }
            }
        }

        private static string EncryptMd5(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var character in hash)
            {
                sb.Append(character.ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }
}
