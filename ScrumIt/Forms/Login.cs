using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class Login : MetroForm
    {
        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");
        private readonly Color _guestColorButton = ColorTranslator.FromHtml("#eeeeee");
        public Login()
        {
            InitializeComponent();
        }
        
        // zamykamy aplikacje jesli uzytkownik klika na przycisk "zamknij" (czerwony x :))
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //MessageBox.Show("Zamknięcie aplikacji");
                Application.Exit();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //jeśli użytkownik znajduje sie w bazie to ukrywamy formularz Login i wchodzimy do mainView
            if (Models.UserModel.LoginAs(loginTextBox.Text, passwordTextBox.Text))
            {
                this.Hide();
                var view = new MainView();
                //view.ShowDialog();
                view.Show();
            }
            else
            {
                MessageBox.Show("Niepoprawne dane logowania");
            }
        }
        

        private void Login_Load(object sender, EventArgs e)
        {
            loginButton.BackColor = _panelColor;
            guestButton.BackColor = _guestColorButton;
        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            var state = AppStateProvider.Instance;
            state.CurrentUser = new UserModel();
            this.Hide();
            var view = new MainView();
            //view.ShowDialog();
            view.Show();

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            Hide();
            reg.Show();
        }
    }
}
