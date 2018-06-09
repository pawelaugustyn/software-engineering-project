using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class EditTask : MetroForm
    {
        private int _taskId;
        private int _projectId;
        private string _userRole;

        public EditTask(int taskId, int projectId)
        {
            _userRole = AppStateProvider.Instance.CurrentUser.Role.ToString();
            _taskId = taskId;
            _projectId = projectId;
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void EditTask_Load(object sender, System.EventArgs e)
        {
            editTaskButton.BackColor = _panelColor;
            try
            {
                var task = TaskModel.GetTaskById(_taskId);

                taskNameTextBox.Text = task.TaskName;
                taskDescriptionTextBox.Text = task.TaskDesc;
                priorityTextBox.Text = task.TaskPriority.ToString();
                estimatedTimeTextBox.Text = task.TaskEstimatedTime.ToString();

                taskNameTextBox.BackColor = Color.White;
                taskDescriptionTextBox.BackColor = Color.White;
                priorityTextBox.BackColor = Color.White;
                estimatedTimeTextBox.BackColor = Color.White;

                var users = UserModel.GetUsersByTaskId(_taskId);
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
                    var toolStripMenuItemName = allUsers[i].UserId;
                    var toolStripMenuItemText = allUsers[i].Firstname + " " + allUsers[i].Lastname + " ";
                    var toolStripMenuItem = new ToolStripMenuItem
                    {
                        Name = toolStripMenuItemName.ToString(),
                        Text = toolStripMenuItemText,
                        Image = allUsers[i].Avatar,
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

        private void editTaskButton_Click(object sender, System.EventArgs e)
        {
            var validationFlag = true;
            var taskName = taskNameTextBox.Text;
            if (taskName == "")
            {
                MessageBox.Show(@"Uzupełnij nazwę zadania");
                validationFlag = false;
            }

            var taskDescription = taskDescriptionTextBox.Text;
            var taskPriority = priorityTextBox.Text;
            if (taskPriority == "")
            {
                MessageBox.Show(@"Uzupełnij stopień skomplikowania zadania");
                validationFlag = false;
            }
            else
            if (Int16.Parse(taskPriority) > 101 || Int16.Parse(taskPriority) < 0)
            {
                MessageBox.Show(@"Możliwa wartość stopnia skomplikowania to liczba całkownita między 0 a 100");
                validationFlag = false;
            }

            var taskEstimatedTime = estimatedTimeTextBox.Text;
            if (taskEstimatedTime == "")
            {
                MessageBox.Show(@"Uzupełnij przewidywany czas zadania");
                validationFlag = false;
            }
            else
            if (Int16.Parse(taskEstimatedTime) > 101 || Int16.Parse(taskEstimatedTime) < 0)
            {
                MessageBox.Show(@"Możliwa wartość przewidywanego czasu zadania to liczba całkownita między 0 a 100");
                validationFlag = false;
            }

            var usersList = userListMenuStrip.Items;
            var userNames = new List<string>();
            foreach (ToolStripMenuItem user in usersList)
            {
                if (user.Checked)
                {
                    var userName = user.Name;
                    userNames.Add(userName);
                }
            }

            var userModels = new List<UserModel>();
            foreach (var user in userNames)
            {
                userModels.Add(UserModel.GetUserById(Int32.Parse(user)));
            }
            if (validationFlag)
            {
                try
                {
                    var task = TaskModel.GetTaskById(_taskId);
                    TaskModel.AssignUsersToTask(task, userModels);
                    task.TaskName = taskName;
                    task.TaskDesc = taskDescription;
                    task.TaskPriority = Int32.Parse(taskPriority);
                    task.TaskEstimatedTime = Int32.Parse(taskEstimatedTime);
                    if (TaskModel.UpdateTask(task))
                    {
                        MessageBox.Show(@"Zaktualizowano zmiany zadania");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                this.Close();
            }
        }

        private void showUsersButton_Click(object sender, System.EventArgs e)
        {
            userListMenuStrip.Show(showUsersButton, new Point(0, showUsersButton.Height));
        }

        private void priorityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void estimatedTimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void userListMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_userRole == "ScrumMaster")
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Jesteś pewny, że chcesz usunąć to zadanie? ",
                        "Usuń zadanie", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TaskModel.RemoveTask(_taskId);
                        Close();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                var tooltip = new ToolTip();
                tooltip.SetToolTip(button1, "Tylko Scrum Master może usuwać zadania");
            }
        }
    }
}
