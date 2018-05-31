﻿using System;
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

            _project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            _guest = new UserModel();

            AppStateProvider.Instance.CurrentUser = _user;

            UserAccess.Add(_user, Password);
            Setup.RegisterToDeleteAfterTestExecution(_user);

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
        [TestCase("testScrumMaster", "")]
        [TestCase("", "testScrumMaster")]
        public void LoginAsWithEmptyCredentialsShouldFail(string username, string password)
        {
            var user = UserAccess.LoginAs(username, password);

            Assertion.Equals(user, _guest);
        }

        [Test]
        [TestCase("incorrectLogin", "incorrectPassword")]
        [TestCase("testScrumMaster", "incorrectPassword")]
        [TestCase("incorrectLogin", "testScrumMaster")]
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
        public void GetUsersByLastNameShouldReturnCorrectUser()
        {
            var users = UserAccess.GetUsersByLastName(_user.Lastname);

            users.ListContains(_user);
        }

        [Test]
        public void GetUserByLoginShouldReturnCorrectUser()
        {
            var user = UserAccess.GetUserByUsername(_user.Username);

            Assertion.Equals(user, _user);
        }

        [Test]
        public void GetUsersByProjectIdShouldReturnCorrectUsers()
        {
            var users = UserAccess.GetUsersByProjectId(_project.ProjectId);

            users.ListContains(AppStateProvider.Instance.CurrentUser);
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
        public void DeleteUserWithUniqueUsername()
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
            var userAfterAdd = UserAccess.GetUserByUsername(userToAdd.Username);

            Assertion.Equals(userToAdd, userAfterAdd, "User with unique username not added correctly to DB. ");

            var deletedSyccessful = UserAccess.Delete(userAfterAdd);
            Assert.That(deletedSyccessful, Is.True, $"Deleting should be successful {Messages.Display(userAfterAdd)}.");

            var userAfterDelete = UserAccess.GetUserByUsername(userToAdd.Username);
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
    }
}