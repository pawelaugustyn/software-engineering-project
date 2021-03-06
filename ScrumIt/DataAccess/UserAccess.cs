﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Npgsql;
using ScrumIt.Models;

namespace ScrumIt.DataAccess
{
    internal class UserAccess
    {
        private static Image _defaultPic = new Bitmap(64, 64);

        public static UserModel LoginAs(string username, string password)
        {
            var currentUser = new UserModel();
            // W ten sposob robimy polaczenie z baza danych
            // korzystajac z using zapewniamy, ze wychodzac z tego bloku
            // wywolamy metode Dispose z klasy Connection, czyli
            // zamkniemy poprawnie polaczenie
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where lower(username)=@username and pass=@pass limit 1;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("username", username?.ToLower());
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
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where uid=@uid limit 1;")
                {
                    Connection = Connection.Conn
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

        public static UserModel GetUserByUsername(string username)
        {
            var user = new UserModel();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where lower(username) like @username limit 1;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("username", username?.ToLower() + '%');
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

        public static List<UserModel> GetUsersByTaskId(int taskid)
        {
            var users = new List<UserModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select b.* from tasks_assigned_users a join users b using(uid) where a.task_id = @taskid order by b.username;")
                {
                Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("taskid", taskid);
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

        public static List<UserModel> GetUsersByProjectId(int projectid, bool exclusive = false)
        {
            var users = new List<UserModel>();
            using (var c = new Connection(exclusive))
            {
                var cmd = new NpgsqlCommand("select b.* from projects_has_users a join users b using(uid) where a.project_id = @projectid order by b.uid;")
                {
                    Connection = exclusive ? c.ConnExcl : Connection.Conn
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

        public static Dictionary<int, Image> GetUserPicture(List<int> uids)
        {
            var dict = new Dictionary<int, Image>();
            using (new Connection())
            {
                foreach (var uid in uids)
                {
                    dict.Add(uid, GetUserPicture(uid));
                }
            }

            return dict;
        }

        public static Image GetUserPicture(int uid)
        {
            var picture = _defaultPic;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select picture from users where uid = @uid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("uid", uid);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader[0] == DBNull.Value)
                            break;
                        var str = new BufferedStream(new MemoryStream());
                        var bw = new BinaryWriter(str);
                        var outbyte = new byte[100];
                        var startIndex = 0;
                        var retval = reader.GetBytes(0, startIndex, outbyte, 0, 100);
                        while (retval == 100)
                        {
                            bw.Write(outbyte);
                            bw.Flush();
                            startIndex += 100;
                            retval = reader.GetBytes(0, startIndex, outbyte, 0, 100);
                        }
                        bw.Write(outbyte, 0, 100);
                        bw.Flush();
                        try
                        {
                            picture = Image.FromStream(str);
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                        bw.Close();
                        str.Close();
                    }
                }
            }

            return picture;
        }

        public static bool SetUserPicture(int uid, Image img)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("update users set picture = @picture where uid = @uid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("uid", uid);
                cmd.Parameters.AddWithValue("picture", ImageToByte(img));
                var res = cmd.ExecuteNonQuery();

                AppStateProvider.Instance.SetUserPicture(uid, img);

                return res == 1;
            }
        }

        public static List<UserModel> GetAllUsers()
        {
            var users = new List<UserModel>();
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users order by uid;")
                {
                    Connection = Connection.Conn
                };
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

        public static bool Add(UserModel addedUser, string password)
        {
            if (AppStateProvider.Instance.CurrentUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Brak uprawnien.");
            ValidateUser(addedUser, password);

            using (new Connection())
            {
                var cmd = new NpgsqlCommand("INSERT INTO users VALUES (DEFAULT, @username, @pass, @first_name, @last_name, @role, @email);")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("username", addedUser.Username);
                cmd.Parameters.AddWithValue("pass", EncryptMd5(password));
                cmd.Parameters.AddWithValue("first_name", addedUser.Firstname);
                cmd.Parameters.AddWithValue("last_name", addedUser.Lastname);
                cmd.Parameters.AddWithValue("role", (int)addedUser.Role);
                cmd.Parameters.AddWithValue("email", addedUser.Email);
                var result = cmd.ExecuteNonQuery();

                if (result != 1)
                    return false;

                cmd = new NpgsqlCommand("SELECT uid FROM users ORDER BY uid DESC LIMIT 1;")
                {
                    Connection = Connection.Conn
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

        public static bool Delete(UserModel deletedUser)
        {
            var currUser = AppStateProvider.Instance.CurrentUser;
            if (currUser.Role != UserRoles.ScrumMaster)
                throw new UnauthorizedAccessException("Brak uprawnien.");
            if (currUser.UserId == deletedUser.UserId)
                throw new ArgumentException("Nie mozesz usunac samego siebie.");

            using (new Connection())
            {
                var cmd = new NpgsqlCommand("DELETE FROM users WHERE uid = @uid")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("uid", deletedUser.UserId);
                var res = cmd.ExecuteNonQuery();

                return res == 1;
            }
        }

        public static bool UpdateUserData(UserModel updatedUser)
        {
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Guest)
                throw new UnauthorizedAccessException("Brak uprawnien.");
            if (AppStateProvider.Instance.CurrentUser.Role == UserRoles.Developer && AppStateProvider.Instance.CurrentUser.UserId != updatedUser.UserId)
                throw new UnauthorizedAccessException("Brak uprawnien - nie mozesz edytowac czyichs danych.");

            ValidatePersonalData(updatedUser);

            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE users SET first_name = @firstname, last_name = @lastname, role = @role, email = @email WHERE uid = @userid;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("firstname", updatedUser.Firstname);
                cmd.Parameters.AddWithValue("lastname", updatedUser.Lastname);
                cmd.Parameters.AddWithValue("role", (int)updatedUser.Role);
                cmd.Parameters.AddWithValue("email", updatedUser.Email);

                cmd.Parameters.AddWithValue("userid", updatedUser.UserId);
                var result = cmd.ExecuteNonQuery();
                if (result != 1) return false;

                return true;
            }
        }

        public static bool UpdateUserPassword(string password)
        {
            ValidatePassword(password);
            var userId = AppStateProvider.Instance.CurrentUser.UserId;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("UPDATE users SET pass=@password where uid=@id")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("password", EncryptMd5(password));
                cmd.Parameters.AddWithValue("id", userId);
                var result = cmd.ExecuteNonQuery();
                if (result != 1) return false;
            }
            return true;
        }
        private static byte[] ImageToByte(Image img)
        {
            var converter = new ImageConverter();

            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static void ValidateUser(UserModel addedUser, string password)
        {
            ValidateUsername(addedUser);
            ValidatePassword(password);
            ValidatePersonalData(addedUser);
        }

        private static void ValidateUsername(UserModel addedUser)
        {
            var username = addedUser.Username;
            ValidateUsernameFormat(username);
            ValidateUsernameAvailability(username);
        }

        private static void ValidateUsernameFormat(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Nazwa uzytkownika nie moze byc pusta!");
            if (username.Length < 5)
                throw new ArgumentException("Login musi zawierac conajmniej 5 znakow!");
            if (!new Regex(@"^[a-zA-Z0-9()-]*$").IsMatch(username))
                throw new ArgumentException("Nazwa uzytkownika moze zawierac tylko znaki alfanumeryczne!");
            if (!new Regex(@"^[a-zA-Z][a-zA-Z0-9()-]*$").IsMatch(username))
                throw new ArgumentException("Nazwa uzytkownika musi zaczynac sie od litery!");
        }

        private static void ValidateUsernameAvailability(string username)
        {
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("SELECT username FROM users WHERE lower(username) LIKE @username;")
                {
                    Connection = Connection.Conn
                };
                cmd.Parameters.AddWithValue("username", username.ToLower() + '%');
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        throw new ArgumentException("Ta nazwa uzytkownika jest zajeta, sprobuj innej.");
                    }
                }
            }
        }

        private static void ValidatePassword(string password)
        {
            if (password?.Length == 0)
                throw new ArgumentException("Haslo nie moze byc puste!");
            if (password?.Length < 5)
                throw new ArgumentException("Haslo musi miec conajmniej 5 znakow.");
        }

        private static void ValidatePersonalData(UserModel addedUser)
        {
            if (addedUser.Firstname.Length == 0 || addedUser.Lastname.Length == 0)
                throw new ArgumentException("Imie i nazwisko nie moga byc puste");
            try
            {
                var m = new MailAddress(addedUser.Email);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Nieprawidlowy adres email");
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
