using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class CurrentSprint : MetroForm
    {
        public CurrentSprint()
        {
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");
        private Point _mouseDownLocation;
        private Point _mouseUpLocation;

        private void CurrentSprint_Load(object sender, EventArgs e)
        {
            //lista taskow - pobierz z bazki
            var taskList = new[]
            {
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 2,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 5,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 7,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 8,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 10,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 1,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage =1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 0,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 5,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 4,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 4,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 4,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                }
            };

            //pobierz historyczne sprinty
            var historicalSprints = new[]
            {
                new
                {
                    sprintName = "Sprint1"
                },
                new
                {
                    sprintName = "Sprint2"
                }
            };

            //Pobierz backlog
            var backlogTasks = new[]
            {
                new
                {
                    TaskName = "Task1"
                },
                new
                {
                    TaskName = "Task2"
                }
            };

            //Pobierz liste użytkowników danego projektu 
            var users = new[]
            {
                new
                {
                    UserName = "BM",
                    FirstName = "Bartosz",
                    LastName = "Mindur",
                    Role = "Admin"
                },
                new
                {
                    UserName = "BM",
                    FirstName = "Bartosz",
                    LastName = "Mindur",
                    Role = "Admin"
                }
            };

            for (var i = 0; i < taskList.Length; i++)
            {
                CreateTaskPanel(taskList[i], i);
            }

            historyMenuStrip.Items.AddRange(CreateHistoryMenu(historicalSprints));
            backlogMenuStrip.Items.AddRange(createBacklogMenu(backlogTasks));
            userListMenuStrip.Items.AddRange(createUserListMenu(users));
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
            //pobierz taski z bazy dla najnowszego sprintu
            var taskList = new[]
{
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 0,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 8,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage =2
                },
                new
                {
                    taskName = "Nowy Task",
                    taskDescription = "Task Description",
                    taskPriority = 7,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 3
                }
            };
            scrumBoardPanel.Controls.Clear();

            for (var i = 0; i < taskList.Length; i++)
            {
                CreateTaskPanel(taskList[i], i);
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
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

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            var width = scrumBoardPanel.ClientRectangle.Width;
            if (_mouseUpLocation.X < width / 4)
            {
                ((Panel)sender).Location = new Point(width / 30, ((Panel)sender).Location.Y);
            }

            if (_mouseUpLocation.X > width / 4 && _mouseUpLocation.X < 7 * width / 12)
            {
                ((Panel)sender).Location = new Point(width / 30 + width / 3, ((Panel)sender).Location.Y);
            }
            if (_mouseUpLocation.X > 7 * width / 12)
            {
                ((Panel)sender).Location = new Point(width / 30 + 2 * width / 3, ((Panel)sender).Location.Y);
            }
            //change task stage
        }

        private void changeColorButton_Click(Panel taskPanel, MetroTextBox textBox)
        {
            var color = new Color();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
            taskPanel.BackColor = color;
            textBox.BackColor = color;
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
            //dodaj taska nowy form
        }

        private void historyToolStripMenuItem_Click(string sprintName)
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
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 1,
                    Color = Color.Aquamarine
                },
                new
                {
                    taskName = "Stary Task",
                    taskDescription = "Task Description",
                    taskPriority = 4,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
                    taskStage = 2,
                    Color = Color.Aqua
                },
                new
                {
                    taskName = "Stary Task",
                    taskDescription = "Task Description",
                    taskPriority = 10,
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"},
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

        private ToolStripItem[] CreateHistoryMenu(dynamic history)
        {
            var toolStripItems = new ToolStripItem[history.Length];
            for (var i = 0; i < history.Length; i++)
            {
                var toolStripMenuItemName = history[i].sprintName + "ToolStripMenuItem";
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = history[i].sprintName
                };
                toolStripMenuItem.Click += delegate
                {
                     historyToolStripMenuItem_Click(toolStripMenuItemName);
                 };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
        }

        private ToolStripItem[] createBacklogMenu(dynamic backlog)
        {
            var toolStripItems = new ToolStripItem[backlog.Length];
            for (var i = 0; i < backlog.Length; i++)
            {
                var toolStripMenuItemName = backlog[i].TaskName + "ToolStripMenu";
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = backlog[i].TaskName
                };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
        }

        private ToolStripItem[] createUserListMenu(dynamic userList)
        {
            var toolStripItems = new ToolStripItem[userList.Length];
            for (var i = 0; i < userList.Length; i++)
            {
                var toolStripMenuItemName = userList[i].UserName + "ToolStripMenu";
                var toolStripMenuItemText = userList[i].FirstName + " " + userList[i].LastName + " " + userList[i].Role;
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = toolStripMenuItemName,
                    Text = toolStripMenuItemText,
                    Image = Properties.Resources.image
                };
                toolStripItems[i] = toolStripMenuItem;
            }

            return toolStripItems;
        }

        private void CreateTaskPanel(dynamic taskList, int index)
        {
            var height = GetScrumBoardPanelHeight();
            var width = GetScrumBoardPanelWidth();
            int stageTemp = taskList.taskStage;
            var taskPanelName = "taskPanel" + index;
            var positionX = width / 30;
            switch (stageTemp)
            {
                case 2:
                    positionX += width / 3;
                    break;
                case 3:
                    positionX += 2 * width / 3;
                    break;
            }
            var taskPanel = new Panel
            {
                BackColor = Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Location = new Point(positionX, height / 24 + index * 90),
                Name = taskPanelName,
                Size = new Size(384, 80),
                TabIndex = 0,
                Dock = DockStyle.None
            };
            taskPanel.MouseDown += panel_MouseDown;
            taskPanel.MouseMove += panel_MouseMove;
            taskPanel.MouseUp += panel_MouseUp;

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
                    Image = Properties.Resources.image,
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
            changeColorButton.Click += delegate
            {
                changeColorButton_Click(taskPanel, taskNameTextBox);
            };

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
            int stageTemp = taskList.taskStage;
            var taskPanelName = "taskPanel" + index;
            var positionX= width / 30;
            switch (stageTemp)
            {
                case 2:
                    positionX += width / 3;
                    break;
                case 3:
                    positionX += 2 * width / 3;
                    break;
            }
            var taskPanel = new Panel
            {
                BackColor = Color.White,
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
                    Image = Properties.Resources.image,
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

            if (taskList.taskStage < 3)
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
            if (priority < 4)
            {
                priorityColor = Color.CornflowerBlue;
            }else if (priority < 8)
            {
                priorityColor = Color.DarkOrange;
            }
            else
            {
                priorityColor = Color.DarkRed;
            }
            return priorityColor;
        }

        private static string ToHexValue(Color color)
        {
            return "#" + color.R.ToString("X2") +
                   color.G.ToString("X2") +
                   color.B.ToString("X2");
        }
    }
}
