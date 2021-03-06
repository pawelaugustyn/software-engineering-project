﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
        public string Email { get; set; }
        
        public Image Avatar
        {
            get { return AppStateProvider.Instance.GetUserPicture(UserId); }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                AppStateProvider.Instance.SetUserPicture(UserId, value, false);
            }
        }


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

        public static UserModel GetUserByUsername(string username)
        {
            return UserAccess.GetUserByUsername(username);
        }

        public static List<UserModel> GetUsersByProjectId(int projectid)
        {
            return UserAccess.GetUsersByProjectId(projectid);
        }

        public static bool Add(UserModel addedUser, string password)
        {
            return UserAccess.Add(addedUser, password);
        }

        public static bool Delete(UserModel deletedUser)
        {
            return UserAccess.Delete(deletedUser);
        }
        public static List<UserModel> GetUsersByTaskId(int projectid)
        {
            return UserAccess.GetUsersByTaskId(projectid);
        }

        public static void UpdateUserPassword(string password)
        {
            UserAccess.UpdateUserPassword(password);
        }

        public static void UpdateUserData(UserModel user)
        {
            UserAccess.UpdateUserData(user);
        }

        public static List<UserModel> GetAllUser()
        {
            return UserAccess.GetAllUsers();
        }
    }

    public enum UserRoles
    {
        Guest,
        Developer,
        ScrumMaster
    }
}
