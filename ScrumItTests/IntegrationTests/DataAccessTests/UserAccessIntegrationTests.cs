using System;
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
                ProjectColor = "#ff0000"
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
            var userWithTheSameUsername = UserAccess.GetUserByUsername(userToAdd.Username);
            Assert.That(userWithTheSameUsername.IsDeepEqual(new UserModel()), Is.True, "User should not exist.");

            var isAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            var userAfterAdd = UserAccess.GetUserByUsername(userToAdd.Username);

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

            var deletedSyccessful = UserAccess.Delete(userAfterAdd);
            Assert.That(deletedSyccessful, Is.True, $"Deleting should be successful {Messages.Display(userAfterAdd)}.");

            var userAfterDelete = UserAccess.GetUserByUsername(userToAddAndDelete.Username);
            Assert.That(userAfterDelete.IsDeepEqual(new UserModel()), Is.True, $"User {Messages.Display(userAfterDelete)} should be deleted.");
        }

        [Test]
        public void DeleteEmptyOrInvalidUserShouldDoNothing()
        {
            var userToDelete = new UserModel();
            var deletedSyccessful = UserAccess.Delete(userToDelete);
            Assert.That(deletedSyccessful, Is.False, $"Deleting user should not be successful {Messages.Display(userToDelete)}.");

            userToDelete = new UserModel
            {
                Username = "delete",
            };

            deletedSyccessful = UserAccess.Delete(userToDelete);
            Assert.That(deletedSyccessful, Is.False, $"Deleting user should not be successful {Messages.Display(userToDelete)}.");
        }

        [Test]
        public void DeleteYourselfShouldThrow()
        {
            var deletedSyccessful = false;
            Assert.Throws<ArgumentException>(delegate { deletedSyccessful = UserAccess.Delete(_user); },
                "Exception should be thrown, because it should not be possible to delete yourself.");

            Assert.That(deletedSyccessful, Is.False, $"Deleting user should not be successful {Messages.Display(_user)}.");
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

            Assertion.Equals(userToAddAndDelete, userAfterAdd, "User with unique username not added correctly to DB. ");

            var deletedSyccessful = true;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { deletedSyccessful = UserAccess.Delete(userToAddAndDelete); },
                "Exception should be thrown, because it should not be possible to delete user if you are not scrum master.");

            Assert.That(deletedSyccessful, Is.True, $"Deleting user should not be successful {Messages.Display(userToAddAndDelete)}.");

            AppStateProvider.Instance.CurrentUser = _user;
        }
    }
}