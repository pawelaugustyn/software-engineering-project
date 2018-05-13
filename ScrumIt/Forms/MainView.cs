using System;
using System.Windows.Forms;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumIt.Forms
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            var tasks = TaskAccess.GetProjectTasksByProjectId(1);
            foreach (var task in tasks)
            {
                Proj.Text = "taskId" + task.TaskId.ToString() + task.SprintId.ToString() + ", typ: " + task.TaskType + ", nazwa: " + task.TaskType +
                            "opis" + task.TaskDesc + ", priorytet: " + task.TaskPriority.ToString() + ", estymacja: " + task.TaskEstimatedTime +
                            "stage" + task.TaskStage + "sprintId: "+ '\n';

            }
        }
    }
}
