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

        private void CurrentSprint_Load(object sender, EventArgs e)
        {
            //lista taskow - pobierz z bazki
            var taskList = new[]
            {
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "Low",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "Medium",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                },
                new
                {
                    taskName = "Nowy Task",
                    taskType = "High",
                    taskDescription = "Task Description",
                    taskPriority = "High",
                    estimatedTime = 10,
                    users = new[] {"Mindur1","Mindur2","Mindur3","Mindur4"}
                }
            };

            for (var i = 0; i < taskList.Length; i++)
            {
                createTaskPanel(taskList, i);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //prepareLayout(e);
        }

        private void addTaskButton_Click(object sender, System.EventArgs e)
        {
            //przekierowanie do formsa task
        }

        private void createTaskPanel(dynamic taskList, int index)
        {
            var height = scrumBoardPanel.ClientRectangle.Height;
            var width = scrumBoardPanel.ClientRectangle.Width;

            var taskPanelName = "taskPanel" + index;

            var taskPanel = new Panel
            {
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                Location = new System.Drawing.Point(width / 60, height / 10 + index * 90),
                Name = taskPanelName,
                Size = new System.Drawing.Size(384, 80),
                TabIndex = 0,
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
                Text = taskList[index].taskName

            };

            var priorityPanel = new Panel
            {
                BackColor = getPriorityColor(taskList[index].taskPriority),
                Location = new System.Drawing.Point(-1, -1),
                Name = "priorityPanel",
                Size = new System.Drawing.Size(10, 79),
                TabIndex = 1,
            };

            var taskDescriptionButton = new MetroButton
            {
                Location = new System.Drawing.Point(361, 3),
                Name = "taskDescriptionButton",
                Size = new System.Drawing.Size(12, 22),
                TabIndex = 0,
                Text = "?",
            };
            taskDescriptionButton.Click += taskDescriptionButton_Click;

            var taskTimeLabel = new MetroLabel
            {
                AutoSize = true,
                FontSize = MetroFramework.MetroLabelSize.Small,
                FontWeight = MetroFramework.MetroLabelWeight.Regular,
                Location = new System.Drawing.Point(360, 56),
                Name = "taskTimeLabel",
                Size = new System.Drawing.Size(13, 15),
                TabIndex = 3,
                Text = (taskList[index].estimatedTime).ToString(),
                TextAlign = System.Drawing.ContentAlignment.MiddleRight

            };

            var userPhotos = taskList[index].users;
            var pictureBoxes = new List<PictureBox>();
            var location = 15;
            foreach (var user in userPhotos)
            {
                var pictureBoxName = user.ToString() + "PhotoBox";
                var pictureBox = new PictureBox
                {
                    Image = global::ScrumIt.Properties.Resources.image,
                    Location = new System.Drawing.Point(location, 49),
                    Name = pictureBoxName,
                    Size = new System.Drawing.Size(23, 25),
                    SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
                    TabIndex = 4,
                    TabStop = false
                };
                pictureBoxes.Add(pictureBox);
                location += 29;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var color = new Color();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }

            labelTest.Text = ToHexValue(color);
            labelTest.BackColor = ColorTranslator.FromHtml("#FF0000");
        }

        private void taskDescriptionButton_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Dziala");
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            var borderSize = 2;
            var panelColor = ColorTranslator.FromHtml("#00aba9");
            var height = scrumBoardPanel.ClientRectangle.Height;
            var width = scrumBoardPanel.ClientRectangle.Width;
            var toDoLabel = new MetroLabel
            {
                Text = "To Do",
                Size = new Size(width / 3 , height / 12 - borderSize),
                Location = new Point(borderSize, borderSize),
                TextAlign = ContentAlignment.MiddleCenter,
                FontWeight = MetroLabelWeight.Bold,
                CustomForeColor = true,
                CustomBackground = true,
                ForeColor = Color.White,
                BackColor = panelColor,
                FontSize = MetroLabelSize.Tall
            };
            scrumBoardPanel.Controls.Add(toDoLabel);

            var inProgressLabel = new MetroLabel
            {
                Text = "In Progress",
                Size = new Size(width / 3 , height / 12 - borderSize),
                Location = new Point(width / 3 + borderSize, borderSize),
                TextAlign = ContentAlignment.MiddleCenter,
                FontWeight = MetroLabelWeight.Bold,
                CustomForeColor = true,
                CustomBackground = true,
                ForeColor = Color.White,
                BackColor = panelColor,
                FontSize = MetroLabelSize.Tall
            };
            scrumBoardPanel.Controls.Add(inProgressLabel);

            var completedLabel = new MetroLabel
            {
                Text = "Completed",
                Size = new Size(width / 3 , height / 12 - borderSize),
                Location = new Point(2 * width / 3 + borderSize, borderSize),
                TextAlign = ContentAlignment.MiddleCenter,
                FontWeight = MetroLabelWeight.Bold,
                CustomForeColor = true,
                CustomBackground = true,
                ForeColor = Color.White,
                BackColor = panelColor,
                FontSize = MetroLabelSize.Tall
            };
            scrumBoardPanel.Controls.Add(completedLabel);
        }

        private void prepareLayout(PaintEventArgs e)
        {
            var borderSize = 2;
            var panelColor = ColorTranslator.FromHtml("#00aba9");
            var height = scrumBoardPanel.ClientRectangle.Height;
            var width = scrumBoardPanel.ClientRectangle.Width;
            Pen greyPen = new Pen(panelColor, borderSize);
            Graphics g = e.Graphics;

            g.DrawLine(greyPen, width / 3, borderSize, width / 3, height);
            g.DrawLine(greyPen, 2 * width / 3, borderSize, 2 * width / 3, height);
            g.Dispose();
            
        }

        private Color getPriorityColor(string priority)
        {
            Color priorityColor = new Color();
            switch (priority)
            {
                case ("High"):
                    priorityColor = Color.DarkRed;
                    break;
                case ("Medium"):
                    priorityColor = Color.DarkOrange;
                    break;
                default:
                    priorityColor = Color.CornflowerBlue;
                    break;
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
