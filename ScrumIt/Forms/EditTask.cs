using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class EditTask : MetroForm
    {
        private int _taskId;
        private int _projectId;

        public EditTask(int taskId, int projectId)
        {
            _taskId = taskId;
            _projectId = projectId;
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void EditTask_Load(object sender, System.EventArgs e)
        {
            editTaskButton.BackColor = _panelColor;

            //pobierz dany task z bazki
            var task = new
            {
                taskName = "Nowy Task",
                taskType = "High",
                taskDescription = "Task Description",
                taskPriority = 5,
                estimatedTime = 10,
                users = new[]
                {
                    new
                    {
                        UserName ="BM1",
                        FirstName = "Bartosz",
                        LastName = "Nowak"
                    },
                    new
                    {
                        UserName ="BM2",
                        FirstName = "Bartosz",
                        LastName = "Nowak"
                    }
                }
            };

            taskNameTextBox.Text = task.taskName;
            taskDescriptionTextBox.Text = task.taskDescription;
            priorityTextBox.Text = task.taskPriority.ToString();
            estimatedTimeTextBox.Text = task.estimatedTime.ToString();

            taskNameTextBox.BackColor = Color.White;
            taskDescriptionTextBox.BackColor = Color.White;
            priorityTextBox.BackColor = Color.White;
            estimatedTimeTextBox.BackColor = Color.White;

            userListMenuStrip.Items.AddRange(createUsersListMenu(task.users));
        }

        private ToolStripItem[] createUsersListMenu(dynamic userList)
        {
            //pobierz wszystkich uzytkownikow z bazki
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
                    if (user.UserName == allUsers[i].Username)
                    {
                        toolStripMenuItem.Checked = true;
                    }
                }
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
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
            if (Int16.Parse(taskPriority) > 11 || Int16.Parse(taskPriority) < 0)
            {
                MessageBox.Show(@"Możliwa wartość stopnia skomplikowania to liczba całkownita między 0 a 10");
                validationFlag = false;
            }

            var taskEstimatedTime = estimatedTimeTextBox.Text;
            if (taskEstimatedTime == "")
            {
                MessageBox.Show(@"Uzupełnij przewidywany czas zadania");
                validationFlag = false;
            }
            else
            if (Int16.Parse(taskEstimatedTime) > 11 || Int16.Parse(taskEstimatedTime) < 0)
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
                    //przypisz uzytkownika do zadania do bazki
                }
            }
            if (validationFlag)
            {
                //add task to db
                
                this.Close();
            }
        }

        private void showUsersButton_Click(object sender, System.EventArgs e)
        {
            userListMenuStrip.Show(showUsersButton, new Point(0, showUsersButton.Height));
        }

        private void priorityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
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
    }
}
