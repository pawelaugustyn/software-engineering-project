using NUnit.Framework;
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

        [OneTimeSetUp]
        public void SetUp()
        {
            _user = new UserModel
            {
                UserId = 2,
                Username = "testScrumMaster",
                Firstname = "scrum",
                Lastname = "master",
                Role = UserRoles.ScrumMaster,
                Email = "testScrumMaster@test.com"
            };

            _project = new ProjectModel
            {
                ProjectId = 2,
                ProjectColor = "#ff0000",
                ProjectName = "TestProject"
            };

            _guest = new UserModel();

            //UserAccess.Add(_user);
            //ProjectAccess.Add(_project);
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
            const string password = "testScrumMaster";

            var user = UserAccess.LoginAs(_user.Username, password);

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

            Assert.That(users.Contains(_user), Is.True, $"User do not exist on the list. Expected User: {Messages.Display(_user)} ");
        }

        [Test]
        public void GetUserByLoginShouldReturnCorrectUser()
        {
            var user = UserAccess.GetUserByLogin(_user.Username);

            Assertion.Equals(user, _user);
        }

        [Test]
        public void GetUsersByProjectIdShouldReturnCorrectUsers()
        {
            var users = UserAccess.GetUsersByProjectId(_project.ProjectId);

            Assert.That(users.Contains(_user), Is.True, $"User do not exist on the list. Expected User: {Messages.Display(_user)} ");
        }
    }
}