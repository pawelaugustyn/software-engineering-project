using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class UserPanel : MetroForm
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        private void UserPanel_Load(object sender, System.EventArgs e)
        {
            UserModel user = new UserModel
            {
                Email = "dd",
                Firstname = "Kamil",
                Lastname = "Nowak",
                Role = UserRoles.Developer,
                Username = "Kamil123"
            };

            userEmailTextBox.Text = user.Email;
            userNameTextBox.Text = user.Firstname;
            userLastNameTextBox.Text = user.Lastname;
            userLoginTextBox.Text = user.Username;
            userRoleTextBox.Text = user.Role.ToString();
        }

        private void changePasswordButton_Click(object sender, System.EventArgs e)
        {
            changePasswordLayoutTablePanel.Visible = true;
            submitPasswordChangeButton.Visible = true;
        }
    }
}
