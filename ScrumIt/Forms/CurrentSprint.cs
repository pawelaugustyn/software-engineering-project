using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ScrumIt.Forms
{
    public partial class CurrentSprint : MetroForm
    {
        public CurrentSprint()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var height = panel1.ClientRectangle.Height;
            var width = panel1.ClientRectangle.Width;

            Pen blackpen = new Pen(Color.Black, 3);
            Graphics g = e.Graphics;

            g.DrawLine(blackpen, width / 3, 0, width / 3, height);
            g.DrawLine(blackpen, 2 * width / 3, 0, 2 * width / 3, height);

            g.Dispose();

            //lista taskow - pobierz z bazki
            var taskLisk = new
            {
                taskName = "Nowy Task",
                taskDescription = "Task Description",
                taskPriority = "High",
                estimatedTime = 10
            };

            var panel = new Panel();
            panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //panel.Controls.Add(this.userPhotoPictureBox);
            //panel.Controls.Add(this.taskTimeLabel);
            //panel.Controls.Add(this.taskPriorityLabel);
            //panel.Controls.Add(this.taskNameLabel);
            //panel.Controls.Add(this.taskDescriptionButton);
            panel.Location = new System.Drawing.Point(46, 37);
            panel.Name = "taskPanel";
            panel.Size = new System.Drawing.Size(183, 195);
            panel.TabIndex = 0;
            panel1.Controls.Add(panel);

        }

        private void addTaskButton_Click(object sender, System.EventArgs e)
        {
            //przekierowanie do formsa task
        }
    }
}
