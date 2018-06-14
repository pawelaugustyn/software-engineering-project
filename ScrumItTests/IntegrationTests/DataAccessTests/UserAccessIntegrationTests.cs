using System;
using System.Collections.Generic;
using System.Drawing;
using DeepEqual.Syntax;
using NUnit.Framework;
using ScrumIt;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumItTests.IntegrationTests.DataAccessTests
{
    [TestFixture, IntegrationTest]
    public class UserAccessIntegrationTests
    {
        private UserModel _user;
        private UserModel _guest;
        private ProjectModel _project;
        private const string Password = "testScrumMaster";

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
                ProjectColor = "#88f72c"
            };

            ProjectAccess.CreateNewProject(_project);
            Setup.RegisterToDeleteAfterTestExecution(_project);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            UserModel.Logout();
        }

        [Test]
        [TestCase("", "")]
        [TestCase("admin", "")]
        [TestCase("", Password)]
        public void LoginAsWithEmptyCredentialsShouldFail(string username, string password)
        {
            var user = UserAccess.LoginAs(username, password);

            Assertion.Equals(user, _guest);
        }

        [Test]
        [TestCase("incorrectLogin", "incorrectPassword")]
        [TestCase("admin", "incorrectPassword")]
        [TestCase("incorrectLogin", Password)]
        public void LoginAsWithIncorrectCredentialsShouldFail(string username, string password)
        {
            var user = UserAccess.LoginAs(username, password);

            Assertion.Equals(user, _guest);
        }

        [Test]
        public void LoginAsWithCorrectCredentialsShouldPass()
        {
            var user = UserAccess.LoginAs(_user.Username, Password);

            Assertion.Equals(user, _user);
        }

        [Test]
        public void GetUserByIdShouldReturnCorrectUser()
        {
            var user = UserAccess.GetUserById(_user.UserId);

            Assertion.Equals(user, _user);
        }

        [Test]
        public void GetUserByIdShouldNotReturnCorrectUser()
        {
            var user = UserAccess.GetUserById(-1);

            Assertion.Equals(user, _guest);
        }

        [Test]
        public void GetUsersByLastNameShouldReturnCorrectUser()
        {
            var users = UserAccess.GetUsersByLastName(_user.Lastname);

            users.ListContains(_user);
        }

        [Test]
        public void GetUsersByLastNameShouldNotReturnCorrectUser()
        {
            var users = UserAccess.GetUsersByLastName("incorrectLastname");

            users.ListNotContains(_user);
        }

        [Test]
        public void GetUserByUsernameShouldReturnCorrectUser()
        {
            var user = UserAccess.GetUserByUsername(_user.Username);

            Assertion.Equals(user, _user);
        }

        [Test]
        public void GetUserByUsernameShouldNotReturnCorrectUser()
        {
            var user = UserAccess.GetUserByUsername("incorrectUsername");

            Assertion.Equals(user, _guest);
        }

        [Test]
        public void GetUsersByProjectIdShouldReturnCorrectUsers()
        {
            var users = UserAccess.GetUsersByProjectId(_project.ProjectId);

            users.ListContains(AppStateProvider.Instance.CurrentUser);
        }

        [Test]
        public void GetUsersByProjectIdShouldNotReturnCorrectUsers()
        {
            var users = UserAccess.GetUsersByProjectId(-1);

            users.ListNotContains(AppStateProvider.Instance.CurrentUser);
        }

        [Test]
        public void GetUsersByTaskIdShouldReturnCorrectUsers()
        {
            var user = new UserModel
            {
                Username = "testScrumMaster".WithUniqueName(),
                Firstname = "scrum",
                Lastname = "master",
                Role = UserRoles.ScrumMaster,
                Email = "testScrumMaster@test.com"
            };

            UserAccess.Add(user, Password);
            Setup.RegisterToDeleteAfterTestExecution(user);

            var project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#827f62"
            };

            ProjectAccess.CreateNewProject(project);
            Setup.RegisterToDeleteAfterTestExecution(project);

            var task = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = project.ProjectId,
            };

            TaskAccess.CreateNewTask(task);
            Setup.RegisterToDeleteAfterTestExecution(task);

            var isAssignedSuccessful = TaskAccess.AssignUsersToTask(task, new List<UserModel> { user });
            Assert.That(isAssignedSuccessful, Is.True, $"User not assigned to task succesfully: {Messages.Display(task)} {Environment.NewLine}{user}");

            var users = UserAccess.GetUsersByTaskId(task.TaskId);

            users.ListContains(user);
        }

        [Test]
        public void GetUsersByTaskIdShoulNotReturnCorrectUsers()
        {
            var user = new UserModel
            {
                Username = "testScrumMaster".WithUniqueName(),
                Firstname = "scrum",
                Lastname = "master",
                Role = UserRoles.ScrumMaster,
                Email = "testScrumMaster@test.com"
            };

            UserAccess.Add(user, Password);
            Setup.RegisterToDeleteAfterTestExecution(user);

            var project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#ff8293"
            };

            ProjectAccess.CreateNewProject(project);
            Setup.RegisterToDeleteAfterTestExecution(project);

            var task = new TaskModel
            {
                TaskName = "testTask".WithUniqueName(),
                TaskDesc = "testTaskDescription",
                TaskPriority = int.Parse("15"),
                TaskEstimatedTime = int.Parse("10"),
                TaskStage = TaskModel.TaskStages.ToDo,
                TaskColor = "#ffffff",
                BacklogProjectId = project.ProjectId,
            };

            TaskAccess.CreateNewTask(task);
            Setup.RegisterToDeleteAfterTestExecution(task);

            var users = UserAccess.GetUsersByTaskId(task.TaskId);

            users.ListNotContains(user);
        }

        [Test]
        public void GetAllUsersShouldReturnCorrectUsers()
        {
            var users = UserAccess.GetAllUsers();

            users.ListContains(_user);
        }

        [Test]
        public void AddUserWithUniqueUsername()
        {
            var userToAdd = new UserModel
            {
                Username = "addUser".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "addUser@test.com"
            };
            Setup.RegisterToDeleteAfterTestExecution(userToAdd);

            var userWithTheSameUsername = UserAccess.GetUserByUsername(userToAdd.Username);
            Assert.That(userWithTheSameUsername.IsDeepEqual(new UserModel()), Is.True, "User should not exist.");

            var isAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            var userAfterAdd = UserAccess.GetUserByUsername(userToAdd.Username);
            Setup.RegisterToDeleteAfterTestExecution(userToAdd);

            Assertion.Equals(userToAdd, userAfterAdd, "User with unique username not added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.True, $"Adding user should be successful {Messages.Display(userToAdd)}.");
        }

        [Test]
        public void AddUserThatAlreadyExistShouldThrow()
        {
            var userToAdd = new UserModel
            {
                Username = "addUser".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "addUser@test.com"
            };
            var userWithTheSameUsername = UserAccess.GetUserByUsername(userToAdd.Username);
            Assert.That(userWithTheSameUsername.IsDeepEqual(new UserModel()), Is.True, "User should not exist.");

            UserAccess.Add(userToAdd, "addUser");
            Setup.RegisterToDeleteAfterTestExecution(userToAdd);

            var isAddedSuccessful = false;
            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = UserAccess.Add(userToAdd, "addUser"); },
                "Exception should be thrown, because it should not be possible to add user with the same username that has already been added.");

            var userAfterAdd = UserAccess.GetUserByUsername(userToAdd.Username);
            Assertion.Equals(userToAdd, userAfterAdd, "User with already existing username should not be added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.False, $"Adding user should not be successful {Messages.Display(userToAdd)}.");
        }

        [Test]
        public void AddEmptyUserShouldThrow()
        {
            var userToAdd = new UserModel();
            var isAddedSuccessful = false;

            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = UserAccess.Add(userToAdd, "guest"); },
                "Exception should be thrown, because it should not be possible to add user with empty username.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding user should not be successful {Messages.Display(userToAdd)}.");
        }

        [Test]
        public void X_AddEmptyUserWhenUnauthorizedShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var userToAdd = new UserModel
            {
                Username = "addUser".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "addUser@test.com"
            };
            var userWithTheSameUsername = UserAccess.GetUserByUsername(userToAdd.Username);
            Assert.That(userWithTheSameUsername.IsDeepEqual(new UserModel()), Is.True, "User should not exist.");

            var isAddedSuccessful = false;

            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { isAddedSuccessful = UserAccess.Add(userToAdd, "addUser"); },
                "Exception should be thrown, because it should not be possible to add user if you are not scrum master.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding user should not be successful {Messages.Display(userToAdd)}.");

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void DeleteUserWithUniqueUsername()
        {
            var userToAddAndDelete = new UserModel
            {
                Username = "deleteUser".WithUniqueName(),
                Firstname = "delete",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "deleteUser@test.com"
            };
            var userWithTheSameUsername = UserAccess.GetUserByUsername(userToAddAndDelete.Username);
            Assert.That(userWithTheSameUsername.IsDeepEqual(new UserModel()), Is.True, "User should not exist.");

            UserAccess.Add(userToAddAndDelete, "deleteUser");
            var userAfterAdd = UserAccess.GetUserByUsername(userToAddAndDelete.Username);

            Assertion.Equals(userToAddAndDelete, userAfterAdd, "User with unique username not added correctly to DB. ");

            var deletedSuccessful = UserAccess.Delete(userAfterAdd);
            Assert.That(deletedSuccessful, Is.True, $"Deleting should be successful {Messages.Display(userAfterAdd)}.");

            var userAfterDelete = UserAccess.GetUserByUsername(userToAddAndDelete.Username);
            Assert.That(userAfterDelete.IsDeepEqual(new UserModel()), Is.True, $"User {Messages.Display(userAfterDelete)} should be deleted.");
        }

        [Test]
        public void DeleteEmptyOrInvalidUserShouldDoNothing()
        {
            var userToDelete = new UserModel();
            var deletedSuccessful = UserAccess.Delete(userToDelete);
            Assert.That(deletedSuccessful, Is.False, $"Deleting user should not be successful {Messages.Display(userToDelete)}.");

            userToDelete = new UserModel
            {
                Username = "delete",
            };

            deletedSuccessful = UserAccess.Delete(userToDelete);
            Assert.That(deletedSuccessful, Is.False, $"Deleting user should not be successful {Messages.Display(userToDelete)}.");
        }

        [Test]
        public void DeleteYourselfShouldThrow()
        {
            var deletedSuccessful = false;
            Assert.Throws<ArgumentException>(delegate { deletedSuccessful = UserAccess.Delete(_user); },
                "Exception should be thrown, because it should not be possible to delete yourself.");

            Assert.That(deletedSuccessful, Is.False, $"Deleting user should not be successful {Messages.Display(_user)}.");
        }

        [Test]
        public void UpdateUserDataAsScrumMasterShouldBePossible()
        {
            var userToUpdate = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDeveloper@test.com"
            };

            UserAccess.Add(userToUpdate, Password);
            Setup.RegisterToDeleteAfterTestExecution(userToUpdate);

            userToUpdate.Email = "developer@test.com";

            var updatedSuccessful = UserAccess.UpdateUserData(userToUpdate);
            Assert.That(updatedSuccessful, Is.True, $"Updating user should be successful {Messages.Display(updatedSuccessful)}.");

            var user = UserAccess.GetUserById(userToUpdate.UserId);
            Assertion.Equals(user, userToUpdate);
        }

        [Test]
        public void UpdateUserDataAsGuestShouldThrow()
        {
            var userToUpdate = new UserModel
            {
                Username = "testDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDeveloper@test.com"
            };

            UserAccess.Add(userToUpdate, Password);
            Setup.RegisterToDeleteAfterTestExecution(userToUpdate);

            AppStateProvider.Instance.CurrentUser = _guest;

            userToUpdate.Email = "developer@test.com";

            var updatedSuccessful = false;
            Assert.Throws<UnauthorizedAccessException>(delegate { updatedSuccessful = UserAccess.UpdateUserData(userToUpdate); },
                "Exception should be thrown, because it should not be possible to update anyone as guest.");

            Assert.That(updatedSuccessful, Is.False, $"Updating user should not be successful {Messages.Display(updatedSuccessful)}.");

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void SetUserPicture()
        {
            var user = new UserModel
            {
                Username = "setPicture".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "setPictureUser@test.com"
            };
            Setup.RegisterToDeleteAfterTestExecution(user);

            UserAccess.Add(user, "setPicture");

            var picture = new Bitmap(64, 64);
            for (var x = 0; x < picture.Width; x++)
            {
                for (var y = 0; y < picture.Height; y++)
                {
                    picture.SetPixel(x, y, Color.Aqua);
                }
            }

            var isPictureSetSuccessful = UserAccess.SetUserPicture(user.UserId, picture);
            Assert.That(isPictureSetSuccessful, Is.True, $"Setting user picture should be successful {Messages.Display(user)}.");

            var userWithPicture = UserAccess.GetUserById(user.UserId);
            Assert.That(Objects.AreImagesTheSame(new Bitmap(userWithPicture.Avatar), picture), Is.True, $"User picture should be the same as updated one { Messages.Display(user)}.");
        }

        [Test]
        public void GetUserPicture()
        {
            var user = new UserModel
            {
                Username = "getPicture".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "getPictureUser@test.com"
            };
            Setup.RegisterToDeleteAfterTestExecution(user);

            UserAccess.Add(user, "getPicture");

            var userPicture = UserAccess.GetUserPicture(user.UserId);
            Assert.That(Objects.AreImagesTheSame((Bitmap)user.Avatar, (Bitmap)userPicture), Is.True, $"User picture should be equal to updated one { Messages.Display(user)}.");
        }

        [Test]
        public void X_DeleteUserWhenUnauthorizedShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var userToAddAndDelete = new UserModel
            {
                Username = "deleteUser".WithUniqueName(),
                Firstname = "delete",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "deleteUser@test.com"
            };
            var userWithTheSameUsername = UserAccess.GetUserByUsername(userToAddAndDelete.Username);
            Assert.That(userWithTheSameUsername.IsDeepEqual(new UserModel()), Is.True, "User should not exist.");

            UserAccess.Add(userToAddAndDelete, "deleteUser");
            var userAfterAdd = UserAccess.GetUserByUsername(userToAddAndDelete.Username);
            Setup.RegisterToDeleteAfterTestExecution(userToAddAndDelete);

            Assertion.Equals(userToAddAndDelete, userAfterAdd, "User with unique username not added correctly to DB. ");

            var deletedSuccessful = true;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { deletedSuccessful = UserAccess.Delete(userToAddAndDelete); },
                "Exception should be thrown, because it should not be possible to delete user if you are not scrum master.");

            Assert.That(deletedSuccessful, Is.True, $"Deleting user should not be successful {Messages.Display(userToAddAndDelete)}.");

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void X_UpdateUserPasswordShouldBePossible()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var userToUpdate = new UserModel
            {
                Username = "updatePasswordDeveloper".WithUniqueName(),
                Firstname = "test",
                Lastname = "developer",
                Role = UserRoles.Developer,
                Email = "testDeveloper@test.com"
            };

            UserAccess.Add(userToUpdate, Password);
            Setup.RegisterToDeleteAfterTestExecution(userToUpdate);

            const string oldPassword = "oldOne";
            const string newPassword = "newOne";

            UserModel.Logout();
            AppStateProvider.Instance.CurrentUser = userToUpdate;

            var updatedSyccessful = UserAccess.UpdateUserPassword(newPassword);
            Assert.That(updatedSyccessful, Is.True, $"Updating user password from {oldPassword} to {newPassword} should be successful {Messages.Display(userToUpdate)}.");

            UserModel.Logout();
            AppStateProvider.Instance.CurrentUser = _user;
        }
    }
}