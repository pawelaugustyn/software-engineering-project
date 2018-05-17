# Unit test 
### Rules
1. Test only logic - all database and UI stuff should be mocked
2. Test should take place in ScrumItTest solution at the same as in ScrumIt solution
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
### Test Area to Cover
1. Log in
    - incorrect login
    - incorrest password
    - incorrect login and password
    - empty login
    - empty password
    - empty login and password
    - go as guest
    - SQL injection
2. Log out 
    - when you are logged in
    - try when you are not logged in
    - then log in as a different user and check if there aro NO remainders of previous user
3. Right to access - roles
    - check if you have particular role you can only do  :
        - Guest - read only mode
        - Developer - Guest + can edit tasks 
        - ScrumMaster - Developer + everything despite scrum master settings
        - Admin  - everything
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


    