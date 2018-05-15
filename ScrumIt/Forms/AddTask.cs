using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class AddTask : MetroForm
    {
        public AddTask()
        {
            InitializeComponent();
        }


        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void TaskForm_Load(object sender, EventArgs e)
        {
            addTaskButton.BackColor = _panelColor;

            //pobierz uzykownikow danego projektu z bazki
            var users = new[]
            {
                new
                {
                    UserName = "BM",
                    FirstName = "Bartosz",
                    LastName = "Nowak"
                },
                new
                {
                    UserName = "BM",
                    FirstName = "Bartosz",
                    LastName = "Nowak"
                }
            };

            userListMenuStrip.Items.AddRange(createUsersListMenu(users));
        }

        private void addTaskButton_Click(object sender, EventArgs e)
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

        private void addUsersButton_Click(object sender, EventArgs e)
        {
            userListMenuStrip.Show(addUsersButton, new Point(0, addUsersButton.Height));
        }

        private ToolStripItem[] createUsersListMenu(dynamic userList)
        {
            var toolStripItems = new ToolStripItem[userList.Length];
            for (var i = 0; i < userList.Length; i++)
            {
                var toolStripMenuItemName = userList[i].UserName;
                var toolStripMenuItemText = userList[i].FirstName + " " + userList[i].LastName + " ";
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = toolStripMenuItemText,
                    Image = Properties.Resources.image,
                    CheckOnClick = true
                };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
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
