using System;
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
            using (var conn = new Connection())
            {
                var cmd = new NpgsqlCommand("select * from users where username=@username and pass=@pass limit 1;")
                {
                    Connection = conn.Conn
                };
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("pass", EncryptMd5(password));
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        currentUser = new UserModel()
                        {
                            UserId = (int)reader[0],
                            Username = (string)reader[1],
                            Firstname = (string)reader[3],
                            Lastname = (string)reader[4],
                            Role = (UserRoles)reader[5]
                        };
                        break;
                    }
                }
            }
            return currentUser;
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
