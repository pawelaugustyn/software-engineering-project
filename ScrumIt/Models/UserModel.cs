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

        public static bool Logout()
        {
            var state = AppStateProvider.Instance;
            if (state.CurrentUser.UserId <= 0) return false;
            state.CurrentUser = new UserModel();
            return true;
        }

        public static UserModel GetUserById(int userid)
        {
            return UserAccess.GetUserById(userid);
        }

        public static UserModel GetUserByLastName(string lastname)
        {
            return UserAccess.GetUserByLastName(lastname);
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
