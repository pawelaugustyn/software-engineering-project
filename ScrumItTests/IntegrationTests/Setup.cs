using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScrumIt;
using ScrumIt.Models;

namespace ScrumItTests.IntegrationTests
{
    [SetUpFixture]
    public class Setup
    {
        private static AppStateProvider _state;
        private static List<ProjectModel> _projectList = new List<ProjectModel>();
        private static List<SprintModel> _sprintModelList = new List<SprintModel>();
        private static List<TaskModel> _taskModelList = new List<TaskModel>();
        private static List<UserModel> _userList = new List<UserModel>();

        [OneTimeSetUp]
        public static void GlobalSetup()
        {
            _state = AppStateProvider.Instance;
        }

        [OneTimeTearDown]
        public static void GlobalTeardown()
        {
            if (!_taskModelList.Any())
            {
                foreach (var task in _taskModelList)
                {
                    TaskModel.RemoveTask(task.TaskId);
                }
            }
            if (!_sprintModelList.Any())
            {
                foreach (var sprint in _sprintModelList)
                {
                    //TODO: Delete sprint
                    //SprintModel.Delete(sprint);
                }
            }
            if (!_projectList.Any())
            {
                foreach (var project in _projectList)
                {
                    ProjectModel.DeleteProject(project);
                }
            }
            if (!_userList.Any())
            {
                foreach (var user in _userList)
                {
                    UserModel.Delete(user);
                }
            }
        }

        public static void RegisterToDeleteAfterTestExecution<T>(T item)
        {
            var type = typeof(T);
            if (type == typeof(ProjectModel))
                _projectList.Add(item as ProjectModel);
            else if (type == typeof(SprintModel))
                _sprintModelList.Add(item as SprintModel);
            else if (type == typeof(TaskModel))
                _taskModelList.Add(item as TaskModel);
            else if (type == typeof(UserModel))
                _userList.Add(item as UserModel);
            else
                throw new InvalidOperationException("This type of Model is not supported to delete, you should implement deleting it first and then add 'else if' statement");
        }
    }
}
