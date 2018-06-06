using System;
using System.Collections.Generic;
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
        private string _userRole;

        public AddTaskFromBacklog(int taskId, int sprintId)
        {
            _userRole = AppStateProvider.Instance.CurrentUser.Role.ToString();
            _taskId = taskId;
            _sprintId = sprintId;
            InitializeComponent();
        }

        private readonly Color _panelColor = ColorTranslator.FromHtml("#4AC1C1");

        private void AddTaskFromBacklog_Load(object sender, System.EventArgs e)
        {
            if (_userRole == "Guest")
            {
                addTaskButton.BackColor = ColorTranslator.FromHtml("#eeeeee");
                addTaskButton.ForeColor = Color.DarkGray;
                var toolTip = new ToolTip();
                toolTip.SetToolTip(addTaskButton, "Zaloguj się aby dodać zadanie");
            }
            else
            {
                addTaskButton.BackColor = _panelColor;
            }

            try
            {
                TaskModel task = TaskModel.GetTaskById(_taskId);


                taskNameTextBox.Text = task.TaskName;
                taskDescriptionTextBox.Text = task.TaskDesc;
                priorityTextBox.Text = task.TaskPriority.ToString();
                estimatedTimeTextBox.Text = task.TaskEstimatedTime.ToString();

                taskNameTextBox.BackColor = Color.White;
                taskDescriptionTextBox.BackColor = Color.White;
                priorityTextBox.BackColor = Color.White;
                estimatedTimeTextBox.BackColor = Color.White;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void addTaskButton_Click(object sender, System.EventArgs e)
        {
            if (_userRole != "Guest")
            {
                try
                {
                    TaskModel.AssignFromBacklogToSprint(_taskId, _sprintId);
                }
                catch (ArgumentException error)
                {
                    MessageBox.Show(@""+error.Message+"");
                }

                Close();
            }
        }
    }
}
