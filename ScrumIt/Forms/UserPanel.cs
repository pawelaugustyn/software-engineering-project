using System;
using System.Drawing;
using System.Windows.Forms;
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

        private UserModel _user;
        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void UserPanel_Load(object sender, System.EventArgs e)
        {
            changePasswordButton.BackColor = _panelColor;
            submitPasswordChangeButton.BackColor = _panelColor;
            try
            {
                var state = AppStateProvider.Instance;
                _user = state.CurrentUser;

                userEmailTextBox.Text = _user.Email;
                userNameTextBox.Text = _user.Firstname;
                userLastNameTextBox.Text = _user.Lastname;
                userLoginTextBox.Text = _user.Username;
                userRoleTextBox.Text = _user.Role.ToString();
                userPhotoPictureBox.Image = _user.Avatar;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void changePasswordButton_Click(object sender, System.EventArgs e)
        {
            changePasswordLayoutTablePanel.Visible = true;
            submitPasswordChangeButton.Visible = true;
        }

        private void submitPasswordChangeButton_Click(object sender, System.EventArgs e)
        {
            var newPass = newPasswordTextBox.Text;
            var newPassConf = confirmNewPasswordTextBox.Text;
            if (newPass == newPassConf && _user != null)
            {
                MessageBox.Show(@"Pomyślnie zmieniono hasło");
                UserModel.UpdateUserPassword(newPass);
            }
            else
            {
                MessageBox.Show(@"Wprowadzone nowe hasła nie są identyczne");
            }
        }

        private void userPhotoPictureBox_Click(object sender, System.EventArgs e)
        {
            if (loadPictureDialog.ShowDialog() == DialogResult.OK)
            {
                var user = AppStateProvider.Instance.CurrentUser;
                try
                {
                    user.Avatar = AppStateProvider.LoadImage(loadPictureDialog.FileName);
                    MessageBox.Show(@"Pomyślnie zmieniono zdjęcie.");
                    userPhotoPictureBox.Image = user.Avatar;
                }
                catch (ArgumentException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}
