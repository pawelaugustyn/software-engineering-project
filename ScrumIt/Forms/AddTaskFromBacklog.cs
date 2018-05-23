using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class AddTaskFromBacklog : MetroForm
    {
        private int _taskId;
        private int _sprintId;

        public AddTaskFromBacklog(int taskId, int sprintId)
        {
            _taskId = taskId;
            _sprintId = sprintId;
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void AddTaskFromBacklog_Load(object sender, System.EventArgs e)
        {
            addTaskButton.BackColor = _panelColor;

            //pobierz dany task z bazki
            var task = new TaskModel
            {
                TaskName = "Nowy Task",
                TaskType = "High",
                TaskDesc = "Task Description",
                TaskPriority = 5,
                TaskEstimatedTime = 10
            };

            taskNameTextBox.Text = task.TaskName;
            taskDescriptionTextBox.Text = task.TaskDesc;
            priorityTextBox.Text = task.TaskPriority.ToString();
            estimatedTimeTextBox.Text = task.TaskEstimatedTime.ToString();

            taskNameTextBox.BackColor = Color.White;
            taskDescriptionTextBox.BackColor = Color.White;
            priorityTextBox.BackColor = Color.White;
            estimatedTimeTextBox.BackColor = Color.White;
        }

        private void addTaskButton_Click(object sender, System.EventArgs e)
        {
            //dodaj task do bazki
            this.Close();
        }
    }
}
