# Week 4: 18/07 - 22/07

**1.** [Monday](##1. Monday) - Attributes & TDD

**2.** [Tuesday](##2. Tuesday) - C# Core Test & GitHib Collaboration

**3.** [Wednesday](##3. Wednesday) - Big-O Notation & Recursion

**4.** [Thursday](##4. Thursday) - Refactoring, Code Smells & Design Patterns

**5.** [Friday](##5. Friday) - 

## 1. Monday

### Attributes

* Attributes are used to identify tests

* `[TestFixture]` - An attribute that marks a class that contains tests

* `[OneTimeSetup]` - It will run this method once before the tests are ran

* `[Setup]` - It will run this method once before every test

* `[OneTimeTearDown]` - A method that runs after all the tests have ran

* `[TearDown]` - A method that runs after each test has ran

* Unit tests must be isolated as it is not known the exact order they will run, and this can change each time

* `[Ignore("Reason to ignore")]` - stops the test explorer from running these indicated tests

* Characteristics of a good unit test
  
  * **F**ast - each tests should run fast
  * **I**solated - shouldn't affect other tests
  * **R**epeatable - should always produce the same result
  * **S**elf-checking - tests automatically inform if passed or failed
  * **T**imely - shouldn't take long to write the test

* `[Category("Name")]` - groups types of tests together as specified

* `[TestCaseSource] - used on parameterised tests to pass in different data types:
  
  * ```csharp
    [TestCaseSource("AddCases")]
    public void aNewTest(int a, int b, int c)
    {
        ...
    }
    private static object[] AddCases =
    {
        new int[] {1, 2, 3}
        new int[] {4, 5, 6}
    };
    
    ```

* The test case source name must match the new method name

* Can add multiple different types of objects this way, that will all be tested

### Test Driven Development

* Unit testing can act as living documentation of the code by looking at what expected results are meant to be

* More efficient and cheaper to find bugs at the unit testing phase

* Confirms the program works as expected

* Provides a suite of regression tests to confirm that the code continues to work at multiple stages

* Assists in refactoring code

* When you test often and fully it assists in writing good code

* Test Automation Pyramid:
  
  * 70% Unit Tests
  
  * 20% API/Integration/Component Tests
  
  * 10% GUI Tests

## 2. Tuesday

### GitHub Collaboration

* Only commit to the main branch at the end of each sprint

* Make all changes to the dev branch

* The feature branch is taken off the dev branch to work on individual features, multiple feature branches can be taken at the same time

* A pull request is used to merge a feature branch into the dev branch

* Any other users will then merge this into their feature branch and continue on

* `git branch` - is the main branch that needs to be commited at the end of the sprint

* `git checkout -b nameOfNewBranch` - creates a new branch and takes you to it

* `git checkout nameOfBranch` - takes to that branch

* `dotnet new console` - creates a new console app in the branch

* `git push -set-upstream origin dev` - pushes the commit to the dev branch

* `git pull origin` - to pull a branch made in github

* In github - settings - branches - add protection rule (require pull request before merging)

* Update default branch in settings to dev - when cloned after this, it will automatically refer to this branch

* Pull requests in github will show all requests from users
  
  * Files changed window to confirm the changes - review changes - happy - approve
  
  * Merge pull requests - confirm merge

## 3. Wednesday

## 4. Thursday

## 5. Friday
