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
