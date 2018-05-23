using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Npgsql;
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
                var cmd = new NpgsqlCommand("select * from users where lower(username)=@username and pass=@pass limit 1;")
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
                var cmd = new NpgsqlCommand("select * from users where lower(last_name) like @lastname;")
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
                var cmd = new NpgsqlCommand("select * from users where lower(username) like @login limit 1;")
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

        public static bool Add(ref UserModel addedUser, string password)
        {
            ValidateUser(ref addedUser);

            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("INSERT INTO users VALUES (DEFAULT, @username, @pass, @first_name, @last_name, @role, @email);")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("username", addedUser.Username);
                cmd.Parameters.AddWithValue("pass", EncryptMd5(password));
                cmd.Parameters.AddWithValue("first_name", addedUser.Firstname);
                cmd.Parameters.AddWithValue("last_name", addedUser.Lastname);
                cmd.Parameters.AddWithValue("role", (int) addedUser.Role);
                cmd.Parameters.AddWithValue("email", addedUser.Email);
                cmd.ExecuteNonQuery();

                cmd = new NpgsqlCommand("SELECT uid FROM users ORDER BY uid DESC LIMIT 1;")
                {
                    Connection = conn.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        addedUser.UserId = (int)reader[0];
                        break;
                    }
                }
            }

            return true;
        }

        private static void ValidateUser(ref UserModel addedUser)
        {
            // TODO
            // validate added user
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
