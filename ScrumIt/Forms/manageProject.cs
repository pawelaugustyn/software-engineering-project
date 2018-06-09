using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class ManageProject : MetroForm
    {
        private int _projectId;
        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        public ManageProject(int projectId)
        {
            _projectId = projectId;
            InitializeComponent();
        }

        private void ManageProject_Load(object sender, System.EventArgs e)
        {
            editProjectButton.BackColor = _panelColor;
            addSprintButton.BackColor = _panelColor;
            try
            {
                var project = ProjectModel.GetProjectById(_projectId);
                changeNameTextBox.Text = project.ProjectName;

                changeColorButton.BackColor = ColorTranslator.FromHtml(project.ProjectColor);

                var users = UserModel.GetUsersByProjectId(_projectId);

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
                var allUsers = UserModel.GetAllUser();

                var toolStripItems = new ToolStripItem[allUsers.Count];
                for (var i = 0; i < allUsers.Count; i++)
                {
                    var toolStripMenuItemName = allUsers[i].Username;
                    var toolStripMenuItemText = allUsers[i].Firstname + " " + allUsers[i].Lastname + " ";
                    var toolStripMenuItem = new ToolStripMenuItem
                    {
                        Name = toolStripMenuItemName,
                        Text = toolStripMenuItemText,
                        CheckOnClick = true
                    };
                    foreach (var user in userList)
                    {
                        if (user.Username == allUsers[i].Username)
                        {
                            toolStripMenuItem.Checked = true;
                        }
                    }

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

        private void showUsersButton_Click(object sender, System.EventArgs e)
        {
            userListMenuStrip.Show(showUsersButton, new Point(0, showUsersButton.Height));
        }

        private void userListMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        private void changeColoButton_Click(object sender, System.EventArgs e)
        {
            var color = new Color();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
            changeColorButton.BackColor = color;
        }

        private void editTaskButton_Click(object sender, System.EventArgs e)
        {
            if (changeNameTextBox.Text == "")
            {
                MessageBox.Show("Uzupełnij nazwę projektu");
            }

            try
            {
                var project = ProjectModel.GetProjectById(_projectId);
                ProjectModel.UpdateProject(new ProjectModel
                {
                    ProjectId = project.ProjectId,
                    ProjectName = changeNameTextBox.Text,
                    ProjectColor = ToHexValue(changeColorButton.BackColor)
                });

                var usersList = userListMenuStrip.Items;
                var userListToAssign = new List<UserModel>();
                foreach (ToolStripMenuItem user in usersList)
                {
                    if (user.Checked)
                    {
                        var userName = user.Name;
                        userListToAssign.Add(UserModel.GetUserByUsername(userName));
                    }
                }

                ProjectModel.AssignUsersToProject(project, userListToAssign);

                MessageBox.Show("Projekt został zaktualizowany");
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Jesteś pewny, że chcesz usunąć ten projekt? ", "Usuń projekt", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var project = ProjectModel.GetProjectById(_projectId);
                    ProjectModel.DeleteProject(project);
                    Close();
                    var mainView = new MainView();
                    mainView.Show();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void addSprintButton_Click(object sender, System.EventArgs e)
        {
            var addSprint = new AddSprint(_projectId);
            Hide();
            addSprint.Show();
        }

        private static string ToHexValue(Color color)
        {
            return "#" + color.R.ToString("X2") +
                   color.G.ToString("X2") +
                   color.B.ToString("X2");
        }
    }
}
