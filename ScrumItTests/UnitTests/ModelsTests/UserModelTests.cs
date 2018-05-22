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

        [OneTimeSetUp]
        public void SetUp()
        {
            _state = AppStateProvider.Instance;
            _state.CurrentUser = new UserModel();
        }

        [Test]
        public void LoginAsWithEmptyPasswordShouldFail()
        {
            var loggedInSuccessful = UserModel.LoginAs("admin", "");

            Assert.That(loggedInSuccessful, Is.EqualTo(false), "Logging in was successful without password.");
            Assert.That(_state.CurrentUser.UserId, Is.EqualTo(0), "User Id changed after failed log in");
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "User role changed from guest after failed log in");
        }

        [Test]
        public void LoginAsWithEmptyLoginShouldFail()
        {
            var loggedInSuccessful = UserModel.LoginAs("", "admin");

            Assert.That(loggedInSuccessful, Is.EqualTo(false), "Logging in was successful with empty login.");
            Assert.That(_state.CurrentUser.UserId, Is.EqualTo(0), "User Id changed after failed log in");
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "User role changed from guest after failed log in");
        }

        [Test]
        public void LoginAsWithEmptyCredentialsShouldFail()
        {
            var loggedInSuccessful = UserModel.LoginAs("", "");

            Assert.That(loggedInSuccessful, Is.EqualTo(false), "Logging in was successful with empty credentials.");
            Assert.That(_state.CurrentUser.UserId, Is.EqualTo(0), "User Id changed after failed log in");
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "User role changed from guest after failed log in");
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
