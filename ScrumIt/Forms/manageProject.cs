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

                // TO DO
                // Pobierz userow przypisanych do zadania
                var users = new List<UserModel>
                {
                    UserModel.GetUserById(1)
                };

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
                var allUsers = UserModel.GetUsersByProjectId(_projectId);

                var toolStripItems = new ToolStripItem[allUsers.Count];
                for (var i = 0; i < allUsers.Count; i++)
                {
                    var toolStripMenuItemName = allUsers[i].Username;
                    var toolStripMenuItemText = allUsers[i].Firstname + " " + allUsers[i].Lastname + " ";
                    var toolStripMenuItem = new ToolStripMenuItem
                    {
                        Name = toolStripMenuItemName,
                        Text = toolStripMenuItemText,
                        Image = Properties.Resources.cat2,
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
            // TO DO 
            // Update project
            MessageBox.Show("Projekt został zaktualizowany");
            Close();
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
        
    }
}
