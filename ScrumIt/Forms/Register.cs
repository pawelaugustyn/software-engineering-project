using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class Register : MetroForm
    {
        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");
        private UserModel _user;

        public Register()
        {
            _user = new UserModel();
            InitializeComponent();
        }

        private void Register_Load(object sender, System.EventArgs e)
        {
            registerButton.BackColor = _panelColor;
            roleComboBox.Items.Add("Wybierz rolę...");
            roleComboBox.Items.Add("Scrum Master");
            roleComboBox.Items.Add("Developer");
        }

        private void registeButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    _user.Username = userLoginTextBox.Text;
                    _user.Firstname = userNameTextBox.Text;
                    _user.Lastname = userLastNameTextBox.Text;
                    _user.Email = userEmailTextBox.Text;
                    if (roleComboBox.SelectedIndex == 1)
                    {
                        _user.Role = UserRoles.ScrumMaster;
                    }
                    if (roleComboBox.SelectedIndex == 2)
                    {
                        _user.Role = UserRoles.Developer;
                    }

                    try
                    {
                        UserModel.Add(_user, newPasswordTextBox.Text);

                        MessageBox.Show("Pomyślnie stworzono użytkownika");
                        this.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private bool ValidateInput()
        {
            var login = userLoginTextBox.Text;
            if (login == "")
            {
                MessageBox.Show("Uzupełnij login");
                return false;
            }

            var firstName = userNameTextBox.Text;
            if (firstName == "")
            {
                MessageBox.Show("Uzupełnij imię");
                return false;
            }

            var lastName = userLastNameTextBox.Text;
            if (lastName == "")
            {
                MessageBox.Show("Uzupełnij nazwisko");
                return false;
            }

            var email = userEmailTextBox.Text;
            if (email == "")
            {
                MessageBox.Show("Uzupełnij email");
                return false;
            }

            var password = newPasswordTextBox.Text;
            if (password == "")
            {
                MessageBox.Show("Uzupełnij hasło");
                return false;
            }

            var confirmPassword = confirmNewPasswordTextBox.Text;
            if (confirmPassword != password)
            {
                MessageBox.Show("Hasła nie są takie same!");
                return false;
            }

            if (roleComboBox.SelectedIndex == 0)
            {
                MessageBox.Show("Wybierz rolę");
                return false;
            }

            return true;
        }

        private void userPhotoPictureBox_Click(object sender, System.EventArgs e)
        {
            if (loadPictureDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _user.Avatar = AppStateProvider.LoadImage(loadPictureDialog.FileName);
                    userPhotoPictureBox.Image = _user.Avatar;

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);

                }
            }

        }

    }
}
