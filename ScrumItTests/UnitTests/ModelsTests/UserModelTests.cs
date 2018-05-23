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
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "User role changed from guest after failed log in");
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            _state = AppStateProvider.Instance;
            _state.CurrentUser = new UserModel();
        }

        [Test]
        [TestCase("", "")]
        [TestCase("admin", "")]
        [TestCase("", "admin")]
        public void LoginAsWithEmptyCredentialsShouldFail(string username, string password)
        {
            var loggedInSuccessful = UserModel.LoginAs(username, password);

            Assert.That(loggedInSuccessful, Is.EqualTo(false), "Logging in was successful with empty credentials.");
            AssertFailedLogging();
        }

        [Test]
        [TestCase("incorrect_login", "incorrect_password")]
        [TestCase("admin", "incorrect_password")]
        [TestCase("incorrect_login", "admin")]
        public void LoginAsWithIncorrectCredentialsShouldFail(string username, string password)
        {
            var loggedInSuccessful = UserModel.LoginAs(username, password);

            Assert.That(loggedInSuccessful, Is.EqualTo(false), "Logging in was successful with incorrect credentials.");
            AssertFailedLogging();
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
