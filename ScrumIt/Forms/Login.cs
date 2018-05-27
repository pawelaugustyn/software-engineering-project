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
        
        private void GuestmetroLink_Click(object sender, EventArgs e)
        {
            var state = AppStateProvider.Instance;
            state.CurrentUser = new UserModel();
            this.Hide();
            var view = new MainView();
            //view.ShowDialog();
            view.Show();
        }
    }
}
