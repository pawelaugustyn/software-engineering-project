using System;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var borderSize = 2;
            var panelColor = ColorTranslator.FromHtml("#00aba9");
            var height = scrumBoardPanel.ClientRectangle.Height;
            var width = scrumBoardPanel.ClientRectangle.Width;
            Pen greyPen = new Pen(panelColor, borderSize);
            Graphics g = e.Graphics;

            g.DrawLine(greyPen, width / 3, borderSize, width / 3, height);
            g.DrawLine(greyPen, 2 * width / 3, borderSize, 2 * width / 3, height);
            g.DrawLine(greyPen, borderSize, height/12, width, height/12);
            g.DrawRectangle(greyPen, ClientRectangle.X+ borderSize, ClientRectangle.Y+ borderSize, width- 2*borderSize, height- 2*borderSize);
            g.Dispose();
            var toDoLabel = new MetroLabel
            {
                Text = "To Do",
                Size = new Size(width/3- borderSize, height / 12- borderSize),
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
                Size = new Size(width / 3 - borderSize, height / 12 - borderSize),
                Location = new Point(width / 3+borderSize, borderSize),
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
                Size = new Size(width / 3 - borderSize, height / 12 - borderSize),
                Location = new Point(2*width / 3 + borderSize, borderSize),
                TextAlign = ContentAlignment.MiddleCenter,
                FontWeight = MetroLabelWeight.Bold,
                CustomForeColor = true,
                CustomBackground = true,
                ForeColor = Color.White,
                BackColor = panelColor,
                FontSize = MetroLabelSize.Tall
            };
            scrumBoardPanel.Controls.Add(completedLabel);


            //lista taskow - pobierz z bazki
            var taskList = new
            {
                taskName = "Nowy Task",
                taskDescription = "Task Description",
                taskPriority = "High",
                estimatedTime = 10
            };

            createPanel(taskList);


            //this.panel1.Controls.Add(this.taskPanel);


        }

        private void addTaskButton_Click(object sender, System.EventArgs e)
        {
            //przekierowanie do formsa task
        }

        private void createPanel(Object TaskList)
        {
            //var panel = new Panel
            //{
            //    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
            //    Location = new System.Drawing.Point(0, 0),
            //    Name = "taskPanel",
            //    Size = new System.Drawing.Size(183, 195),
            //    TabIndex = 0,
            //};
            //var taskType = new MetroLabel
            //{

            //};
            //var taskTimeLabel = new Label
            //{
            //    AutoSize = true,
            //    Location = new System.Drawing.Point(13, 77),
            //    Name = "taskTimeLabel",
            //    Size = new System.Drawing.Size(99, 19),
            //    TabIndex = 3,
            //    Text = "Estimeted Time"
            //};
            //var taskPriorityLabel = new Label
            //{
            //    AutoSize = true,
            //    Location = new System.Drawing.Point(13, 44),
            //    Name = "taskPriorityLabel",
            //    Size = new System.Drawing.Size(51, 19),
            //    TabIndex = 2,
            //    Text = "Priority"
            //};

            //var taskNameLabel = new Label
            //{
            //    AutoSize = true,
            //    Location = new System.Drawing.Point(13, 13),
            //    Name = "taskNameLabel",
            //    Size = new System.Drawing.Size(34, 19),
            //    TabIndex = 1,
            //    Text = "Task"
            //};

            //var taskDescriptionButton = new MetroButton
            //{
            //    Location = new System.Drawing.Point(94, 157),
            //    Name = "taskDescriptionButton",
            //    Size = new System.Drawing.Size(75, 23),
            //    TabIndex = 0,
            //    Text = "Opis",
            //    Theme = MetroFramework.MetroThemeStyle.Light,
            //};
            //var userPhotoPitureBox = new PictureBox
            //{
            //    Image = global::ScrumIt.Properties.Resources.image,
            //    Location = new System.Drawing.Point(12, 101),
            //    Name = "userPhotoPictureBox",
            //    Size = new System.Drawing.Size(76, 79),
            //    SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage,
            //    TabIndex = 4,
            //    TabStop = false
            //};

            //panel.Controls.Add(taskType);
            //panel.Controls.Add(taskTimeLabel);
            //panel.Controls.Add(taskPriorityLabel);
            //panel.Controls.Add(taskNameLabel);
            //panel.Controls.Add(taskDescriptionButton);
            //panel.Controls.Add(userPhotoPictureBox);
            //panel1.Controls.Add(panel);
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

        private void prepareLayout() { }

        public static string ToHexValue(Color color)
        {
            return "#" + color.R.ToString("X2") +
                   color.G.ToString("X2") +
                   color.B.ToString("X2");
        }
    }
}
