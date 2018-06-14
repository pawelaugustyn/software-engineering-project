using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class UserInfo : MetroForm
    {
        private UserModel _user;

        public UserInfo(UserModel user)
        {
            _user = user;
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, System.EventArgs e)
        {
            userLoginTextBox.Text = _user.Username;
            userNameTextBox.Text = _user.Firstname;
            userLastNameTextBox.Text = _user.Lastname;
            userEmailTextBox.Text = _user.Email;
            userRoleTextBox.Text = _user.Role.ToString();
            userPhotoPictureBox.Image = _user.Avatar;
        }
    }
}
