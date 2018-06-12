using System;
using System.Collections.Generic;
using NUnit.Framework;
using ScrumIt;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumItTests.IntegrationTests.DataAccessTests
{
    [TestFixture, IntegrationTest]
    public class SprintAccessIntegrationTests
    {
        private UserModel _user;
        private ProjectModel _project;
        private SprintModel _sprint;
        private SprintModel _oldSprint;
        private SprintModel _futureSprint;
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
                ProjectColor = "#ff0000"
            };

            ProjectAccess.CreateNewProject(_project);
            Setup.RegisterToDeleteAfterTestExecution(_project);

            _oldSprint = new SprintModel
            {
                ParentProjectId = _project.ProjectId,
                EndDateTime = new DateTime(2018, 4, 30, 12, 00, 00),
                StartDateTime = new DateTime(2018, 3, 30, 12, 00, 00)
            };

            SprintAccess.CreateNewSprintForProject(_oldSprint);
            Setup.RegisterToDeleteAfterTestExecution(_oldSprint);

            _sprint = new SprintModel
            {
                ParentProjectId = _project.ProjectId,
                EndDateTime = new DateTime(2018, 6, 30, 12, 00, 00),
                StartDateTime = new DateTime(2018, 5, 30, 12, 00, 00)
            };

            SprintAccess.CreateNewSprintForProject(_sprint);
            Setup.RegisterToDeleteAfterTestExecution(_sprint);

            _futureSprint = new SprintModel
            {
                ParentProjectId = _project.ProjectId,
                EndDateTime = new DateTime(2018, 8, 30, 12, 00, 00),
                StartDateTime = new DateTime(2018, 7, 30, 12, 00, 00)
            };

            SprintAccess.CreateNewSprintForProject(_futureSprint);
            Setup.RegisterToDeleteAfterTestExecution(_futureSprint);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            UserModel.Logout();
        }

        [Test]
        public void GetSprintByIdShouldReturnCorrectSprint()
        {
            var sprint = SprintAccess.GetSprintById(_sprint.SprintId);

            Assertion.Equals(sprint, _sprint);
        }

        [Test]
        public void GetAllSprintsByProjectIdShouldReturnCorrectSprints()
        {
            var sprints = SprintAccess.GetAllSprintsByProjectId(_project.ProjectId);

            sprints.ListContains(_sprint);
            sprints.ListContains(_oldSprint);
            sprints.ListContains(_futureSprint);
        }

        [Test]
        public void GetNotActiveSprintsByProjectIdShouldReturnCorrectSprints()
        {
            var sprints = SprintAccess.GetNotActiveSprintsByProjectId(_project.ProjectId);

            sprints.ListNotContains(_sprint);
            sprints.ListContains(_oldSprint);
            sprints.ListContains(_futureSprint);
        }

        [Test]
        public void GetSprintByIdShouldNotReturnCorrectSprint()
        {
            var sprint = SprintAccess.GetSprintById(-1);

            Assertion.Equals(sprint, new SprintModel());
        }

        [Test]
        public void GetEndOfLastSprintByProjectIdShouldReturnCorrectDate()
        {
            var endDate = SprintAccess.GetEndOfLastSprintByProjectId(_project.ProjectId);

            Assert.That(endDate, Is.EqualTo(_futureSprint.EndDateTime), "Getting end date of last sprint in the project should return correct value");
        }

        [Test]
        public void GetSprintByProjectIdAndDateShouldReturnCorrectSprint()
        {
            var sprint = SprintAccess.GetSprintByProjectIdAndDate(_project.ProjectId, _sprint.StartDateTime.AddDays(1));

            Assertion.Equals(sprint, _sprint);
        }

        [Test]
        public void GetSprintByProjectIdAndDateShouldNotReturnCorrectSprint()
        {
            var sprint = SprintAccess.GetSprintByProjectIdAndDate(-1, _sprint.StartDateTime.AddDays(1));

            Assert.That(sprint, Is.Null, "Getting sprint with wrong projectId should not be successful.");
        }

        [Test]
        public void GetSprintByProjectIdAndDateWithWrongDateShouldNotReturnCorrectSprint()
        {
            var sprint = SprintAccess.GetSprintByProjectIdAndDate(_project.ProjectId, _oldSprint.StartDateTime.AddDays(-1));

            Assert.That(sprint, Is.Null, "Getting sprint with wrong date should not be successful.");
        }

        [Test]
        public void GetMostRecentSprintByProjectIdShouldReturnCorrectRecentSprint()
        {
            var sprint = SprintAccess.GetMostRecentSprintByProjectId(_project.ProjectId, _sprint.StartDateTime.AddDays(1));

            Assertion.Equals(sprint, _sprint);
        }

        [Test]
        public void GetMostRecentSprintByProjectIdShouldReturnCorrectNextSprint()
        {
            var sprint = SprintAccess.GetMostRecentSprintByProjectId(_project.ProjectId, _sprint.EndDateTime.AddDays(1));

            Assertion.Equals(sprint, _futureSprint);
        }

        [Test]
        public void GetMostRecentSprintByProjectIdShouldReturnCorrectLastFinishedSprint()
        {
            var sprint = SprintAccess.GetMostRecentSprintByProjectId(_project.ProjectId, _futureSprint.EndDateTime.AddDays(1));

            Assertion.Equals(sprint, _futureSprint);
        }

        [Test]
        public void GetOldSprintsByProjectIdShouldReturnCorrectSprints()
        {
            var sprints = SprintAccess.GetOldSprintsByProjectId(_project.ProjectId);

            sprints.ListContains(_oldSprint);
            sprints.ListNotContains(_sprint);
            sprints.ListNotContains(_futureSprint);
        }

        [Test]
        public void GetOldSprintsByProjectIdShouldNotReturnCorrectSprints()
        {
            var sprints = SprintAccess.GetOldSprintsByProjectId(-1);

            sprints.ListNotContains(_oldSprint);
            sprints.ListNotContains(_sprint);
            sprints.ListNotContains(_futureSprint);
        }

        [Test]
        public void AddSprintToProject()
        {
            var project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            ProjectAccess.CreateNewProject(project);
            Setup.RegisterToDeleteAfterTestExecution(project);

            var sprintToAdd = new SprintModel
            {
                ParentProjectId = project.ProjectId,
                EndDateTime = new DateTime(2018, 11, 30, 12, 00, 00),
                StartDateTime = new DateTime(2018, 10, 30, 12, 00, 00)
            };

            var isAddedSuccessful = SprintAccess.CreateNewSprintForProject(sprintToAdd);
            var sprintAfterAdd = SprintAccess.GetSprintById(sprintToAdd.SprintId);
            Setup.RegisterToDeleteAfterTestExecution(sprintToAdd);

            Assertion.Equals(sprintToAdd, sprintAfterAdd, "Sprint not added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.True, $"Adding sprint should be successful {Messages.Display(sprintToAdd)}.");
        }

        [Test]
        public void AddEmptySprintToProjectShouldThrow()
        {
            var sprintToAdd = new SprintModel();
            var isAddedSuccessful = false;

            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = SprintAccess.CreateNewSprintForProject(sprintToAdd); },
                "Exception should be thrown, because it should not be possible to add empty sprint to project.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding sprint should not be successful {Messages.Display(sprintToAdd)}.");
        }

        [Test]
        public void AddSprintWithWrongDatesToProjectShouldThrow()
        {
            var project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            ProjectAccess.CreateNewProject(project);
            Setup.RegisterToDeleteAfterTestExecution(project);

            var sprintToAdd = new SprintModel
            {
                ParentProjectId = project.ProjectId,
                EndDateTime = new DateTime(2019, 1, 1, 12, 00, 00),
                StartDateTime = new DateTime(2019, 1, 2, 12, 00, 00)
            };
            var isAddedSuccessful = false;

            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = SprintAccess.CreateNewSprintForProject(sprintToAdd); },
                "Exception should be thrown, because it should not be possible to add sprint with wrong dates to project.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding sprint should not be successful {Messages.Display(sprintToAdd)}.");
        }

        [Test]
        public void CreatingSprintWithWrongDateFormatShouldThrow()
        {
            SprintModel sprintToAdd = null;

            Assert.Throws<ArgumentOutOfRangeException>(delegate {
                sprintToAdd = new SprintModel
                {
                    ParentProjectId = _project.ProjectId,
                    EndDateTime = new DateTime(2018, 1, 40, 12, 00, 00),
                    StartDateTime = new DateTime(2018, 1, 30, 12, 00, 00)
                };
            }, "Exception should be thrown, because it should not be possible to create sprint with wrong date format.");

            Assert.That(sprintToAdd, Is.Null, "Creating sprint should not be successful.");
        }
        
        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        [TestCase(1, 1)]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void AddSprintToProjectWithDatesOverlapingAnotherSprintShouldThrow(int numberOfDaysToAddToStart, int numberOfDaysToAddToEnd)
        {
            var project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            ProjectAccess.CreateNewProject(project);
            Setup.RegisterToDeleteAfterTestExecution(project);

            var sprint = new SprintModel
            {
                ParentProjectId = project.ProjectId,
                EndDateTime = new DateTime(2018, 6, 10, 12, 00, 00),
                StartDateTime = new DateTime(2018, 6, 01, 12, 00, 00)
            };

            var isAddedSuccessful = SprintAccess.CreateNewSprintForProject(sprint);
            var sprintAfterAdd = SprintAccess.GetSprintById(sprint.SprintId);
            Setup.RegisterToDeleteAfterTestExecution(sprint);

            Assertion.Equals(sprint, sprintAfterAdd, "Sprint not added correctly to DB.");
            Assert.That(isAddedSuccessful, Is.True, $"Adding sprint should be successful {Messages.Display(sprint)}.");

            var overlapingSprintToAdd = new SprintModel
            {
                ParentProjectId = project.ProjectId,
                EndDateTime = new DateTime(2018, 6, 10, 12, 00, 00).AddDays(numberOfDaysToAddToStart),
                StartDateTime = new DateTime(2018, 6, 01, 12, 00, 00).AddDays(numberOfDaysToAddToEnd)
            };

            isAddedSuccessful = false;

            Assert.Throws<ArgumentException>(delegate { isAddedSuccessful = SprintAccess.CreateNewSprintForProject(overlapingSprintToAdd); },
                "Exception should be thrown, because it should not be possible to add sprint to project with overlaping dates of another sprint.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding sprint should not be successful {Messages.Display(overlapingSprintToAdd)}.");
        }

        [Test]
        public void AddSprintToProjectWhenUnauthorizedShouldThrow()
        {
            var sprintToAdd = new SprintModel
            {
                ParentProjectId = _project.ProjectId,
                EndDateTime = new DateTime(2018, 1, 30, 12, 00, 00),
                StartDateTime = new DateTime(2018, 1, 1, 12, 00, 00)
            };

            var isAddedSuccessful = false;
            UserModel.Logout();

            Assert.Throws<UnauthorizedAccessException>(delegate { isAddedSuccessful = SprintAccess.CreateNewSprintForProject(sprintToAdd); },
                "Exception should be thrown, because it should not be possible to add new sprint to project if you are not scrum master.");

            Assert.That(isAddedSuccessful, Is.False, $"Adding sprint should not be successful {Messages.Display(sprintToAdd)}.");

            AppStateProvider.Instance.CurrentUser = _user;
        }

        [Test]
        public void GetNotNotifiedEndingSprintsShouldReturnCorrectSprints()
        {
            var project = new ProjectModel
            {
                ProjectName = "TestProject".WithUniqueName(),
                ProjectColor = "#ff0000"
            };

            ProjectAccess.CreateNewProject(project);
            Setup.RegisterToDeleteAfterTestExecution(project);

            var sprintToAdd = new SprintModel
            {
                ParentProjectId = project.ProjectId,
                EndDateTime = DateTime.Parse( DateTime.Now.AddDays(1).ToString("yyyy-MM-dd hh:mm:ss") ),
                StartDateTime = DateTime.Parse( DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd hh:mm:ss") )
            };

            SprintAccess.CreateNewSprintForProject(sprintToAdd);
            Setup.RegisterToDeleteAfterTestExecution(sprintToAdd);

            var sprints = SprintAccess.GetNotNotifiedEndingSprints(3, true);

            sprints.ListContains(sprintToAdd);
        }
    }
}
