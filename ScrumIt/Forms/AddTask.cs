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
            short taskPriority = -1;
            if (priorityTextBox.Text == "" || !Int16.TryParse(priorityTextBox.Text, out taskPriority))
            {
                MessageBox.Show(@"Uzupełnij stopień skomplikowania zadania");
                validationFlag = false;
            }
            else
            if (taskPriority > 100 || taskPriority < 1)
            {
                MessageBox.Show(@"Możliwa wartość stopnia skomplikowania to liczba całkownita między 0 a 100");
                validationFlag = false;
            }

            short taskEstimatedTime = -1;
            if (estimatedTimeTextBox.Text == "" || !Int16.TryParse(estimatedTimeTextBox.Text, out taskEstimatedTime))
            {
                MessageBox.Show(@"Uzupełnij przewidywany czas zadania");
                validationFlag = false;
            }
            else
            if (taskEstimatedTime > 100 || taskEstimatedTime < 1)
            {
                MessageBox.Show(@"Możliwa wartość przewidywanego czasu zadania to liczba całkownita między 0 a 100");
                validationFlag = false;
            }

            if (!currentSprintRadio.Checked && !backlogRadio.Checked)
            {
                MessageBox.Show(@"Zadanie musi być dodane do sprintu bądź backlogu!");
                validationFlag = false;
            }

            var sprintId = 0;
            var projectId = _projectId;
            if (currentSprintRadio.Checked)
            {
                sprintId = _sprintId;
            }

            if (validationFlag)
            {
                try
                {
                    var task = new TaskModel
                    {
                        TaskName = taskName,
                        TaskDesc = taskDescription,
                        TaskType = "T",
                        TaskPriority = taskPriority,
                        TaskEstimatedTime = taskEstimatedTime,
                        TaskStage = TaskModel.TaskStages.ToDo,
                        SprintId = sprintId,
                        TaskColor = "#ffffff",
                        BacklogProjectId = projectId
                    };
                    TaskModel.CreateNewTask(task, new List<UserModel>());
                    CurrentSprint.refresh = true;
                    Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

            }
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
