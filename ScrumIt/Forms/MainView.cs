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
            Proj.Text = Environment.NewLine + " Wszystkie Projekty: " + Environment.NewLine;
            var allProjects = ProjectAccess.GetAllProjects();
            foreach (var project in allProjects)
            {
                Proj.Text += "Id: " + project.ProjectId.ToString() + ", nazwa: " + project.ProjectName + ", kolor: " + project.ProjectColor + Environment.NewLine;
            }
            Proj.Text += Environment.NewLine + "Zadania projektu o id=1: " + Environment.NewLine;
            var tasks = TaskAccess.GetProjectTasksByProjectId(1);
            foreach (var task in tasks)
            {
                Proj.Text += "taskId" + task.TaskId.ToString() + task.SprintId.ToString() + ", typ: " + task.TaskType + ", nazwa: " + task.TaskType +
                            "opis" + task.TaskDesc + ", priorytet: " + task.TaskPriority.ToString() + ", estymacja: " + task.TaskEstimatedTime +
                            "stage" + task.TaskStage + "sprintId: "+ Environment.NewLine;
            }
            Proj.Text += Environment.NewLine  + " Projekty użytkownika o id=1: "+ Environment.NewLine;
            var userProjects = ProjectAccess.GetProjectsByUserId(1);
            foreach (var project in userProjects)
            {
                Proj.Text += "Id: " + project.ProjectId.ToString() + ", nazwa: " + project.ProjectName + ", kolor: " + project.ProjectColor + Environment.NewLine;
            }
        }
    }
}
