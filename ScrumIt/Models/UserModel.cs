using System.Security.Cryptography;
using System.Text;
using Npgsql;
using ScrumIt.DataAccess;

namespace ScrumIt.Models
{
    public class UserModel
    {
        public int UserId { get; set; } = 0;
        public string Username { get; set; }
        public string Firstname { get; set;  }
        public string Lastname { get; set; }
        public UserRoles Role { get; set; } = UserRoles.Guest;
        

        public static bool LoginAs(string username, string password)
        {
            var state = AppStateProvider.Instance;
            state.CurrentUser = UserAccess.LoginAs(username, password);
            return state.CurrentUser.UserId > 0;
        }
        

    }

    public enum UserRoles
    {
        Guest,
        Developer,
        ScrumMaster,
        Admin
    }
}
