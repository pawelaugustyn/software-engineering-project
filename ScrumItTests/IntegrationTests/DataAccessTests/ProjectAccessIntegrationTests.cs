using System;
using DeepEqual.Syntax;
using NUnit.Framework;
using ScrumIt;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumItTests.IntegrationTests.DataAccessTests
{
    [TestFixture, IntegrationTest]
    public class ProjectAccessIntegrationTests
    {
        private UserModel _user;
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

            AppStateProvider.Instance.CurrentUser = _user;

            UserAccess.Add(_user, Password);
            Setup.RegisterToDeleteAfterTestExecution(_user);

            ProjectAccess.CreateNewProject(_project);
            Setup.RegisterToDeleteAfterTestExecution(_project);
        }

        [Test]
        public void GetProjectByIdShouldReturnCorrectProject()
        {
            var project = ProjectAccess.GetProjectById(_project.ProjectId);

            Assertion.Equals(project, _project);
        }

        [Test]
        public void GetProjectsByUserIdShouldReturnCorrectProjects()
        {
            var projects = ProjectAccess.GetProjectsByUserId(AppStateProvider.Instance.CurrentUser.UserId);

            projects.ListContains(_project);
        }

        [Test]
        public void AddProjectWithUniqueName()
        {
            //TODO: ProjectAcces.GetProjectByName()
            /*
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd);
            var projectAfterAdd = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);

            Assertion.Equals(projectToAdd, projectAfterAdd, "Project with unique name not added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAdd)}.");
            */
        }

        [Test]
        public void AddProjectThatAlreadyExistShouldThrow()
        {
            //TODO: ProjectAcces.GetProjectByName()
            /*
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            ProjectAccess.CreateNewProject(projectToAdd);

            var isAddedSuccessful = false;
            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd); },
                "Exception should be thrown, because it should not be possible to add project with the same name that has already been added.");

            var projectAfterAdd = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assertion.Equals(projectToAdd, projectAfterAdd, "Project with already existing name should not be added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.False, $"Adding project should not be successful {Messages.Display(projectToAdd)}.");
            */
        }

        [Test]
        public void AddEmptyProjectShouldThrow()
        {
            var projectToAdd = new ProjectModel();
            var isAddedSuccessful = false;

            Assert.Throws<ArgumentNullException>(delegate { isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd); },
                "Exception should be thrown, because it should not be possible to add project with empty name.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding project should not be successful {Messages.Display(projectToAdd)}.");
        }

        [Test]
        public void AddProjectWithWrongColourShouldThrow()
        {
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#fffffg"
            };

            var isAddedSuccessful = false;

            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd); },
                "Exception should be thrown, because it should not be possible to add project with wrong colour string.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding project should not be successful {Messages.Display(projectToAdd)}.");
        }
    }
}
