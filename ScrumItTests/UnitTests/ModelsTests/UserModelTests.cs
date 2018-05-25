using NUnit.Framework;
using ScrumIt;
using ScrumIt.Models;
using Assert = NUnit.Framework.Assert;

namespace ScrumItTests.UnitTests.ModelsTests
{
    [TestFixture]
    public class UserModelTests
    {
        private AppStateProvider _state;

        private void AssertFailedLogging() 
        {
            Assert.That(_state.CurrentUser.UserId, Is.EqualTo(0), "User Id changed after failed log in");
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "User role changed after failed log in");
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            _state = AppStateProvider.Instance;
        }

        [Test]
        [TestCase("", "")]
        [TestCase("admin", "")]
        [TestCase("", "admin")]
        public void LoginAsWithEmptyCredentialsShouldFail(string username, string password)
        {
            _state.CurrentUser = new UserModel();

            var loggedInSuccessful = UserModel.LoginAs(username, password);

            Assert.That(loggedInSuccessful, Is.EqualTo(false), "Logging in was successful with empty credentials.");
            AssertFailedLogging();
        }

        [Test]
        [TestCase("incorrectLogin", "incorrectPassword")]
        [TestCase("admin", "incorrectPassword")]
        [TestCase("incorrectLogin", "admin")]
        public void LoginAsWithIncorrectCredentialsShouldFail(string username, string password)
        {
            _state.CurrentUser = new UserModel();

            var loggedInSuccessful = UserModel.LoginAs(username, password);

            Assert.That(loggedInSuccessful, Is.EqualTo(false), "Logging in was successful with incorrect credentials.");
            AssertFailedLogging();
        }

        [Test]
        public void LogOutWhenYouAreNotLoggedInShouldFail()
        {
            _state.CurrentUser = new UserModel();

            var loggedOutSuccessful = UserModel.Logout();

            Assert.That(loggedOutSuccessful, Is.EqualTo(false), "Logging out without logging in first was successful.");
            Assert.That(_state.CurrentUser.UserId, Is.EqualTo(0), "User Id changed after failed logging out");
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "User role changed after failed log out");
        }

        [Test]
        public void LogOutShouldUnsetUser()
        {
            _state.CurrentUser = new UserModel
            {
                UserId = 5,
                Role = UserRoles.Developer
            };

            var loggedOutSuccessful = UserModel.Logout();

            Assert.That(loggedOutSuccessful, Is.EqualTo(true), "Logging out was unsuccessful.");
            Assert.That(_state.CurrentUser.UserId, Is.EqualTo(0), "Previous user Id is present after log out");
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "Previous user role is present after log out");
        }
    }
}
