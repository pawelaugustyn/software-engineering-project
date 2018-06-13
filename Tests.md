# 1. Unit test 
### Rules
1. Test only logic - all database and UI stuff should be mocked
    >*Unit testing is designed to focus on small units of isolated code.*
2. Test should take place in ScrumItTest solution in UnitTestes directory at the same as in ScrumIt solution
3. Everythig that are common to all test should be in SetUp metod
     ```.cs
     private int _variable;

        [OneTimeSetUp]
        public void SetUp()
        {
            _variable = 12;
        }
    ```
4. All asserts should have form :  Assert.That(variable, codition, optionalMessageReturnedWhenTestFail)
    Example: 
    ```.cs
    Assert.That(userAge, Is.GreaterThan(18), "User shoul be adult");
    ```
    More: http://dotnetpattern.com/nunit-assert-examples
5. Do not duplicate (copy) declared in class values - use it
6. For the same method and different values to test you should NOT copy method, use instead of it :
    ```.cs
    [Test]
            [TestCase(10)]
            [TestCase(20)]
            [TestCase(13)]
            public void TestMethod(int inputValue)
            {
                Assert.That(inputValue, Is.GreaterThan(18), "User shoul be adult");
            }
    ```
7. Test name should be the same as class that is tested e.g. class User - class UserTests
8. Method of test should be meaningful and test cases should start with name of method that test and decribe state and expected result
    e.g User has LoginAs() method - LoginAsWithEmptyCredentialShouldFail()
9. Only public and internal method/class should be tested, private one will be covered by them
7. Test result are displayed (after run it manually) in View -> Other Windows -> Test Results or after run test in tested class
8. **Rhino Mock** 
Rhino Mocks will generate fake objects to replace the dependencies that you have, and then allow you to tell them, at runtime, how to behave. This functionality is very powerful, and it means that you can tell your fake objects, for each test, how to behave. It allows to test every element separately and test only part of code that we want to test.
Documentation: http://www.ayende.com/wiki/Rhino+Mocks+Documentation.ashx
Exaples: https://www.hibernatingrhinos.com/oss/rhino-mocks

# 2. Integration test 
1. Test functionality 
    >*Integration testing is a type of testing which is typically designed to test interactions between an application and a database backend.*
2. If you' d like to test logic only, mock db and UI and write unit test instead of integration one.
3. Steps to follow:
    - Use "IntegrationTest" attribute
    - Prepare environment - setup
    - Run a test
    - Check test result
    - Go back to the first point
4. The structure is the same as in Unit Tests, but we do not mock db.
    
# 3. UI test
1. Test window, all controls and their behaviour.

### Test Area to Cover
1. Log in
    - incorrect login 
    - incorrest password 
    - incorrect login and password
    - empty login
    - empty password
    - empty login and password
    - go as guest
2. Log out 
    - when you are logged in
    - try when you are not logged in
    - then log in as a different user and check if there aro NO remainders of previous user
3. Right to access - roles
    - check if you have particular role you can only do  :
        - Guest - read only mode
        - Developer - Guest + can edit tasks 
        - ScrumMaster - Everything
4. Navigation in application and components work properly
    - tabs
    - pop up winows
    - buttons - open correct window or ack as it is expected
    - scroll - is displayed and works
    - textbox - security!
    - combo box - correct values
    - main window: close, minimalize, resize, close then open
5. Current Sprint tab 
Tasks:
    - colors
        - set properly
        - after edit color in settings task colors on board edit as well
        - set color that was set before should be inpossible
     - appropriate navigation - change state of task
        - correct flow
        - put task to forbidden column
        - put task out  of the application window - state of task should not change
    - assigned user display in task picture
    - all info display in task window (color, name, descripton, points, time, users with pictures)
    - progress bar should be synchronized with current sprint state
    -  progress bar - test logic to calculate progress  
    - uncompleted sprint are signed as uncompleted by red cross
    - sprint all task point are presented
  6. Sprint History tab
     -   all task that are completed are selected as completed
        -   all sprints that ended appear in sprint list
        - actual sprit
  7. Backlog tab
        - there are all task that are not started yet
        - there are no task that are completed 
    8. Add task
        - added properly
        - canceled not added
        - with incorrect values not added
    9. User list tab
        -   all user displayed with correct picure and role
        -   users without picture displayed with default picture
  10. User setting
      - personal details
        - edit
        - remove
        - add picture
        - remove picture
 11. General settings
     - user
        - add
        - edit
        - remove (what appears in task that user were assigned to)
     - project
        - add
        - edit
        - remove (what appears in task that project belongs to)
     - sprint
        - add
        - edit
        - remove (what appears in history, were all task deleted)
        - e-mail remainder

