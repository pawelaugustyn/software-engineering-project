using System;
using System.Windows.Forms;
using ScrumIt.Models;
using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class MainView : MetroForm
    {
        public MainView()
        {
            InitializeComponent();
          
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            // jesli pierwszy raz otwieramy aplikacje wchodzi if - przechodzimy do formularza logowania
            if (AppStateProvider.Instance.CurrentUser == null)
            {
                var login = new Login();
                this.Hide();
                login.ShowDialog();
            }
            else
            {
                MessageBox.Show("uzytkownik zalogowany");
            }
        }

        
    }
}
