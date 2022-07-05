# Week 2: 04/07 - 08/07

[Monday](##1. Monday) - C# Basics & Unit Testing

[Tuesday](##2. Tuesday) - 

[Wednesday](##3. Wednesday) - 

[Thursday](##4. Thursday) - 

[Friday](##5. Friday) - 



## 1. Monday

* **Refactoring** changes the structure of the code without changing behaviour - highlight code, right-click and extract into new method
* **DAMP** - Descriptive and Meaningful Phrases
* Type `var` is a general type that infers the type with whatever is assigned to the variable
* To create a new *NUnit test class* - right-click solution-add-new project-search for NUnit test project-create
  * The `[Test]` attribute marks the method as a test so it will be ran by the test explorer
* Method signature for tests:
  * `public void GivenAVariable_NameOfClass_ReturnsSomeOutput()`
* To allow the test class to access the class to test:
  * right-click dependencies-add project reference-tick class name
  * check class method is public
  * add `using` statement for class in test class
* Example of a test (Arrange / Act / Assert):
  * `Assert.That(Program.ClassName(Variable), Is.EqualTo(Variable));`
* What makes a good unit test? **FIRST**:
  * **FAST** - Fast enough that users wont be discouraged from using
  * **INDEPENDENT** - Testing one thing and does not depend on previous tests
  * **REPEATABLE** - In any environment without varying results
  * **SELF VALIDATING** - In test explorer it should show pass/fail
  * **TIMELY** - Before production code
* **Boundary value analysis** - testing the boundaries of an expected result
* **Parameterised tests** - testing the parameters by taking arguments:
  * Change `[Test]` tag to `[TestCase(parameter)]` and provide a parameter in the method signature as required - Can provide multiple per method, and can include multiple parameters.
* **TDD (Test Driven Development)** - Create tests, test fails, refactor methods to pass tests and repeat
* **TFD (Test First Development)** - Create all tests first and adapt the code to pass the tests



## 2. Tuesday





## 3. Wednesday





## 4. Thursday





## 5. Friday