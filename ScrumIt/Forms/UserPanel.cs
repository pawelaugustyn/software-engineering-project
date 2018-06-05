﻿using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class UserPanel : MetroForm
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void UserPanel_Load(object sender, System.EventArgs e)
        {
            changePasswordButton.BackColor = _panelColor;
            submitPasswordChangeButton.BackColor = _panelColor;

            var state = AppStateProvider.Instance;
            var user = state.CurrentUser;

            userEmailTextBox.Text = user.Email;
            userNameTextBox.Text = user.Firstname;
            userLastNameTextBox.Text = user.Lastname;
            userLoginTextBox.Text = user.Username;
            userRoleTextBox.Text = user.Role.ToString();
            userPhotoPictureBox.Image = user.Avatar;
        }

        private void changePasswordButton_Click(object sender, System.EventArgs e)
        {
            changePasswordLayoutTablePanel.Visible = true;
            submitPasswordChangeButton.Visible = true;
        }

        private void submitPasswordChangeButton_Click(object sender, System.EventArgs e)
        {
            var oldPass = oldPasswordTextBox.Text;
            //Sprawdz czy ok w bazce
               //if czy dobre stare haslo          
            var newPass = newPasswordTextBox.Text;
            var newPassConf = confirmNewPasswordTextBox.Text;
            if (newPass == newPassConf)
            {
                MessageBox.Show(@"Pomyślnie zmieniono hasło");
                // update hasla na bazie
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
