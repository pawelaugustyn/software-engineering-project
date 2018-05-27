using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class Register : MetroForm
    {
        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, System.EventArgs e)
        {
            registeButton.BackColor = _panelColor;
        }

        private void registeButton_Click(object sender, System.EventArgs e)
        {
            if (ValidateInput())
            {
                var newUser = new UserModel
                {
                    Username = userLoginTextBox.Text,
                    Firstname = userNameTextBox.Text,
                    Lastname = userLastNameTextBox.Text,
                    Email = userEmailTextBox.Text,
                    Role = UserRoles.Developer, //tu bedzie combobox
                    //Image

                };
               // UserModel.Add(newUser, newPasswordTextBox.Text);

                MessageBox.Show("Pomyślnie stworzono użytkownika");
                this.Close();
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

            return true;
        }

        private void userPhotoPictureBox_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Wybierz obraz";
                dlg.Filter = "png files (*.png)|*.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    userPhotoPictureBox.Image = new Bitmap(dlg.FileName);
                }
            }
        }
        
    }
}
