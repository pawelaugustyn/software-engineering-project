using System;
using System.Collections.Generic;
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
        private SprintModel _sprint;
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

            _project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#123456"
            };

            ProjectAccess.CreateNewProject(_project);
            Setup.RegisterToDeleteAfterTestExecution(_project);

            _sprint = new SprintModel
            {
                ParentProjectId = _project.ProjectId,
                EndDateTime = DateTime.Parse( DateTime.Now.AddDays(2).ToString("yyyy-MM-dd hh:mm:ss") ),
                StartDateTime = DateTime.Parse( DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd hh:mm:ss") )
            };

            SprintAccess.CreateNewSprintForProject(_sprint);
            Setup.RegisterToDeleteAfterTestExecution(_sprint);
        }

        [Test]
        public void GetAllProjectsShouldReturnCorrectProjects()
        {
            var projects = ProjectAccess.GetAllProjects();

            projects.ListContains(_project);
        }

        [Test]
        public void GetProjectByIdShouldReturnCorrectProject()
        {
            var project = ProjectAccess.GetProjectById(_project.ProjectId);

            Assertion.Equals(project, _project);
        }

        [Test]
        public void GetProjectByIdShouldNotReturnCorrectProject()
        {
            var project = ProjectAccess.GetProjectById(-1);

            Assertion.Equals(project, new ProjectModel());
        }

        [Test]
        public void GetProjectByNameShouldReturnCorrectProject()
        {
            var project = ProjectAccess.GetProjectByName(_project.ProjectName);

            Assertion.Equals(project, _project);
        }

        [Test]
        public void GetProjectByNameShouldNotReturnCorrectProject()
        {
            var project = ProjectAccess.GetProjectByName("incorrectUserName");

            Assertion.Equals(project, new ProjectModel());
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
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#123457"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd);
            var projectAfterAdd = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);

            Assertion.Equals(projectToAdd, projectAfterAdd, "Project with unique name not added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAdd)}.");
            Setup.RegisterToDeleteAfterTestExecution(projectToAdd);
        }

        [Test]
        public void AddProjectThatAlreadyExistShouldThrow()
        {
            var isAddedSuccessful = false;

            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = ProjectAccess.CreateNewProject(_project); },
                "Exception should be thrown, because it should not be possible to add project with the same name that has already been added.");

            var projectAfterAdd = ProjectAccess.GetProjectByName(_project.ProjectName);
            Assertion.Equals(_project, projectAfterAdd, "Project with already existing name should not be added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.False, $"Adding project should not be successful {Messages.Display(_project)}.");
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
            var projectToAddAndDelete = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#774563"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAddAndDelete.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            ProjectAccess.CreateNewProject(projectToAddAndDelete);
            var projectAfterAdd = ProjectAccess.GetProjectByName(projectToAddAndDelete.ProjectName);

            Assertion.Equals(projectToAddAndDelete, projectAfterAdd, "Project with unique name not added correctly to DB. ");

            var deletedSuccessful = ProjectAccess.DeleteProject(projectAfterAdd);
            Assert.That(deletedSuccessful, Is.True, $"Deleting should be successful {Messages.Display(projectAfterAdd)}.");

            var projectAfterDelete = ProjectAccess.GetProjectByName(projectToAddAndDelete.ProjectName);
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
            var projectToAddAndDelete = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#868236"
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
            Setup.RegisterToDeleteAfterTestExecution(projectToAddAndDelete);
        }

        [Test]
        public void AddProjectWhenUnauthorizedShouldThrow()
        {
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#928723"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAdd.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = false;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAdd); },
                "Exception should be thrown, because it should not be possible to add project if you are guest.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding project should not be successful {Messages.Display(projectToAdd)}.");

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void UpdateProjectWithSameOrNewName()
        {
            var projectToAddandUpdate = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#92f73d"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAddandUpdate);
            Assert.That(isAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAddandUpdate)}.");

            projectToAddandUpdate.ProjectColor = "#87ad92";
            var isUpdatedSuccessful = ProjectAccess.UpdateProject(projectToAddandUpdate);
            var updatedProject = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);

            Assertion.Equals(projectToAddandUpdate, updatedProject, "Project with same name not updated correctly in DB.");
            Assert.That(isUpdatedSuccessful, Is.True, $"Updating project should be successful {Messages.Display(projectToAddandUpdate)}.");

            projectToAddandUpdate.ProjectName = "newTestProjectName".WithUniqueName();
            isUpdatedSuccessful = ProjectAccess.UpdateProject(projectToAddandUpdate);
            updatedProject = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);

            Assertion.Equals(projectToAddandUpdate, updatedProject, "Project with new unique name not updated correctly in DB.");
            Assert.That(isUpdatedSuccessful, Is.True, $"Updating project should be successful {Messages.Display(projectToAddandUpdate)}.");

            Setup.RegisterToDeleteAfterTestExecution(projectToAddandUpdate);
        }

        [Test]
        public void UpdateProjectToEmptyProjectShouldThrow()
        {
            var projectToAddandUpdate = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#288cca"
            };
            var projectWithTheSameName = ProjectAccess.GetProjectByName(projectToAddandUpdate.ProjectName);
            Assert.That(projectWithTheSameName.IsDeepEqual(new ProjectModel()), Is.True, "Project should not exist.");

            var isAddedSuccessful = ProjectAccess.CreateNewProject(projectToAddandUpdate);
            Assert.That(isAddedSuccessful, Is.True, $"Adding project should be successful {Messages.Display(projectToAddandUpdate)}.");

            var emptyProject = new ProjectModel();
            var isUpdatedSuccessful = false;

            Assert.Throws<ArgumentNullException>(delegate { isUpdatedSuccessful = ProjectAccess.UpdateProject(emptyProject); },
                "Exception should be thrown, because it should not be possible to update project to empty project.");

            Assert.That(isUpdatedSuccessful, Is.False, $"Updating project should not be successful {Messages.Display(emptyProject)}.");

            Setup.RegisterToDeleteAfterTestExecution(projectToAddandUpdate);
        }

        [Test]
        public void UpdateProjectWithWrongColourShouldThrow()
        {
            var projectToAddandUpdate = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#827f2f"
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

            Setup.RegisterToDeleteAfterTestExecution(projectToAddandUpdate);
        }

        [Test]
        public void UpdateProjectWhenUnauthorizedShouldThrow()
        {
            var projectToAddandUpdate = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#652aaa"
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

            AppStateProvider.Instance.CurrentUser = _user;
            Setup.RegisterToDeleteAfterTestExecution(projectToAddandUpdate);
        }

        [Test]
        public void AddNewUserToProjectWithUniqueUsername()
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

            var isUserAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            Assert.That(isUserAddedSuccessful, Is.True, $"Adding user should be successful {Messages.Display(userToAdd)}.");

            var isUserAddedToProjectSuccessful =
                ProjectAccess.AddNewUserToProject(userToAdd.UserId, _project.ProjectId);
            var users = UserAccess.GetUsersByProjectId(_project.ProjectId);

            users.ListContains(userToAdd);
            Assert.That(isUserAddedToProjectSuccessful, Is.True, $"Adding new user to project should be successful {Messages.Display(_project)}.");

            Setup.RegisterToDeleteAfterTestExecution(userToAdd);
        }

        [Test]
        public void AddNewUserToProjectThatAlreadyExistsShouldThrow()
        {
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#f72f96"
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

            Setup.RegisterToDeleteAfterTestExecution(userToAdd);
            Setup.RegisterToDeleteAfterTestExecution(projectToAdd);
        }

        [Test]
        public void AddNewUserToProjectWhenUnauthorizedShouldThrow()
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

            var isUserAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            Assert.That(isUserAddedSuccessful, Is.True, $"Adding user should be successful {Messages.Display(userToAdd)}.");

            var isUserAddedToProjectSuccessful = false;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { isUserAddedToProjectSuccessful = ProjectAccess.AddNewUserToProject(userToAdd.UserId, _project.ProjectId); },
                "Exception should be thrown, because it should not be possible to add new user to project if you are not scrum master.");

            Assert.That(isUserAddedToProjectSuccessful, Is.False, $"Adding new user to project should not be successful {Messages.Display(_project)}.");

            AppStateProvider.Instance.CurrentUser = _user;
            Setup.RegisterToDeleteAfterTestExecution(userToAdd);
        }

        [Test]
        public void AssignUsersToProject()
        {
            var projectToAdd = new ProjectModel
            {
                ProjectName = "addTestProject".WithUniqueName(),
                ProjectColor = "#827f02"
            };
            ProjectAccess.CreateNewProject(projectToAdd);

            var userToAdd0 = new UserModel
            {
                Username = "addUser".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "addUser@test.com"
            };
            UserAccess.Add(userToAdd0, "addUser");
            ProjectAccess.AddNewUserToProject(userToAdd0.UserId, projectToAdd.ProjectId);

            var userToAdd1 = new UserModel
            {
                Username = "addUser".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "addUser@test.com"
            };
            UserAccess.Add(userToAdd1, "addUser");

            var userToAdd2 = new UserModel
            {
                Username = "addUser".WithUniqueName(),
                Firstname = "add",
                Lastname = "User",
                Role = UserRoles.Developer,
                Email = "addUser@test.com"
            };
            UserAccess.Add(userToAdd2, "addUser");

            var usersToAdd = new List<UserModel>
            {
                userToAdd1,
                userToAdd2
            };

            var areUsersAddedToProjectSuccessful =
                ProjectAccess.AssignUsersToProject(projectToAdd, usersToAdd);
            var users = UserAccess.GetUsersByProjectId(projectToAdd.ProjectId);

            users.ListNotContains(userToAdd0);
            users.ListContains(userToAdd1);
            users.ListContains(userToAdd2);

            Assert.That(areUsersAddedToProjectSuccessful, Is.True, $"Adding new users to project should be successful {Messages.Display(projectToAdd)}.");

            Setup.RegisterToDeleteAfterTestExecution(userToAdd0);
            Setup.RegisterToDeleteAfterTestExecution(userToAdd1);
            Setup.RegisterToDeleteAfterTestExecution(userToAdd2);
            Setup.RegisterToDeleteAfterTestExecution(projectToAdd);
        }

        [Test]
        public void AssignUsersToProjectWhenUnauthorizedShouldThrow()
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

            var isUserAddedSuccessful = UserAccess.Add(userToAdd, "addUser");
            Assert.That(isUserAddedSuccessful, Is.True, $"Adding user should be successful {Messages.Display(userToAdd)}.");

            var usersToAdd = new List<UserModel>
            {
                userToAdd
            };

            var areUsersAddedToProjectSuccessful = false;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { areUsersAddedToProjectSuccessful = ProjectAccess.AssignUsersToProject(_project, usersToAdd); },
                "Exception should be thrown, because it should not be possible to add new users to project if you are not scrum master.");

            Assert.That(areUsersAddedToProjectSuccessful, Is.False, $"Adding new users to project should not be successful {Messages.Display(_project)}.");

            AppStateProvider.Instance.CurrentUser = _user;
            Setup.RegisterToDeleteAfterTestExecution(userToAdd);
        }

        [Test]
        public void NotifyUsersAboutEndOfSprint()
        {
            var isNotifySuccesful = ProjectAccess.NotifyUsersAboutEndOfSprint(3);
            var notNotifiedSprints = SprintAccess.GetNotNotifiedEndingSprints(3, true);

            notNotifiedSprints.ListNotContains(_sprint);
            Assert.That(isNotifySuccesful, Is.True, $"Notifying sprint should be succeful {Messages.Display(_sprint)}.");
        }
    }
}
