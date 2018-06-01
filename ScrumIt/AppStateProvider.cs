using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumIt
{
    internal class AppStateProvider
    {
        private static AppStateProvider _instance;
        private UserModel _currentUser;
        private Dictionary<int, Image> _userPics;

        private AppStateProvider()
        {
            _userPics = new Dictionary<int, Image>();
        }

        public static AppStateProvider Instance => _instance ?? (_instance = new AppStateProvider());

        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public Image GetUserPicture(int uid)
        {
            Image img;
            if (_userPics.TryGetValue(uid, out img))
                return img;

            img = UserAccess.GetUserPicture(uid);

            return SetUserPicture(uid, img);
        }

        public Image SetUserPicture(int uid, Image img)
        {
            _userPics.Add(uid, img);
            return UserAccess.GetUserPicture(uid);
        }

        public void SetUserPicture(List<int> uids, bool skipExisting=true)
        {
            var imgs = UserAccess.GetUserPicture(uids);
            foreach (var uPic in imgs)
            {
                try
                {
                    SetUserPicture(uPic.Key, uPic.Value);
                }
                catch (ArgumentException)
                {
                    if (skipExisting) continue;
                    _userPics.Remove(uPic.Key);
                    SetUserPicture(uPic.Key, uPic.Value);
                }
            }
        }

        public Image LoadImage(string filePath)
        {
            try
            {
                var img = Image.FromFile(filePath);
                if (img.Width > 100 || img.Height > 100)
                    img = new Bitmap(img, new Size(100, 100));
                return img;
            }
            catch (OutOfMemoryException)
            {
                throw new ArgumentException("Plik ma nieprawidlowy format!");
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException("Plik nie istnieje!");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Plik nie moze byc linkiem!");
            }
        }
    }
}
