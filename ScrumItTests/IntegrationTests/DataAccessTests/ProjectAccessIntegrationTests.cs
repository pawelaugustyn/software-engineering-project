using System;
using DeepEqual.Syntax;
using NUnit.Framework;
using ScrumIt;
using ScrumIt.DataAccess;
using ScrumIt.Models;
using Npgsql;

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
        public void GetProjectByNameShouldReturnCorrectProjects()
        {
            var project = ProjectAccess.GetProjectByName(_project.ProjectName);

            Assertion.Equals(project, _project);
        }

        [Test]
        public void GetProjectsByUserIdShouldReturnCorrectProjects()
        {
            var projects = ProjectAccess.GetProjectsByUserId(AppStateProvider.Instance.CurrentUser.UserId);

            projects.ListContains(_project);
        }

        [Test]
        public void GetProjectsByUserIdShouldNotReturnCorrectProjects()
        {
            var projects = ProjectAccess.GetProjectsByUserId(-1);

            projects.ListNotContains(_project);
        }

        [Test]
        public void AddProjectWithUniqueName()
        {
            AppStateProvider.Instance.CurrentUser = _user;

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
        }

        [Test]
        public void AddProjectThatAlreadyExistShouldThrow()
        {
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

        [Test]
        public void DeleteProjectWithUniqueName()
        {
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            ProjectAccess.CreateNewProject(projectToAdd);
            var projectAfterAdd = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);

            Assertion.Equals(projectToAdd, projectAfterAdd, "Project with unique name not added correctly to DB. ");

            var deletedSuccessful = ProjectAccess.DeleteProject(projectAfterAdd);
            Assert.That(deletedSuccessful, Is.True, $"Deleting should be successful {Messages.Display(projectAfterAdd)}.");

            var projectAfterDelete = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectAfterDelete.IsDeepEqual(new ProjectModel()), Is.True, $"Project {Messages.Display(projectAfterDelete)} should be deleted.");
        }

        [Test]
        public void DeleteEmptyOrInvalidProjectShouldDoNothing()
        {
            var projectToDelete = new ProjectModel();
            var deletedSuccessful = ProjectAccess.DeleteProject(projectToDelete);
            Assert.That(deletedSuccessful, Is.False, $"Deleting project should not be successful {Messages.Display(projectToDelete)}.");

            projectToDelete = new ProjectModel
            {
                ProjectName = "deleteTestProject",
            };

            deletedSuccessful = ProjectAccess.DeleteProject(projectToDelete);
            Assert.That(deletedSuccessful, Is.False, $"Deleting project should not be successful {Messages.Display(projectToDelete)}.");
        }

        [Test]
        public void DeleteProjectWhenUnauthorizedShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAddAndDelete = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAddAndDelete.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            ProjectAccess.CreateNewProject(projectToAddAndDelete);
            var projectAfterAdd = ProjectAccess.GetProjectByName(projectToAddAndDelete.ProjectName);

            Assertion.Equals(projectToAddAndDelete, projectAfterAdd, "Project with unique name not added correctly to DB. ");

            var deletedSuccessful = true;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { deletedSuccessful = ProjectAccess.DeleteProject(projectToAddAndDelete); },
                "Exception should be thrown, because it should not be possible to delete project if you are not scrum master.");

            Assert.That(deletedSuccessful, Is.True, $"Deleting project should not be successful {Messages.Display(projectToAddAndDelete)}.");

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void AddProjectWhenUnauthorizedShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = false;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd); },
                "Exception should be thrown, because it should not be possible to add project if you are guest.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding project should not be successful {Messages.Display(projectToAdd)}.");
        }

        [Test]
        public void UpdateProjectWithSameOrNewName()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAddandUpdate = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAddandUpdate);
            Assert.That(isAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAddandUpdate)}.");

            projectToAddandUpdate.ProjectColor = "#fff000";
            var isUpdatedSuccessful = ProjectAccess.UpdateProject(projectToAddandUpdate);
            var updatedProject = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);

            Assertion.Equals(projectToAddandUpdate, updatedProject, "Project with same name not updated correctly in DB.");
            Assert.That(isUpdatedSuccessful, Is.True, $"Updating project should be successful {Messages.Display(projectToAddandUpdate)}.");

            projectToAddandUpdate.ProjectName = "newTestProjectName".WithUniqueName();
            isUpdatedSuccessful = ProjectAccess.UpdateProject(projectToAddandUpdate);
            updatedProject = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);

            Assertion.Equals(projectToAddandUpdate, updatedProject, "Project with new unique name not updated correctly in DB.");
            Assert.That(isUpdatedSuccessful, Is.True, $"Updating project should be successful {Messages.Display(projectToAddandUpdate)}.");
        }

        [Test]
        public void UpdateProjectWithWrongOrEmptyColourShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAddandUpdate = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAddandUpdate);
            Assert.That(isAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAddandUpdate)}.");

            projectToAddandUpdate.ProjectColor = "#fffffg";
            var isUpdatedSuccessful = false;

            Assert.Throws<ArgumentException>(delegate { isUpdatedSuccessful = ProjectAccess.UpdateProject(projectToAddandUpdate); },
                "Exception should be thrown, because it should not be possible to update project with wrong colour string.");

            Assert.That(isUpdatedSuccessful, Is.False, $"Updating project should not be successful {Messages.Display(projectToAddandUpdate)}.");

            projectToAddandUpdate = new ProjectModel();
            isUpdatedSuccessful = false;

            Assert.Throws<ArgumentNullException>(delegate { isUpdatedSuccessful = ProjectAccess.UpdateProject(projectToAddandUpdate); },
                "Exception should be thrown, because it should not be possible to update project to empty project.");

            Assert.That(isUpdatedSuccessful, Is.False, $"Updating project should not be successful {Messages.Display(projectToAddandUpdate)}.");
        }

        [Test]
        public void UpdateProjectWhenUnauthorizedShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAddandUpdate = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAddandUpdate);
            Assert.That(isAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAddandUpdate)}.");

            projectToAddandUpdate.ProjectColor = "#fff000";
            var isUpdatedSuccessful = false;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { isUpdatedSuccessful = ProjectAccess.UpdateProject(projectToAddandUpdate); },
                "Exception should be thrown, because it should not be possible to update project if you are not scrum master.");

            Assert.That(isUpdatedSuccessful, Is.False, $"Updating project should not be successful {Messages.Display(projectToAddandUpdate)}.");
        }

        [Test]
        public void AddNewUserToProjectWithUniqueUserame()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isProjectAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd);
            Assert.That(isProjectAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAdd)}.");

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

            var isUserAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            Assert.That(isUserAddedSuccessful, Is.True, $"Adding user should be successful {Messages.Display(userToAdd)}.");

            var isUserAddedToProjectSuccessful =
                ProjectAccess.AddNewUserToProject(userToAdd.UserId, projectToAdd.ProjectId);
            var users = UserAccess.GetUsersByProjectId(projectToAdd.ProjectId);

            users.ListContains(userToAdd);
            Assert.That(isUserAddedToProjectSuccessful, Is.True, $"Adding new user to project should be successful {Messages.Display(projectToAdd)}.");
        }

        [Test]
        public void AddNewUserToProjectThatAlreadyExistsShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isProjectAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd);
            Assert.That(isProjectAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAdd)}.");

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

            var isUserAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            Assert.That(isUserAddedSuccessful, Is.True, $"Adding user should be successful {Messages.Display(userToAdd)}.");

            ProjectAccess.AddNewUserToProject(userToAdd.UserId, projectToAdd.ProjectId);

            var isUserAddedToProjectSuccessful = false;
            Assert.Throws<NpgsqlException>(delegate { isUserAddedToProjectSuccessful = ProjectAccess.AddNewUserToProject(userToAdd.UserId, projectToAdd.ProjectId); },
                "Exception should be thrown, because it should not be possible to add user to project with the same username that has already been added.");

            Assert.That(isUserAddedToProjectSuccessful, Is.False, $"Adding new user to project should not be successful {Messages.Display(projectToAdd)}.");
        }

        [Test]
        public void AddNewUserToProjectWhenUnauthorizedShouldThrow()
        {
            AppStateProvider.Instance.CurrentUser = _user;

            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isProjectAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd);
            Assert.That(isProjectAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAdd)}.");

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

            var isUserAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            Assert.That(isUserAddedSuccessful, Is.True, $"Adding user should be successful {Messages.Display(userToAdd)}.");

            var isUserAddedToProjectSuccessful = false;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { isUserAddedToProjectSuccessful = ProjectAccess.AddNewUserToProject(userToAdd.UserId, projectToAdd.ProjectId); },
                "Exception should be thrown, because it should not be possible to add new user to project if you are not scrum master.");

            Assert.That(isUserAddedToProjectSuccessful, Is.False, $"Adding new user to project should not be successful {Messages.Display(projectToAdd)}.");
        }
    }
}
