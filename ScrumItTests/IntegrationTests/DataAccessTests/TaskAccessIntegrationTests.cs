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

            _project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#2299fc"
            };

            ProjectAccess.CreateNewProject(_project);
            Setup.RegisterToDeleteAfterTestExecution(_project);

            _task = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
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
        public void GetTaskByIdShouldReturnCorrectTasks()
        {
            var task = TaskAccess.GetTaskById(_task.TaskId);

            Assertion.Equals(task, _task);
        }

        [Test]
        public void UpdateTaskStage()
        {
            var taskToUpdateStage = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(taskToUpdateStage);
            Setup.RegisterToDeleteAfterTestExecution(taskToUpdateStage);

            var isUpdatedSuccessful = TaskAccess.UpdateTaskStage(taskToUpdateStage.TaskId, TaskModel.TaskStages.Doing);

            Assert.That(isUpdatedSuccessful, Is.True,
                $"Task not updated succesfully: {Messages.Display(taskToUpdateStage)}");

            var task = TaskAccess.GetTaskById(taskToUpdateStage.TaskId);

            Assertion.NotEquals(task, taskToUpdateStage);
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
        public void AssignUsersToTaskWhenAssignNewUser()
        {
            var isAssignedSuccessful =
                TaskAccess.AssignUsersToTask(_taskAddedToSprint, new List<UserModel> { _developerToAssigneToTask });
            Assert.That(isAssignedSuccessful, Is.True,
                $"User not assigned to task succesfully: {Messages.Display(_taskAddedToSprint)} {Environment.NewLine}{_developerToAssigneToTask}");
        }

        [Test]
        public void AssignUsersToTaskWhenAssignNewUserAndDeassignOldUser()
        {
            var developer2ToAssigneToTask = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDevelope@test.com"
            };

            UserAccess.Add(developer2ToAssigneToTask, Password);
            Setup.RegisterToDeleteAfterTestExecution(developer2ToAssigneToTask);

            var developer3ToAssigneToTask = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDevelope@test.com"
            };

            var taskAddedToSprint = new TaskModel
            {
                TaskName = "taskAddedToSprint".WithUniqueName(),
                TaskDesc = "taskAddedToSprintDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
                SprintId = _sprint.SprintId
            };

            TaskAccess.CreateNewTask(taskAddedToSprint);
            Setup.RegisterToDeleteAfterTestExecution(taskAddedToSprint);

            UserAccess.Add(developer3ToAssigneToTask, Password);
            Setup.RegisterToDeleteAfterTestExecution(developer3ToAssigneToTask);

            var isAssignedSuccessful = TaskAccess.AssignUsersToTask(taskAddedToSprint,
                new List<UserModel> { developer2ToAssigneToTask, developer3ToAssigneToTask });
            Assert.That(isAssignedSuccessful, Is.True,
                $"User not assigned to task succesfully: {Messages.Display(taskAddedToSprint)} {Environment.NewLine}{_developerToAssigneToTask}");
        }

        [Test]
        public void AssignUsersToTaskWhenUserIdsGivenWhenAssignNewUserAndDeassignOldUser()
        {
            var developer2ToAssigneToTask = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDevelope@test.com"
            };

            UserAccess.Add(developer2ToAssigneToTask, Password);
            Setup.RegisterToDeleteAfterTestExecution(developer2ToAssigneToTask);

            var developer3ToAssigneToTask = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDevelope@test.com"
            };

            var taskAddedToSprint = new TaskModel
            {
                TaskName = "taskAddedToSprint".WithUniqueName(),
                TaskDesc = "taskAddedToSprintDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
                SprintId = _sprint.SprintId
            };

            TaskAccess.CreateNewTask(taskAddedToSprint);
            Setup.RegisterToDeleteAfterTestExecution(taskAddedToSprint);

            UserAccess.Add(developer3ToAssigneToTask, Password);
            Setup.RegisterToDeleteAfterTestExecution(developer3ToAssigneToTask);

            var isAssignedSuccessful = TaskAccess.AssignUsersToTask(taskAddedToSprint,
                new List<int> { developer2ToAssigneToTask.UserId, developer3ToAssigneToTask.UserId });
            Assert.That(isAssignedSuccessful, Is.True,
                $"User not assigned to task succesfully: {Messages.Display(taskAddedToSprint)} {Environment.NewLine}{_developerToAssigneToTask}");
        }

        [Test]
        public void AssignFromBacklogToSprint()
        {
            var taskInBacklog = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
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

            Assert.That(isAssignedSuccessful, Is.True,
                $"Task not assigned from backlog to sprint succesfully: {Messages.Display(taskInBacklog)}");

            tasks = TaskAccess.GetProjectBacklogTasks(_project.ProjectId);

            tasks.ListNotContains(taskInBacklog);
            tasks.ListContains(_task);
        }

        [Test]
        public void SetNewColour()
        {
            var taskToEditColor = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(taskToEditColor);
            Setup.RegisterToDeleteAfterTestExecution(taskToEditColor);

            const string colour = "#0000ff";
            var isSetSuccessful = TaskAccess.SetNewColour(taskToEditColor, colour);
            Assert.That(isSetSuccessful, Is.True,
                $"Task color should be changed to {colour}: {Messages.Display(taskToEditColor)}");

            var taskAfterSet = TaskAccess.GetTaskById(taskToEditColor.TaskId);
            Assertion.Equals(taskAfterSet, taskToEditColor);
        }

        [Test]
        public void UpdateTask()
        {
            var taskToUpdate = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(taskToUpdate);
            Setup.RegisterToDeleteAfterTestExecution(taskToUpdate);

            taskToUpdate.TaskName = "updatedTask".WithUniqueName();
            taskToUpdate.TaskDesc = "updatedTaskDescription";
            taskToUpdate.TaskPriority = int.Parse("30");
            taskToUpdate.TaskEstimatedTime = int.Parse("20");

            var isUpdatedSuccessful = TaskAccess.UpdateTask(taskToUpdate);

            Assert.That(isUpdatedSuccessful, Is.True,
                $"Task not updated succesfully: {Messages.Display(taskToUpdate)}");

            var task = TaskAccess.GetTaskById(taskToUpdate.TaskId);

            Assertion.Equals(task, taskToUpdate);
        }

        [Test]
        public void RemoveTask()
        {
            var taskToRemove = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(taskToRemove);
            TaskAccess.RemoveTask(taskToRemove.TaskId);

            var task = TaskAccess.GetTaskById(taskToRemove.TaskId);

            Assertion.NotEquals(task, taskToRemove);
            Assertion.Equals(task, new TaskModel());
        }

        [Test]
        public void X_UpdateTaskStageAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            //Update task stage
            var operationSuccessful = true;

            Assert.Throws<ArgumentException>(
                delegate
                {
                    operationSuccessful = TaskAccess.UpdateTaskStage(addedTask.TaskId, TaskModel.TaskStages.Completed);
                },
                "Exception should be thrown, because it should not be possible to update task stage as guest.");
            Assert.That(operationSuccessful, Is.True,
                $"Updating task stage as guest not be successful {Messages.Display(addedTask)}.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_CreateNewTaskAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            //Create new task
            var operationSuccessful = true;
            var taskToAdd = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            Assert.Throws<ArgumentException>(
                delegate { operationSuccessful = TaskAccess.CreateNewTask(taskToAdd); },
                "Exception should be thrown, because it should not be possible to create task as guest.");
            Assert.That(operationSuccessful, Is.True,
                $"Creating task as guest not be successful {Messages.Display(addedTask)}.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_AssignUsersToTaskAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            var operationSuccessful = true;

            var user = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDeveloper@test.com"
            };

            Assert.Throws<ArgumentException>(
                delegate
                {
                    operationSuccessful =
                        TaskAccess.AssignUsersToTask(addedTask, new List<UserModel> { user });
                },
                "Exception should be thrown, because it should not be possible to assign user to task as guest.");
            Assert.That(operationSuccessful, Is.True,
                $"Assigning user to task as guest not be successful {Messages.Display(addedTask)}.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_AssignUsersToTaskByIdAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            var operationSuccessful = true;

            var user = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDeveloper@test.com"
            };

            Assert.Throws<ArgumentException>(
                delegate
                {
                    operationSuccessful =
                        TaskAccess.AssignUsersToTask(addedTask, new List<int>(user.UserId));
                },
                "Exception should be thrown, because it should not be possible to assign user to task as guest.");
            Assert.That(operationSuccessful, Is.True,
                $"Assigning user to task as guest not be successful {Messages.Display(addedTask)}.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_AssignFromBacklogToSprintAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            var operationSuccessful = true;

            Assert.Throws<ArgumentException>(
                delegate
                {
                    operationSuccessful = TaskAccess.AssignFromBacklogToSprint(addedTask.TaskId, _sprint.SprintId);
                },
                "Exception should be thrown, because it should not be possible to assign task from backlog to sprint as guest.");
            Assert.That(operationSuccessful, Is.True,
                $"Assigning task from backlog to sprint as guest not be successful {Messages.Display(addedTask)}.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_RemoveTasktAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            Assert.Throws<ArgumentException>(
                delegate
                {
                    TaskAccess.RemoveTask(addedTask.TaskId);
                },
                "Exception should be thrown, because it should not be possible to assign task from backlog to sprint as guest.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_SetNewColourAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            var operationSuccessful = true;

            Assert.Throws<ArgumentException>(
                delegate
                {
                    operationSuccessful = TaskAccess.SetNewColour(addedTask, "#076e4e");
                },
                "Exception should be thrown, because it should not be possible to set new task color as guest.");
            Assert.That(operationSuccessful, Is.True,
                $"Setting new task color as guest not be successful {Messages.Display(addedTask)}.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_UpdateTaskAsGuestShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var addedTask = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = _project.ProjectId,
            };

            TaskAccess.CreateNewTask(addedTask);
            Setup.RegisterToDeleteAfterTestExecution(addedTask);

            AppStateProvider.Instance.CurrentUser = new UserModel();

            var operationSuccessful = true;
            var updatedTask = new TaskModel
            {
                BacklogProjectId = addedTask.BacklogProjectId,
                SprintId = addedTask.SprintId,
                TaskColor = addedTask.TaskColor,
                TaskDesc = addedTask.TaskDesc,
                TaskEstimatedTime = addedTask.TaskEstimatedTime,
                TaskId = addedTask.TaskId,
                TaskName = "updatedTask".WithUniqueName(),
                TaskPriority = addedTask.TaskPriority,
                TaskStage = addedTask.TaskStage
            };

            Assert.Throws<UnauthorizedAccessException>(
                delegate
                {
                    operationSuccessful = TaskAccess.UpdateTask(updatedTask);
                },
                "Exception should be thrown, because it should not be possible to update task color as guest.");
            Assert.That(operationSuccessful, Is.True,
                $"Updating task as guest not be successful {Messages.Display(addedTask)}.");

            var task = TaskAccess.GetTaskById(addedTask.TaskId);
            Assertion.Equals(task, addedTask);

            AppStateProvider.Instance.CurrentUser = _user;
        }
    }
}
