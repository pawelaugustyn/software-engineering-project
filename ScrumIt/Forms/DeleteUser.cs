using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class DeleteUser : MetroForm
    {
        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        public DeleteUser()
        {
            InitializeComponent();
        }

        private void DeleteUser_Load(object sender, System.EventArgs e)
        {
            userListButton.BackColor = _panelColor;
            deleteUserButton.BackColor = Color.DarkRed;
            try
            {
                var users = UserModel.GetAllUser();
                userListMenuStrip.Items.AddRange(createUsersListMenu(users));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private ToolStripItem[] createUsersListMenu(List<UserModel> userList)
        {
            try
            {
                var length = 25;
                if (userList.Count < 25)
                {
                    length = userList.Count;
                }
                var toolStripItems = new ToolStripItem[length];
                for (var i = 0; i < length; i++)
                {
                    var toolStripMenuItemName = userList[i].UserId;
                    var toolStripMenuItemText = userList[i].Firstname + " " + userList[i].Lastname + " ";
                    var toolStripMenuItem = new ToolStripMenuItem
                    {
                        Name = toolStripMenuItemName.ToString(),
                        Text = toolStripMenuItemText,
                        Image = userList[i].Avatar,
                        CheckOnClick = true
                    };

                    toolStripItems[i] = toolStripMenuItem;
                }

                return toolStripItems;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }

        }

        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"Jesteś pewny, że chcesz usunąć tych użytkowników? ", @"Usuń użytkowników", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var usersList = userListMenuStrip.Items;
                var userNames = new List<string>();
                try
                {
                    foreach (ToolStripMenuItem user in usersList)
                    {
                        if (user.Checked)
                        {
                            var userId = Int32.Parse(user.Name);
                            var userToDelete = UserModel.GetUserById(userId);
                            UserModel.Delete(userToDelete);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void userListButton_Click(object sender, EventArgs e)
        {
            userListMenuStrip.Show(userListButton, new Point(0, userListButton.Height));
        }
    }
}