### Implemented Integration Tests

1. UserAccessIntegrationTests
    ```
     AddEmptyUserShouldThrow [0:00.000] Success
     AddUserThatAlreadyExistShouldThrow [0:00.321] Success
     AddUserWithUniqueUsername [0:00.293] Success
     DeleteEmptyOrInvalidUserShouldDoNothing [0:00.080] Success
     DeleteUserWithUniqueUsername [0:00.352] Success
     DeleteYourselfShouldThrow [0:00.126] Success
     GetAllUsersShouldReturnCorrectUsers [0:00.271] Success
     GetUserByIdShouldNotReturnCorrectUser [0:00.032] Success
     GetUserByIdShouldReturnCorrectUser [0:00.030] Success
     GetUserByUsernameShouldNotReturnCorrectUser [0:00.035] Success
     GetUserByUsernameShouldReturnCorrectUser [0:00.029] Success
     GetUserPicture [0:00.282] Success
     GetUsersByLastNameShouldNotReturnCorrectUser [0:00.032] Success
     GetUsersByLastNameShouldReturnCorrectUser [0:00.029] Success
     GetUsersByProjectIdShouldNotReturnCorrectUsers [0:00.034] Success
     GetUsersByProjectIdShouldReturnCorrectUsers [0:00.030] Success
     GetUsersByTaskIdShoulNotReturnCorrectUsers [0:00.520] Success
     GetUsersByTaskIdShouldReturnCorrectUsers [0:00.577] Success
     LoginAsWithCorrectCredentialsShouldPass [0:00.032] Success
     LoginAsWithEmptyCredentialsShouldFail (3 tests) [0:00.107] Success
     LoginAsWithIncorrectCredentialsShouldFail (3 tests) [0:00.106] Success
     SetUserPicture [0:00.274] Success
     UpdateUserDataAsGuestShouldThrow [0:00.096] Success
     UpdateUserDataAsScrumMasterShouldBePossible [0:00.170] Success
     X_AddEmptyUserWhenUnauthorizedShouldThrow [0:00.032] Success
     X_DeleteUserWhenUnauthorizedShouldThrow [0:00.296] Success
     X_UpdateUserPasswordShouldBePossible [0:00.282] Success
    
3. TaskAccessIntegrationTests 
	```
     AssignFromBacklogToSprint [0:00.192] Success
     AssignUsersToTaskWhenAssignNewUser [0:00.076] Success
     AssignUsersToTaskWhenAssignNewUserAndDeassignOldUser [0:00.359] Success
     AssignUsersToTaskWhenUserIdsGivenWhenAssignNewUserAndDeassignOldUser [0:00.358] Success
     GetProjectBacklogTasksReturnCorrectTasks [0:00.238] Success
     GetProjectTasksByProjectIdShouldReturnCorrectTasks [0:00.031] Success
     GetProjectTasksBySprintIdReturnCorrectTasks [0:00.153] Success
     GetTaskByIdShouldReturnCorrectTasks [0:00.034] Success
     RemoveTask [0:00.163] Success
     SetNewColour [0:00.126] Success
     UpdateTask [0:00.126] Success
     UpdateTaskStage [0:00.122] Success
     X_AssignFromBacklogToSprintAsGuestShouldThrow [0:00.101] Success
     X_AssignUsersToTaskAsGuestShouldThrow [0:00.095] Success
     X_AssignUsersToTaskByIdAsGuestShouldThrow [0:00.099] Success
     X_CreateNewTaskAsGuestShouldThrow [0:00.092] Success
     X_RemoveTasktAsGuestShouldThrow [0:00.097] Success
     X_SetNewColourAsGuestShouldThrow [0:00.098] Success
     X_UpdateTaskAsGuestShouldThrow [0:00.117] Success
     X_UpdateTaskStageAsGuestShouldThrow [0:00.096] Success
	```

4. SprintAccessIntegrationTests 
    ```
     AddEmptySprintToProjectShouldThrow [0:00.001] Success
     AddSprintToProject [0:00.293] Success
     AddSprintToProjectWhenUnauthorizedShouldThrow [0:00.000] Success
     AddSprintToProjectWithDatesOverlapingAnotherSprintShouldThrow (7 tests) [0:02.531] Success
     AddSprintWithWrongDatesToProjectShouldThrow [0:00.170] Success
     CreatingSprintWithWrongDateFormatShouldThrow [0:00.001] Success
     GetAllSprintsByProjectIdShouldReturnCorrectSprints [0:00.037] Success
     GetEndOfLastSprintByProjectIdShouldReturnCorrectDate [0:00.033] Success
     GetMostRecentSprintByProjectIdShouldReturnCorrectLastFinishedSprint [0:00.095] Success
     GetMostRecentSprintByProjectIdShouldReturnCorrectNextSprint [0:00.061] Success
     GetMostRecentSprintByProjectIdShouldReturnCorrectRecentSprint [0:00.031] Success
     GetNotActiveSprintsByProjectIdShouldReturnCorrectSprints [0:00.068] Success
     GetNotNotifiedEndingSprintsShouldReturnCorrectSprints [0:00.295] Success
     GetOldSprintsByProjectIdShouldNotReturnCorrectSprints [0:00.035] Success
     GetOldSprintsByProjectIdShouldReturnCorrectSprints [0:00.030] Success
     GetSprintByIdShouldNotReturnCorrectSprint [0:00.029] Success
     GetSprintByIdShouldReturnCorrectSprint [0:00.034] Success
     GetSprintByProjectIdAndDateShouldNotReturnCorrectSprint [0:00.034] Success
     GetSprintByProjectIdAndDateShouldReturnCorrectSprint [0:00.030] Success
     GetSprintByProjectIdAndDateWithWrongDateShouldNotReturnCorrectSprint [0:00.030] Success
    ```
5. ProjectAccessIntegrationTests 
    ```
     AddEmptyProjectShouldThrow [0:00.014] Success
     AddNewUserToProjectThatAlreadyExistsShouldThrow [0:00.696] Success
     AddNewUserToProjectWhenUnauthorizedShouldThrow [0:00.256] Success
     AddNewUserToProjectWithUniqueUsername [0:00.326] Success
     AddProjectThatAlreadyExistShouldThrow [0:00.097] Success
     AddProjectWhenUnauthorizedShouldThrow [0:00.032] Success
     AddProjectWithUniqueName [0:00.221] Success
     AddProjectWithWrongColourShouldThrow [0:00.033] Success
     AddProjectWitwNotUniqueColourShouldThrow [0:00.287] Success
     AssignUsersToProject [0:01.011] Success
     AssignUsersToProjectWhenUnauthorizedShouldThrow [0:00.253] Success
     DeleteEmptyOrInvalidProjectShouldDoNothing [0:00.063] Success
     DeleteProjectWhenUnauthorizedShouldThrow [0:00.236] Success
     DeleteProjectWithUniqueName [0:00.287] Success
     GetAllProjectsShouldReturnCorrectProjects [0:00.034] Success
     GetProjectByIdShouldNotReturnCorrectProject [0:00.030] Success
     GetProjectByIdShouldReturnCorrectProject [0:00.033] Success
     GetProjectByNameShouldNotReturnCorrectProject [0:00.031] Success
     GetProjectByNameShouldReturnCorrectProject [0:00.034] Success
     GetProjectsByUserIdShouldNotReturnCorrectProjects [0:00.033] Success
     GetProjectsByUserIdShouldReturnCorrectProjects [0:00.032] Success
     NotifyUsersAboutEndOfSprint [0:03.978] Success
     UpdateProjectToEmptyProjectShouldThrow [0:00.192] Success
     UpdateProjectWhenUnauthorizedShouldThrow [0:00.190] Success
     UpdateProjectWithSameOrNewName [0:00.542] Success
     UpdateProjectWithWrongColourShouldThrow [0:00.231] Success
    ```
6. ConnectionIntegrationTests
    ```
     ConnExcl [0:00.000] Success
     Connect [0:00.001] Success
    ```
    
    
