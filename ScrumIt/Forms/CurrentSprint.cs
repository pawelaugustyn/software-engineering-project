﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class CurrentSprint : MetroForm
    {
        private readonly int _projectId;
        private int _sprintId;
        private bool createMenuflag = true;
        private string _userRole;

        public CurrentSprint()
        {
            _userRole = AppStateProvider.Instance.CurrentUser.Role.ToString();
            InitializeComponent();
        }

        public CurrentSprint(int projectId)
        {
            _projectId = projectId;
            _userRole = AppStateProvider.Instance.CurrentUser.Role.ToString();
            var sprintModel = SprintModel.GetCurrentSprintForProject(_projectId);
            _sprintId = sprintModel.SprintId+1;
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");
        private Point _mouseDownLocation;
        private Point _mouseUpLocation;

        private void CurrentSprint_Load(object sender, EventArgs e)
        {
            var taskList = TaskModel.GetTasksBySprintId(_sprintId);
            
            var index = 0;
            foreach (var task in taskList)
            {
                CreateTaskPanel(task, index++);
            }

            if (createMenuflag)
            {
                propertiesComboBox.Items.Add("Wybierz opcję...");
                propertiesComboBox.Items.Add("Lista Projektów");
                if (_userRole == "ScrumMaster")
                {
                    propertiesComboBox.Items.Add("Dane użytkownika");
                    propertiesComboBox.Items.Add("Stwórz konto");
                    propertiesComboBox.Items.Add("Zarządzaj projektem");
                    propertiesComboBox.Items.Add("Wyloguj");
                }
                else if (_userRole == "Developer")
                {
                    propertiesComboBox.Items.Add("Dane użytkownika");
                    propertiesComboBox.Items.Add("Wyloguj");
                }
                else
                {
                    propertiesComboBox.Items.Add("Zaloguj się");
                }
                propertiesComboBox.SelectedIndex = 0;

                var projectColorString = ProjectModel.GetProjectById(_projectId).ProjectColor;
                var projectColor = ColorTranslator.FromHtml(projectColorString);
                scrumBoardPanel.BackColor = projectColor;

                //pobierz historyczne sprinty
                var historicalSprints = new List<SprintModel>
                {
                    new SprintModel()
                    {
                        StartDateTime = DateTime.Parse("2018-04-21"),
                        EndDateTime = DateTime.Parse("2018-05-09")

                    }
                };

                //Pobierz backlog
                var backlogTasks = TaskModel.GetTasksBySprintId(0);

                var users = UserModel.GetUsersByProjectId(_projectId);

                historyMenuStrip.Items.AddRange(CreateHistoryMenu(historicalSprints));
                backlogMenuStrip.Items.AddRange(createBacklogMenu(backlogTasks));
                userListMenuStrip.Items.AddRange(createUserListMenu(users));
                createMenuflag = false;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            PrepareLayout(e);
        }

        private void bottomPanel_Paint(object sender, PaintEventArgs e)
        {
            bottomPanel.BackColor = _panelColor;
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            historyMenuStrip.Show(historyButton, new Point(0, historyButton.Height));
        }

        private void backlogButton_Click(object sender, EventArgs e)
        {
            backlogMenuStrip.Show(backlogButton, new Point(0, backlogButton.Height));
        }

        private void userListButton_Click(object sender, EventArgs e)
        {
            userListMenuStrip.Show(userListButton, new Point(0, userListButton.Height));
        }

        private void currentSprintButton_Click(object sender, EventArgs e)
        {
            var taskList = TaskModel.GetTasksBySprintId(_sprintId);
            scrumBoardPanel.Controls.Clear();

            var index = 0;
            foreach (var task in taskList)
            {
                CreateTaskPanel(task, index++);
            }
        }

        private void panel_MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDownLocation = e.Location;
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseUpLocation = new Point(e.X + ((Panel)sender).Location.X - _mouseDownLocation.X,
                    ((Panel)sender).Location.Y);
                ((Panel)sender).Location = _mouseUpLocation;
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e, TaskModel task)
        {
            var width = scrumBoardPanel.ClientRectangle.Width;
            if (_mouseUpLocation.X < width / 4)
            {
                ((Panel)sender).Location = new Point(width / 40, ((Panel)sender).Location.Y);
                //update task stage
            }

            if (_mouseUpLocation.X > width / 4 && _mouseUpLocation.X < 7 * width / 12)
            {
                ((Panel)sender).Location = new Point(width / 40 + width / 3, ((Panel)sender).Location.Y);
            }
            if (_mouseUpLocation.X > 7 * width / 12)
            {
                ((Panel)sender).Location = new Point(width / 40 + 2 * width / 3, ((Panel)sender).Location.Y);
            }
            //change task stage
        }

        private void panel_DoubleClick(int taskId)
        {
            EditTask editTask = new EditTask(taskId, _projectId);
            editTask.FormClosed += delegate { editTask_FormClosed(); };
            editTask.Show();
        }

        private void editTask_FormClosed()
        {
            scrumBoardPanel.Controls.Clear();
            CurrentSprint_Load(null, EventArgs.Empty);
        }

        private void addTask_FormClosed()
        {
            scrumBoardPanel.Controls.Clear();
            CurrentSprint_Load(null, EventArgs.Empty);
        }

        private void addTaskFromBacklog_FormClosed()
        {
            scrumBoardPanel.Controls.Clear();
            CurrentSprint_Load(null, EventArgs.Empty);
        }


        private void backlogToolStripMenuItem_Click(int taskId)
        {

            AddTaskFromBacklog addTask = new AddTaskFromBacklog(taskId, _sprintId);
            addTask.FormClosed += delegate { addTaskFromBacklog_FormClosed(); };
            addTask.Show();
        }

        private void changeColorButton_Click(Panel taskPanel, MetroTextBox textBox, TaskModel task)
        {
            var color = new Color();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
            taskPanel.BackColor = color;
            TaskModel.SetNewColour(task, ToHexValue(color));
        }

        private void taskDescriptionButton_Click(string description)
        {
            MessageBox.Show(description);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            var borderSize = getScrumBordPanelBorderSize();
            var height = GetScrumBoardPanelHeight();
            var width = GetScrumBoardPanelWidth();
            var toDoLabel = new MetroLabel
            {
                Text = @"To Do",
                Size = new Size(width / 3, height / 12 - borderSize),
                Location = new Point(borderSize, borderSize),
                TextAlign = ContentAlignment.MiddleCenter,
                CustomForeColor = true,
                CustomBackground = true,
                ForeColor = Color.White,
                BackColor = _panelColor,
                FontSize = MetroLabelSize.Tall
            };
            headerPanel.Controls.Add(toDoLabel);

            var inProgressLabel = new MetroLabel
            {
                Text = @"In Progress",
                Size = new Size(width / 3, height / 12 - borderSize),
                Location = new Point(width / 3 + borderSize, borderSize),
                TextAlign = ContentAlignment.MiddleCenter,
                CustomForeColor = true,
                CustomBackground = true,
                ForeColor = Color.White,
                BackColor = _panelColor,
                FontSize = MetroLabelSize.Tall
            };
            headerPanel.Controls.Add(inProgressLabel);

            var completedLabel = new MetroLabel
            {
                Text = @"Completed",
                Size = new Size(width / 3 + 15, height / 12 - borderSize),
                Location = new Point(2 * width / 3 + borderSize, borderSize),
                TextAlign = ContentAlignment.MiddleCenter,
                CustomForeColor = true,
                CustomBackground = true,
                ForeColor = Color.White,
                BackColor = _panelColor,
                FontSize = MetroLabelSize.Tall
            };
            headerPanel.Controls.Add(completedLabel);
        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            if (_userRole != "Guest")
            {
                AddTask addTask = new AddTask(_projectId, _sprintId);
                addTask.FormClosed += delegate { addTask_FormClosed(); };
                addTask.Show();
            }
            else
            {
                var addTaskToolTip = new ToolTip();
                addTaskToolTip.SetToolTip(addTaskButton, "Zaloguj się aby dodać zadanie");
            }
        }

        private void historyToolStripMenuItem_Click(int sprintId)
        {
            //pobierz taski z historycznego sprintu

            var taskList = new[]
            {
                new
                {
                    taskName = "Stary Task",
                    taskDescription = "Task Description",
                    taskPriority = 2,
                    estimatedTime = 10,
                    users = new[] {"Nowak1"},
                    taskStage = 1,
                    Color = Color.Aquamarine
                },
                new
                {
                    taskName = "Stary Task",
                    taskDescription = "Task Description",
                    taskPriority = 4,
                    estimatedTime = 10,
                    users = new[] {"Nowak1","Nowak2"},
                    taskStage = 2,
                    Color = Color.Aqua
                },
                new
                {
                    taskName = "Stary Task",
                    taskDescription = "Task Description",
                    taskPriority = 10,
                    estimatedTime = 10,
                    users = new[] {"Nowak1","Nowak2","Nowak3"},
                    taskStage = 3,
                    Color = Color.Bisque
                }
            };
            scrumBoardPanel.Controls.Clear();

            for (var i = 0; i < taskList.Length; i++)
            {
                CreateHistoryTaskPanel(taskList[i], i);
            }
        }

        private int GetScrumBoardPanelHeight()
        {
            return scrumBoardPanel.Height;
        }

        private int GetScrumBoardPanelWidth()
        {
            return scrumBoardPanel.Width;
        }

        private int getScrumBordPanelBorderSize()
        {
            return 2;
        }

        private ToolStripItem[] CreateHistoryMenu(List<SprintModel> history)
        {
            var toolStripItems = new ToolStripItem[history.Count];
            for (var i = 0; i < history.Count; i++)
            {
                var sprintId = history[i].SprintId;
                var sprintName = history[i].StartDateTime.ToShortDateString() + " - " + history[i].EndDateTime.ToShortDateString();
                var toolStripMenuItemName = sprintName + "ToolStripMenuItem";
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = sprintName
                };
                toolStripMenuItem.Click += delegate
                {
                    historyToolStripMenuItem_Click(sprintId);
                };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
        }

        private ToolStripItem[] createBacklogMenu(List<TaskModel> backlog)
        {
            var toolStripItems = new ToolStripItem[backlog.Count];
            for (var i = 0; i < backlog.Count; i++)
            {
                var toolStripMenuItemName = backlog[i].TaskName + "ToolStripMenu";
                var taskId = backlog[i].TaskId;
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = backlog[i].TaskName
                };
                toolStripMenuItem.Click += delegate
                {
                    backlogToolStripMenuItem_Click(taskId);
                };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
        }

        private ToolStripItem[] createUserListMenu(List<UserModel> userList)
        {
            var toolStripItems = new ToolStripItem[userList.Count];
            var index = 0;
            foreach (var user in userList)
            {
                var toolStripMenuItemName = user.Username + "ToolStripMenu";
                var toolStripMenuItemText = user.Firstname + " " + user.Lastname + " " + user.Role;
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = toolStripMenuItemText,
                    Image = Properties.Resources.cat2
                };
                toolStripItems[index++] = toolStripMenuItem;
            }

            return toolStripItems;
        }

        private void CreateTaskPanel(TaskModel task, int index)
        {
            var height = GetScrumBoardPanelHeight();
            var width = GetScrumBoardPanelWidth();
            var stageTemp = task.TaskStage;
            var taskPanelName = "taskPanel" + index;
            var taskId = task.TaskId;
            var positionX = width / 40;
            
            switch (stageTemp)
            {
                case TaskModel.TaskStages.Doing:
                    positionX += width / 3;
                    break;
                case TaskModel.TaskStages.Completed:
                    positionX += 2 * width / 3;
                    break;
            }
            var taskPanel = new Panel
            {
                BackColor = ColorTranslator.FromHtml(task.TaskColor),
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Location = new Point(positionX, height / 24 + index * 90),
                Name = taskPanelName,
                Size = new Size(384, 80),
                TabIndex = 0,
                Dock = DockStyle.None
            };
            if (_userRole != "Guest")
            {
                taskPanel.MouseDown += (sender, e) => panel_MouseDown(e);
                taskPanel.MouseMove += panel_MouseMove;
                taskPanel.MouseUp += (sender, e) => panel_MouseUp(sender, e, task); ;
                taskPanel.DoubleClick += delegate
                {
                    panel_DoubleClick(taskId);
                };
            }
            var taskNameTextBox = new MetroTextBox()
            {
                BackColor = Color.White,
                CustomBackground = true,
                Location = new Point(15, 3),
                Multiline = true,
                Name = "taskNameTextBox",
                Size = new Size(340, 43),
                TabIndex = 5,
                Text = task.TaskName,
                Enabled = false
            };

            var priorityPanel = new Panel
            {
                BackColor = getPriorityColor(task.TaskPriority),
                Location = new Point(-1, -1),
                Name = "priorityPanel",
                Size = new Size(10, 79),
                TabIndex = 1,
            };

            var taskDescriptionButton = new MetroButton
            {
                Location = new Point(361, 3),
                Name = "taskDescriptionButton",
                Size = new Size(12, 22),
                TabIndex = 0,
                Text = @"?"
            };
            taskDescriptionButton.Click += delegate
            {
                taskDescriptionButton_Click(task.TaskDesc);
            };

            var taskTimeLabel = new MetroLabel
            {
                AutoSize = true,
                FontSize = MetroLabelSize.Small,
                FontWeight = MetroLabelWeight.Regular,
                Location = new Point(360, 30),
                Name = "taskTimeLabel",
                Size = new Size(13, 15),
                TabIndex = 3,
                Text = (task.TaskEstimatedTime).ToString(),
                TextAlign = ContentAlignment.MiddleRight
            };

            var userPhotos = new[] { "Nowak1", "Nowak2", "Nowak3", "Nowak4" };
            var pictureBoxes = new List<PictureBox>();
            var location = 15;
            foreach (var user in userPhotos)
            {
                var pictureBoxName = user.ToString() + "PhotoBox";
                var pictureBox = new PictureBox
                {
                    //get picture by user id
                    Image = Properties.Resources.cat2,
                    Location = new Point(location, 49),
                    Name = pictureBoxName,
                    Size = new Size(23, 25),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    TabIndex = 4,
                    TabStop = false
                };
                pictureBoxes.Add(pictureBox);
                location += 29;
            }

            var changeColorButton = new Button
            {
                Location = new Point(355, 50),
                Name = "changeColorButton",
                Size = new Size(22, 22),
                TabIndex = 0,
                BackColor = Color.Red
            };
            if (_userRole != "Guest")
            {
                changeColorButton.Click += delegate
                {
                    changeColorButton_Click(taskPanel, taskNameTextBox, task);
                };
            }

            taskPanel.Controls.Add(priorityPanel);
            foreach (var pictureBox in pictureBoxes)
            {
                taskPanel.Controls.Add(pictureBox);
            }
            taskPanel.Controls.Add(taskNameTextBox);
            taskPanel.Controls.Add(taskTimeLabel);
            taskPanel.Controls.Add(taskDescriptionButton);
            taskPanel.Controls.Add(changeColorButton);
            scrumBoardPanel.Controls.Add(taskPanel);
        }

        private void CreateHistoryTaskPanel(dynamic taskList, int index)
        {
            var height = GetScrumBoardPanelHeight();
            var width = GetScrumBoardPanelWidth();
            var stageTemp = (TaskModel.TaskStages)taskList.taskStage;
            var taskPanelName = "taskPanel" + index;
            var positionX = width / 40;
            switch (stageTemp)
            {
                case TaskModel.TaskStages.Doing:
                    positionX += width / 3;
                    break;
                case TaskModel.TaskStages.Completed:
                    positionX += 2 * width / 3;
                    break;
            }
            var taskPanel = new Panel
            {
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Location = new Point(positionX, height / 24 + index * 90),
                Name = taskPanelName,
                Size = new Size(384, 80),
                TabIndex = 0,
                Dock = DockStyle.None
            };

            var taskNameTextBox = new MetroTextBox()
            {
                BackColor = Color.White,
                CustomBackground = true,
                Location = new Point(15, 3),
                Multiline = true,
                Name = "taskNameTextBox",
                Size = new Size(340, 43),
                TabIndex = 5,
                Text = taskList.taskName,
                Enabled = false
            };

            var priorityPanel = new Panel
            {
                BackColor = getPriorityColor(taskList.taskPriority),
                Location = new Point(-1, -1),
                Name = "priorityPanel",
                Size = new Size(10, 79),
                TabIndex = 1,
            };

            var taskDescriptionButton = new MetroButton
            {
                Location = new Point(361, 3),
                Name = "taskDescriptionButton",
                Size = new Size(12, 22),
                TabIndex = 0,
                Text = @"?"
            };
            taskDescriptionButton.Click += delegate
            {
                taskDescriptionButton_Click(taskList.taskDescription);
            };

            var taskTimeLabel = new MetroLabel
            {
                AutoSize = true,
                FontSize = MetroLabelSize.Small,
                FontWeight = MetroLabelWeight.Regular,
                Location = new Point(360, 30),
                Name = "taskTimeLabel",
                Size = new Size(13, 15),
                TabIndex = 3,
                Text = (taskList.estimatedTime).ToString(),
                TextAlign = ContentAlignment.MiddleRight
            };

            var userPhotos = taskList.users;
            var pictureBoxes = new List<PictureBox>();
            var location = 15;
            foreach (var user in userPhotos)
            {
                var pictureBoxName = user.ToString() + "PhotoBox";
                var pictureBox = new PictureBox
                {
                    //get picture by user id
                    Image = Properties.Resources.cat2,
                    Location = new Point(location, 49),
                    Name = pictureBoxName,
                    Size = new Size(23, 25),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    TabIndex = 4,
                    TabStop = false
                };
                pictureBoxes.Add(pictureBox);
                location += 29;
            }

            taskPanel.BackColor = taskList.Color;
            taskNameTextBox.BackColor = taskList.Color;

            if ((TaskModel.TaskStages)taskList.taskStage < TaskModel.TaskStages.Completed)
            {
                var notFinishedTask = new Label
                {
                    Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold, GraphicsUnit.Point, 238),
                    Location = new Point(358, 50),
                    Name = "notFinishedLabel",
                    ForeColor = Color.Red,
                    Size = new Size(35, 35),
                    TabIndex = 3,
                    Text = @"X"
                };
                taskPanel.Controls.Add(notFinishedTask);
            }

            taskPanel.Controls.Add(priorityPanel);
            foreach (var pictureBox in pictureBoxes)
            {
                taskPanel.Controls.Add(pictureBox);
            }
            taskPanel.Controls.Add(taskNameTextBox);
            taskPanel.Controls.Add(taskTimeLabel);
            taskPanel.Controls.Add(taskDescriptionButton);
            scrumBoardPanel.Controls.Add(taskPanel);
        }

        private void PrepareLayout(PaintEventArgs e)
        {
            var borderSize = getScrumBordPanelBorderSize();
            var height = GetScrumBoardPanelHeight();
            var width = GetScrumBoardPanelWidth();
            Pen greyPen = new Pen(_panelColor, borderSize);
            Graphics g = e.Graphics;

            g.DrawLine(greyPen, width / 3, 0, width / 3, height);
            g.DrawLine(greyPen, 2 * width / 3, 0, 2 * width / 3, height);
            g.Dispose();
        }

        private Color getPriorityColor(int priority)
        {
            Color priorityColor;
            if (priority < 40)
            {
                priorityColor = Color.CornflowerBlue;
            }
            else if (priority < 80)
            {
                priorityColor = Color.DarkOrange;
            }
            else
            {
                priorityColor = Color.DarkRed;
            }
            return priorityColor;
        }

        private void CurrentSprint_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                UserModel.Logout();
                Application.Exit();
            }
        }

        private void propertiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_userRole == "ScrumMaster")
            {
                if (propertiesComboBox.SelectedIndex == 1)
                {
                    MainView mainView = new MainView();
                    Hide();
                    mainView.Show();
                }
                //opcja dane uzytkownika
                if (propertiesComboBox.SelectedIndex == 2)
                {
                    UserPanel userPanel = new UserPanel();
                    userPanel.Show();
                }
                
                //opcja wyloguj
                if (propertiesComboBox.SelectedIndex == 3)
                {
                    var reg = new Register();
                    reg.Show();
                }
                if (propertiesComboBox.SelectedIndex == 4)
                {
                    var proj = new ManageProject(_projectId);
                    proj.Show();
                }
                if (propertiesComboBox.SelectedIndex == 5)
                {
                    MessageBox.Show("wylogowano");
                    UserModel.Logout();
                    this.Hide();
                    var l = new Login();
                    l.Show();
                }
            }
            else if (_userRole == "Developer")
            {
                if (propertiesComboBox.SelectedIndex == 1)
                {
                    MainView mainView = new MainView();
                    Hide();
                    mainView.Show();
                }
                //opcja dane uzytkownika
                if (propertiesComboBox.SelectedIndex == 2)
                {
                    UserPanel userPanel = new UserPanel();
                    userPanel.Show();
                }
                //opcja wyloguj
                if (propertiesComboBox.SelectedIndex == 3)
                {
                    MessageBox.Show("wylogowano");
                    UserModel.Logout();
                    this.Hide();
                    var l = new Login();
                    l.Show();
                }
            }
            else
            {
                if (propertiesComboBox.SelectedIndex == 1)
                {
                    MainView mainView = new MainView();
                    Hide();
                    mainView.Show();
                }
                if (propertiesComboBox.SelectedIndex == 2)
                {
                    this.Hide();
                    var l = new Login();
                    l.Show();
                }
            }
        }

        private static string ToHexValue(Color color)
        {
            return "#" + color.R.ToString("X2") +
                   color.G.ToString("X2") +
                   color.B.ToString("X2");
        }
    }
}
