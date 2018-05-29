using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class AddTask : MetroForm
    {
        private int _projectId;
        private int _sprintId;

        public AddTask(int projectId, int sprintId)
        {
            _projectId = projectId;
            _sprintId = sprintId;
            InitializeComponent();
        }


        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void TaskForm_Load(object sender, EventArgs e)
        {
            addTaskButton.BackColor = _panelColor;
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

            var sprintId = 0;
            if (currentSptintRadio.Checked)
            {
                sprintId = _sprintId;
            }

            if (validationFlag)
            {
                var task = new TaskModel
                {
                    TaskName = taskName,
                    TaskDesc = taskDescription,
                    TaskType = "T",
                    TaskPriority = Int16.Parse(taskPriority),
                    TaskEstimatedTime = Int16.Parse(taskEstimatedTime),
                    TaskStage = TaskModel.TaskStages.ToDo,
                    SprintId = sprintId,
                    TaskColor = "#ffffff"
                };
                TaskModel.CreateNewTask(task, new List<UserModel>());
                Close();
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

        private void userListMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }
    }
}
