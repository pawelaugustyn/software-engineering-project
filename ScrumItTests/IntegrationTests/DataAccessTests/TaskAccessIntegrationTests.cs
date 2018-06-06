using System;
using System.Collections.Generic;
using NUnit.Framework;
using ScrumIt;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumItTests.IntegrationTests.DataAccessTests
{
    [TestFixture, IntegrationTest]
    public class TaskAccessIntegrationTests
    {
        private UserModel _user;
        private UserModel _guest;
        private ProjectModel _project;
        private TaskModel _task;
        private SprintModel _sprint;
        private TaskModel _taskAddedToSprint;
        private UserModel _developerToAssigneToTask;
        private const string Password = "tester";

        [OneTimeSetUp]
        public void SetUp()
        {
            _user = new UserModel
            {
                Username = "testScrumMaster".WithUniqueName(),
                Firstname = "scrum",
                Lastname = "master",
                Role = UserRoles.ScrumMaster,
                Email = "testScrumMaster@test.com"
            };

            AppStateProvider.Instance.CurrentUser = _user;

            UserAccess.Add(_user, Password);
            Setup.RegisterToDeleteAfterTestExecution(_user);

            _guest = new UserModel();

            _project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            ProjectAccess.CreateNewProject(_project);
            Setup.RegisterToDeleteAfterTestExecution(_project);

            _task = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskType = "T",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(_task);
            Setup.RegisterToDeleteAfterTestExecution(_task);

            _sprint = new SprintModel
            {
                ParentProjectId = _project.ProjectId,
                EndDateTime = new DateTime(2018, 6, 30),
                StartDateTime = new DateTime(2018, 5, 30)
            };

            SprintAccess.CreateNewSprintForProject(_sprint);
            Setup.RegisterToDeleteAfterTestExecution(_sprint);

            _taskAddedToSprint = new TaskModel
            {
                TaskName = "taskAddedToSprint".WithUniqueName(),
                TaskDesc = "taskAddedToSprintDescription",
                TaskType = "T",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
                SprintId = _sprint.SprintId
            };

            TaskAccess.CreateNewTask(_taskAddedToSprint);
            Setup.RegisterToDeleteAfterTestExecution(_taskAddedToSprint);

            _developerToAssigneToTask = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDevelope@test.com"
            };

            UserAccess.Add(_developerToAssigneToTask, Password);
            Setup.RegisterToDeleteAfterTestExecution(_developerToAssigneToTask);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            UserModel.Logout();
        }

        [Test]
        public void GetProjectTasksByProjectIdShouldReturnCorrectTasks()
        {
            var tasks = TaskAccess.GetProjectTasksByProjectId(_project.ProjectId);

            tasks.ListContains(_task);
        }

        [Test]
        public void GetTaskByIdShouldReturnCorrectTasks()
        {
            var task = TaskAccess.GetTaskById(_task.TaskId);

            Assertion.Equals(task, _task);
        }

        [Test]
        public void UpdateTaskStage()
        {
            var isUpdatedSuccessful = TaskAccess.UpdateTaskStage(_task.TaskId, TaskModel.TaskStages.Doing);

            Assert.That(isUpdatedSuccessful, Is.True, $"Task not updated succesfully: {Messages.Display(_task)}");

            var task = TaskAccess.GetTaskById(_task.TaskId);

            Assertion.NotEquals(task, _task);
        }

        [Test]
        public void GetProjectTasksBySprintIdReturnCorrectTasks()
        {
            var tasks = TaskAccess.GetProjectTasksBySprintId(_sprint.SprintId);

            tasks.ListContains(_taskAddedToSprint);
        }

        [Test]
        public void GetProjectBacklogTasksReturnCorrectTasks()
        {
            var tasks = TaskAccess.GetProjectBacklogTasks(_project.ProjectId);

            tasks.ListContains(_task);
            tasks.ListNotContains(_taskAddedToSprint);
        }

        [Test]
        public void AssignUsersToTask()
        {
            var isAssignedSuccessful = TaskAccess.AssignUsersToTask(_taskAddedToSprint, new List<UserModel> { _developerToAssigneToTask });

            Assert.That(isAssignedSuccessful, Is.True, $"User not assigned to task succesfully: {Messages.Display(_taskAddedToSprint)} {Environment.NewLine}{_developerToAssigneToTask}");
        }

        [Test]
        public void AssignFromBacklogToSprint()
        {
            var taskInBacklog = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskType = "T",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(taskInBacklog);
            Setup.RegisterToDeleteAfterTestExecution(taskInBacklog);

            var tasks = TaskAccess.GetProjectBacklogTasks(_project.ProjectId);

            tasks.ListContains(_task);
            tasks.ListContains(taskInBacklog);

            var isAssignedSuccessful = TaskAccess.AssignFromBacklogToSprint(taskInBacklog.TaskId, _sprint.SprintId);

            Assert.That(isAssignedSuccessful, Is.True, $"Task not assigned from backlog to sprint succesfully: {Messages.Display(taskInBacklog)}");

            tasks = TaskAccess.GetProjectBacklogTasks(_project.ProjectId);

            tasks.ListNotContains(taskInBacklog);
            tasks.ListContains(_task);
        }
    }
}
