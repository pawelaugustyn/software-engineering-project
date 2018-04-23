using ScrumIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumIt
{
    internal class AppStateProvider
    {
        private static AppStateProvider _instance;
        private UserModel _currentUser;

        private AppStateProvider() { }

        public static AppStateProvider Instance => _instance ?? (_instance = new AppStateProvider());

        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }
    }
}
